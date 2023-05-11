using ColourLibrary;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourGroupMetaData))]
    public class ColourGroup
    {
        public int Id { get; set; }

        [ForeignKey(nameof(BackgroundColourHexCode))]
        public string BackgroundColourHexCode { get; set; } = string.Empty;
        public Colour? BackgroundColour { get; set; }

        [ForeignKey(nameof(PaletteId))]
        public int PaletteId { get; set; }
        public Palette? Palette { get; set; }

        [JsonIgnore]
        public virtual ICollection<ForegroundColour> ForegroundColours { get; set; } = new HashSet<ForegroundColour>();
    }
}
