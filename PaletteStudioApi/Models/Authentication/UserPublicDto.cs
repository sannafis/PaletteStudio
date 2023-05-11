using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models.Authentication
{
    public class UserPublicDto
    {
        public string Email { get; set; } = string.Empty;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nickname { get; set; }

        public IList<Palette> Palettes { get; set; } = new List<Palette>();
    }
}
