using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourGroupMetaData))]
    public class ColourGroup
    {
        public int Id { get; set; }

        [ForeignKey(nameof(BackgroundColourHexCode))]
        public string? BackgroundColourHexCode { get; set; } = string.Empty;
        public Colour? BackgroundColour { get; set; }

        [ForeignKey(nameof(PaletteId))]
        public int? PaletteId { get; set; }
        public Palette? Palette { get; set; }

        public virtual ICollection<ForegroundColour> ForegroundColours { get; set; } = new HashSet<ForegroundColour>();
    }
}
