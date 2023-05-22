using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models
{
    public class PaletteMetaData
    {

        [Required(ErrorMessage = "Palette name is required.")]
        [StringLength(50, ErrorMessage = "Max character limit: 50.")]
        public string Name { get; set; } = "Untitled";

        [Required(ErrorMessage = "No User provided.")]
        public int? UserId { get; set; }
    }
}
