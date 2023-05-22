using Microsoft.AspNetCore.Mvc;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ForegroundColourMetaData))]
    public class ForegroundColourCreateDto
    {
        public string? ColourHexCode { get; set; } = string.Empty;
    }
}
