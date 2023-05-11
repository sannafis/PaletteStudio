using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaletteStudioApi.Services;
using PaletteStudioApi.Exceptions;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Authentication;
using PaletteStudioApi.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace PaletteStudioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthRepository _authRepository;

        public AuthController(ILogger<AuthController> logger, IAuthRepository authRepository)
        {
            this._logger = logger;
            this._authRepository = authRepository;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] UserDto userDto)
        {
            var errors = await _authRepository.Register(userDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                throw new BadRequestException(nameof(Register), ModelState, userDto.Email);
            }
            return Ok();
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] UserLoginDto userDto)
        {
            _logger.LogInformation($"Attempting Login for {userDto.Email}");

            var response = await _authRepository.Login(userDto);

            if (response == null)
            {
                throw new UnauthorizedException(nameof(Register), userDto.Email);
            }

            return Ok(response);
        }


        [HttpPost]
        [Route("refreshToken")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponseDto>> RefreshToken([FromBody] AuthResponseDto request)
        {
            var response = await _authRepository.VerifyRefreshToken(request);

            if (response == null)
            {
                throw new UnauthorizedException(nameof(Register), request.UserId);
            }

            return Ok(response);
        }
    }
}
