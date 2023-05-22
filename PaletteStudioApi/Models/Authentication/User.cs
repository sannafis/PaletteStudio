using Microsoft.AspNetCore.Identity;

namespace PaletteStudioApi.Models.Authentication
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Nickname { get; set; } = string.Empty;

        public ICollection<Palette> Palettes { get; set; } = new HashSet<Palette>();
    }
}
