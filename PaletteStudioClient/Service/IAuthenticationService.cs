using PaletteStudioClient.Models.Authentication;
using System.Threading.Tasks;

namespace PaletteStudioClient.Service
{
    public interface IAuthenticationService
    {
        Task<Response<AuthResponse>> AuthenticateAsync(UserLoginDto user);
        Task Logout();
    }
}
