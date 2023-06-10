using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ForegroundColourMetaData))]
    public class ForegroundColour
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ColourGroupId))]
        public int? ColourGroupId { get; set; }
        public ColourGroup? ColourGroup { get; set; }

        [ForeignKey(nameof(ColourHexCode))]
        public string? ColourHexCode { get; set; } = string.Empty;
        public Colour? Colour { get; set; }
    }
}
