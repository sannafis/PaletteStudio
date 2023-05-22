using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models.Authentication
{
    public class UserMetaData
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(256)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
