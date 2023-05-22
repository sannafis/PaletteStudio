using Microsoft.AspNetCore.Mvc;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourGroupMetaData))]
    public class ColourGroupCreateDto
    {
        public string? BackgroundColourHexCode { get; set; } = string.Empty;

        public List<ForegroundColourCreateDto> ForegroundColours { get; set; } = new List<ForegroundColourCreateDto>();
    }
}
