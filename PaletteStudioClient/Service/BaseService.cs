using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading.Tasks;

namespace PaletteStudioClient.Service
{
    public class BaseService
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorage;

        public BaseService(IClient client, ILocalStorageService localStorage)
        {
            this._client = client;
            this._localStorage = localStorage;
        }
        protected Response<Guid> ConvertApiException<Guid>(ApiException ex)
        {
            switch (ex.StatusCode)
            {
                case 400:
                    return new Response<Guid> { Message = "Validation Errors.", ValidationErrors = ex.Response, Success = false };
                case 404:
                    return new Response<Guid> { Message = "Not Found.", Success = false };
                default:
                    return new Response<Guid> { Message = "Something went wrong. Please try again.", Success = false };
            }
        }

        protected async Task GetToken()
        {
            var token = await _localStorage.GetItemAsync<string>("accessToken");
            if (token != null)
            {
                // add header to token
                _client.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            }
        }
    }
}
