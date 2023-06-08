using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models
{
    public class ForegroundColourCreateDto
    {
        [Required(ErrorMessage = "Colour value required")]
        [RegularExpression("^#([0-9a-fA-f]{6}|[0-9a-fA-F]{3})$", ErrorMessage = "Hex value not in proper format")]
        [StringLength(7)]
        public string? ColourHexCode { get; set; } = string.Empty;
    }
}
