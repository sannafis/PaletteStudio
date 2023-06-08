using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models
{
    public class ColourGroupUpdateDto : BaseDto
    {
        [Required(ErrorMessage = "Each colour group must have an associated background/main colour.")]
        [RegularExpression("^#([0-9a-fA-f]{6}|[0-9a-fA-F]{3})$", ErrorMessage = "Hex value not in proper format.")]
        [StringLength(7)]
        public string? BackgroundColourHexCode { get; set; } = string.Empty;

        public List<ForegroundColourUpdateDto> ForegroundColours { get; set; } = new List<ForegroundColourUpdateDto>();
    }
}
