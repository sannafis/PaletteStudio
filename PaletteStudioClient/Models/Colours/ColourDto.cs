using Microsoft.AspNetCore.Mvc;
using Cl = ColourLibrary;
using ColourLibrary;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models
{
    public class ColourDto
    {
        [Required(ErrorMessage = "Colour value required")]
        [RegularExpression("^#([0-9a-fA-f]{6}|[0-9a-fA-F]{3})$", ErrorMessage = "Hex value not in proper format")]
        [StringLength(7)]
        public string HexCode { get; set; } = string.Empty;

        public RGB RGB
        {
            get { return Cl.Colour.ToRGBFromHex(this.HexCode); }
        }

        public HSV HSV
        {
            get { return Cl.Colour.ToHSVFromRGB(this.RGB); }
        }
    }
}
