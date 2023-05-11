using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaletteStudioApi.Models
{

    public class ColourMetaData
    {

        
        [Required(ErrorMessage ="Colour value required")]
        [RegularExpression("^#([0-9a-fA-f]{6}|[0-9a-fA-F]{3})$", ErrorMessage = "Hex value not in proper format")]
        [StringLength(7)]
        public string? HexCode { get; set; } // default: grey
    }
}
