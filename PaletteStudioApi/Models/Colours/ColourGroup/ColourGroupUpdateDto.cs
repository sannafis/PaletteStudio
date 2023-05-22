using Microsoft.AspNetCore.Mvc;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourGroupMetaData))]
    public class ColourGroupUpdateDto : BaseDto
    {
        public string? BackgroundColourHexCode { get; set; } = string.Empty;

        public List<ForegroundColourUpdateDto> ForegroundColours { get; set; } = new List<ForegroundColourUpdateDto>();
    }
}
