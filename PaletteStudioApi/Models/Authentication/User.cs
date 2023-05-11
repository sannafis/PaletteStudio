using Microsoft.AspNetCore.Identity;

namespace PaletteStudioApi.Models.Authentication
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nickname { get; set; }
    }
}
