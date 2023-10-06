using Microsoft.AspNetCore.Mvc;
using PaletteStudioApi.Static;

namespace PaletteStudioApi.Models {
    [ModelMetadataType(typeof(PaletteMetaData))]
    public class PaletteUpdateDto : BaseDto
    {
        public string? Name { get; set; } = "Untitled";

        public string Privacy { get; set; } = PrivacySetting.Private;

        public List<ColourGroupUpdateDto> ColourGroups { get; set; } = new List<ColourGroupUpdateDto>();

    }
}
