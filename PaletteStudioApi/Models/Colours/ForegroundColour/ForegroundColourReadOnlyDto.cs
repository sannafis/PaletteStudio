using Microsoft.AspNetCore.Mvc;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ForegroundColourMetaData))]
    public class ForegroundColourReadOnlyDto : BaseDto
    {
        public string? ColourHexCode { get; set; } = string.Empty;

        public double? Contrast { get; set; }

        public string RegularTextRating { get; set; } = "N/A";

        public string LargeTextRating { get; set; } = "N/A";
    }
}
