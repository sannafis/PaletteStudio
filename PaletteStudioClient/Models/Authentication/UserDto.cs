using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models.Authentication
{
    public class UserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(256)]
        public string Email { get; set; } = string.Empty;


        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [StringLength(50)]
        public string? FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? LastName { get; set; } = string.Empty;

        [StringLength(25)]
        public string? Nickname { get; set; } = string.Empty;
    }
}
