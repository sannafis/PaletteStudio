using Newtonsoft.Json;
using PaletteStudioClient.Models;
using PaletteStudioClient.Models.Authentication;
using PaletteStudioClient.Models.Paging;
using System.Net.Http;
using System;
using System.Threading;
using System.Globalization;
using System.Text;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using Blazored.LocalStorage;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace PaletteStudioClient.Service
{
    public partial class Client : IClient
    {
        private HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private Lazy<JsonSerializerSettings> _settings;
        protected JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

        public Client(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _settings = new Lazy<JsonSerializerSettings>();
        }

        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }

        public bool ReadResponseAsString { get; set; }

        public Task RegisterAsync(UserDto body)
        {
            return RegisterAsync(body, CancellationToken.None);
        }

        public async Task RegisterAsync(UserDto body, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append("api/Auth/register");

            var client = _httpClient;
            var disposeClient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body, _settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("POST");

                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (status == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Unexpected HTTP status code (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient)
                    client.Dispose();
            }
        }

        public Task<AuthResponse> LoginAsync(UserLoginDto body)
        {
            return LoginAsync(body, CancellationToken.None);
        }

        public async Task<AuthResponse> LoginAsync(UserLoginDto body, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append("api/Auth/login");

            var client = _httpClient;
            var disposeClient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body, _settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item_ in response.Content.Headers)
                                headers[item_.Key] = item_.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (status == 200)
                        {
                            var objectresponse = await ReadObjectResponseAsync<AuthResponse>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectresponse.Object == null)
                            {
                                throw new ApiException("Unexpected Response.", status, objectresponse.Text, headers, null);
                            }
                            return objectresponse.Object;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Unexpected HTTP status code (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient)
                    client.Dispose();
            }
        }

        public Task<PagedData<PaletteReadOnlyDto>> PalettesGETAsync(int? pageNumber, int? pageSize)
        {
            return PalettesGETAsync(pageNumber, pageSize, CancellationToken.None);
        }

        public async Task<PagedData<PaletteReadOnlyDto>> PalettesGETAsync(int? pageNumber, int? pageSize, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append("api/Palettes/GetAllPaged?");
            if (pageNumber != null)
            {
                urlBuilder.Append(Uri.EscapeDataString("PageNumber") + "=").Append(Uri.EscapeDataString(ConvertToString(pageNumber, CultureInfo.InvariantCulture))).Append("&");
            }
            if (pageSize != null)
            {
                urlBuilder.Append(Uri.EscapeDataString("PageSize") + "=").Append(Uri.EscapeDataString(ConvertToString(pageSize, CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder.Length--;

            var client = _httpClient;
            var disposeClient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (status == 200)
                        {
                            var objectResponse = await ReadObjectResponseAsync<PagedData<PaletteReadOnlyDto>>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Object == null)
                            {
                                throw new ApiException("Unexpected Response.", status, objectResponse.Text, headers, null);
                            }
                            return objectResponse.Object;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Unexpected HTTP status code (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient)
                    client.Dispose();
            }
        }

        public Task<PagedData<PaletteReadOnlyDto>> PalettesGETPublicAsync(int? pageNumber, int? pageSize)
        {
            return PalettesGETAsync(pageNumber, pageSize, CancellationToken.None);
        }

        public async Task<PagedData<PaletteReadOnlyDto>> PalettesGETPublicAsync(int? pageNumber, int? pageSize, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append("api/Palettes/GetAllPublicPaged?");
            if (pageNumber != null)
            {
                urlBuilder.Append(Uri.EscapeDataString("PageNumber") + "=").Append(Uri.EscapeDataString(ConvertToString(pageNumber, CultureInfo.InvariantCulture))).Append("&");
            }
            if (pageSize != null)
            {
                urlBuilder.Append(Uri.EscapeDataString("PageSize") + "=").Append(Uri.EscapeDataString(ConvertToString(pageSize, CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder.Length--;

            var client = _httpClient;
            var disposeClient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (status == 200)
                        {
                            var objectResponse = await ReadObjectResponseAsync<PagedData<PaletteReadOnlyDto>>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Object == null)
                            {
                                throw new ApiException("Unexpected Response.", status, objectResponse.Text, headers, null);
                            }
                            return objectResponse.Object;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Unexpected HTTP status code (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient)
                    client.Dispose();
            }
        }

        public Task<PaletteReadOnlyDto> PalettePOSTAsync(PaletteCreateDto body)
        {
            return PalettePOSTAsync(body, CancellationToken.None);
        }

        public async Task<PaletteReadOnlyDto> PalettePOSTAsync(PaletteCreateDto body, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append("api/Palettes");

            var client = _httpClient;
            var disposeclient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body, _settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("POST");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (status == 200)
                        {
                            var objectresponse = await ReadObjectResponseAsync<PaletteReadOnlyDto>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectresponse.Object == null)
                            {
                                throw new ApiException("Unexpected Response.", status, objectresponse.Text, headers, null);
                            }
                            return objectresponse.Object;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Unexpected HTTP status code (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeclient)
                    client.Dispose();
            }
        }

        public Task PalettePUTAsync(int id, PaletteUpdateDto body)
        {
            return PalettePUTAsync(id, body, CancellationToken.None);
        }

        public async Task PalettePUTAsync(int id, PaletteUpdateDto body, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append("api/Palettes/{id}");
            urlBuilder.Replace("{id}", Uri.EscapeDataString(ConvertToString(id, CultureInfo.InvariantCulture)));

            var client = _httpClient;
            var disposeClient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(body, _settings.Value));
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Method = new HttpMethod("PUT");

                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (status == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Unexpected HTTP status code (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient)
                    client.Dispose();
            }
        }

        public Task PaletteDELETEAsync(int id)
        {
            return PaletteDELETEAsync(id, CancellationToken.None);
        }
        public async Task PaletteDELETEAsync(int id, CancellationToken cancellationToken)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append("api/Palettes/{id}");
            urlBuilder.Replace("{id}", Uri.EscapeDataString(ConvertToString(id, CultureInfo.InvariantCulture)));

            var client = _httpClient;
            var disposeClient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("DELETE");

                    var url = urlBuilder.ToString();
                    request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeReponse = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (status == 200)
                        {
                            return;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("Unexpected HTTP status code (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeReponse)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient)
                    client.Dispose();
            }
        }

        public Task<PaletteReadOnlyDto> PaletteGETAsync(int? id)
        {
            return PaletteGETAsync(id, CancellationToken.None);
        }

        public async Task<PaletteReadOnlyDto> PaletteGETAsync(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            var urlBuilder = new StringBuilder();
            urlBuilder.Append("api/Palettes/{id}");
            urlBuilder.Replace("{id}", Uri.EscapeDataString(ConvertToString(id, CultureInfo.InvariantCulture)));

            var client = _httpClient;
            var disposeClient = false;
            try
            {
                using (var request = new HttpRequestMessage())
                {
                    request.Method = new HttpMethod("GET");
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    var url_ = urlBuilder.ToString();
                    request.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse = true;
                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (status == 200)
                        {
                            var objectResponse = await ReadObjectResponseAsync<PaletteReadOnlyDto>(response, headers, cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
                            }
                            return objectResponse.Object;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse)
                            response.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient)
                    client.Dispose();
            }
        }

        protected async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (JsonException ex)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, ex);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var streamReader = new StreamReader(responseStream))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var serializer = JsonSerializer.Create(JsonSerializerSettings);
                        var typedBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (JsonException ex)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, ex);
                }
            }
        }

        private string ConvertToString(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return "";
            }

            if (value is Enum)
            {
                var name = Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = CustomAttributeExtensions.GetCustomAttribute(field, typeof(EnumMemberAttribute))
                            as EnumMemberAttribute;
                        if (attribute != null)
                        {
                            return attribute.Value != null ? attribute.Value : name;
                        }
                    }

                    var converted = Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                    return converted == null ? string.Empty : converted;
                }
            }
            else if (value is bool)
            {
                return Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[])
            {
                return Convert.ToBase64String((byte[])value);
            }
            else if (value.GetType().IsArray)
            {
                var array = Enumerable.OfType<object>((System.Array)value);
                return string.Join(",", Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
            }

            var result = Convert.ToString(value, cultureInfo);
            return result == null ? "" : result;
        }

    }
}

