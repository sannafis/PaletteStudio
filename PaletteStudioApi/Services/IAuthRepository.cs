using Microsoft.AspNetCore.Identity;
using PaletteStudioApi.Models.Authentication;

namespace PaletteStudioApi.Services
{
    public interface IAuthRepository
    {
        Task<IEnumerable<IdentityError>> Register(UserDto userDto);
        Task<AuthResponseDto> Login(UserLoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
        Task<bool> UserExists(string email);
        Task<string> CurrentUser();
    }
}
