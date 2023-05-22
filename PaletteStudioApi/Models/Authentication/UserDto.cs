using Microsoft.AspNetCore.Mvc;

namespace PaletteStudioApi.Models.Authentication
{
    [ModelMetadataType(typeof(UserMetaData))]
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Nickname { get; set; } = string.Empty;
    }
}
