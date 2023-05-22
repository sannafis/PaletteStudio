using Microsoft.AspNetCore.Mvc;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ForegroundColourMetaData))]
    public class ForegroundColourUpdateDto : BaseDto
    {
        public string? ColourHexCode { get; set; } = string.Empty;
    }
}
