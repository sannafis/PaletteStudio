using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaletteStudioClient.Models.Authentication;
using PaletteStudioClient.Provider;
using System.Threading.Tasks;

namespace PaletteStudioClient.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            this._httpClient = httpClient;
            this._localStorage = localStorage;
            this._authStateProvider = authStateProvider;
        }
        public async Task<Response<AuthResponse>> AuthenticateAsync(UserLoginDto user)
        {
            Response<AuthResponse> response;
            try
            {
                var result = await _httpClient.LoginAsync(user);
                response = new Response<AuthResponse>
                {
                    Data = result,
                    Success = true
                };

                // collect token
                await _localStorage.SetItemAsync("accessToken", result.Token);

                // Change authentication state
                await ((PSAuthenticationStateProvider)_authStateProvider).LogIn();
            }catch(ApiException exception)
            {
                response = new Response<AuthResponse>
                {
                    Data = null,
                    Success = false
                };
            }
            return response;
        }

        public async Task Logout()
        {
            // Change authentication state and logout user
            await ((PSAuthenticationStateProvider)_authStateProvider).LogOut();
        }
    }
}
