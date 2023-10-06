using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models
{
    public class ForegroundColourReadOnlyDto : BaseDto
    {
        [Required(ErrorMessage = "Colour value required")]
        [RegularExpression("^#([0-9a-fA-f]{6}|[0-9a-fA-F]{3})$", ErrorMessage = "Hex value not in proper format")]
        [StringLength(7)]
        public string? ColourHexCode { get; set; } = string.Empty;

        public double? Contrast { get; set; }

        public string RegularTextRating { get; set; } = "N/A";

        public string LargeTextRating { get; set; } = "N/A";
    }
}
