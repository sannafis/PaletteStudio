using Microsoft.AspNetCore.Mvc;

namespace PaletteStudioApi.Models.Authentication
{
    [ModelMetadataType(typeof(UserMetaData))]
    public class UserLoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
