using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PaletteStudioApi.Contracts;
using PaletteStudioApi.Models.Authentication;
using PaletteStudioApi.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaletteStudioApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private User _user;

        private const string _provider = "PaletteStudioApi";
        private const string _refreshToken = "RefreshToken";

        public AuthRepository(IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IWebHostEnvironment environment)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
            this._environment = environment;
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, _provider, _refreshToken);
            var refreshToken = await _userManager.GenerateUserTokenAsync(_user, _provider, _refreshToken);

            var result = _userManager.SetAuthenticationTokenAsync(_user, _provider, _refreshToken, refreshToken);

            return refreshToken;
        }

        public async Task<string> GenerateToken()
        {
            // Default key for demo purposes
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            if (_environment.IsDevelopment()) // get actual secret key while in development
            {
                securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            }
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,_user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim(CustomClaimTypes.Uid, _user.Id)
            }
            .Union(roleClaims);

            var token = new JwtSecurityToken
            (
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtSettings:DurationDays"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<AuthResponseDto> Login(UserLoginDto loginDto)
        {
            _user = await _userManager.FindByEmailAsync(loginDto.Email);

            var passwordValid = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if (!passwordValid || _user == null) { return null; }

            var token = await GenerateToken();

            return new AuthResponseDto
            {
                UserId = _user.Id,
                Token = token,
                RefreshToken = await CreateRefreshToken()
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(UserDto userDto)
        {
            _user = _mapper.Map<User>(userDto);
            _user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(_user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }

            return result.Errors;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = token.Claims.ToList().FirstOrDefault(c=>c.Type == JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByNameAsync(username);

            if(_user == null || _user.Id != request.UserId)
            {
                return null;
            }

            var isRefreshTokenValid = await _userManager.VerifyUserTokenAsync(_user, _provider, _refreshToken, request.Token);

            if (isRefreshTokenValid)
            {
                var newToken = await GenerateToken();
                return new AuthResponseDto
                {
                    UserId = _user.Id,
                    Token = newToken,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }
    }
}
