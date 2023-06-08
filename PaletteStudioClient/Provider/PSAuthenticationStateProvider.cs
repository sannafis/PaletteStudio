using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PaletteStudioClient.Provider
{
    public class PSAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtTokenHandler;

        public PSAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this._localStorage = localStorage;
            this._jwtTokenHandler = new JwtSecurityTokenHandler();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            var token = await _localStorage.GetItemAsync<string>("accessToken");
            if(token == null)
            {
                // No token
                return new AuthenticationState(user);
            }

            var tokenContent = _jwtTokenHandler.ReadJwtToken(token);

            if(tokenContent.ValidTo < DateTime.Now) // expired token
            {
                await _localStorage.RemoveItemAsync("accessToken");
                return new AuthenticationState(user);
            }

            // parse token claims
            var claims = await GetUserClaims();

            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            return new AuthenticationState(user);
        }

        public async Task LogIn()
        {
            var claims = await GetUserClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authenticationState = Task.FromResult(new AuthenticationState(user));

            //Change Authentication State
            NotifyAuthenticationStateChanged(authenticationState);
        }

        public async Task LogOut()
        {
            // remove token info from local storage
            await _localStorage.RemoveItemAsync("accessToken");

            // change authentication state to log out user
            var authenticationState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
            NotifyAuthenticationStateChanged(authenticationState);
        }

        public async Task<List<Claim>> GetUserClaims()
        {
            var savedToken = await _localStorage.GetItemAsync<string>("accessToken");
            var tokenContent = _jwtTokenHandler.ReadJwtToken(savedToken);
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
