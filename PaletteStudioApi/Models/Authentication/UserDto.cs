using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models.Authentication
{
    public class UserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nickname { get; set; }
    }
}
