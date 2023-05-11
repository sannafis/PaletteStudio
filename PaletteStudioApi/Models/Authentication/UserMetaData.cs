using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models.Authentication
{
    public class UserMetaData
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
