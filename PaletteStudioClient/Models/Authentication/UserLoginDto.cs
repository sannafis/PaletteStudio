using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models.Authentication
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
