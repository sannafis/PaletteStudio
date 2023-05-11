using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PaletteStudioApi.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string name, object key) : base($"Invalid Request in {name} for Key: {key}")
        {

        }

        public BadRequestException(string name, ModelStateDictionary? modelstate, object key) : base($"Invalid Request in {name} for Key: {key}. Errors: {modelstate}")
        {

        }
    }
}
