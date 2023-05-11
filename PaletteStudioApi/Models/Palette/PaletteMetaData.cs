using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace PaletteStudioApi.Models
{
    public class PaletteMetaData
    {

        [Required(ErrorMessage = "Palette name is required.")]
        [StringLength(50, ErrorMessage = "Max character limit: 50.")]
        public string? Name { get; set; }


    }
}
