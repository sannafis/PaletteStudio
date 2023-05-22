using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models
{
    public class ColourGroupMetaData
    {
        [Required(ErrorMessage ="Each colour group must have an associated background/main colour.")]
        [RegularExpression("^#([0-9a-fA-f]{6}|[0-9a-fA-F]{3})$", ErrorMessage = "Hex value not in proper format.")]
        [StringLength(7)]
        public string? BackgroundColourHexCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Palette Id is required.")]
        public int? PaletteId { get; set; }

    }
}
