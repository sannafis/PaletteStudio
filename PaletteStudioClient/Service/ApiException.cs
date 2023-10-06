using System;
using System.Collections.Generic;

namespace PaletteStudioClient.Service
{
    public class ApiException : Exception
    {
        public int? StatusCode { get; private set; }

        public string? Response { get; private set; }

        public IReadOnlyDictionary<string, IEnumerable<string>>? Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, Exception exception)
        : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), exception)

        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }
    }
}
