using Microsoft.AspNetCore.Identity;
using PaletteStudioApi.Models.Authentication;

namespace PaletteStudioApi.Contracts
{
    public interface IAuthRepository
    {
        Task<IEnumerable<IdentityError>> Register(UserDto userDto);
        Task<AuthResponseDto> Login(UserLoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
