using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourMetaData))]
    public class Colour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string HexCode { get; set; } = string.Empty;

        public virtual ICollection<ColourGroup> ColourGroups { get; set; } = new HashSet<ColourGroup>();

        public virtual ICollection<ForegroundColour> ForegroundColours { get; set; } = new HashSet<ForegroundColour>();
    }

}
