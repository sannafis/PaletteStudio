using Microsoft.AspNetCore.Mvc;

namespace PaletteStudioApi.Models {
    [ModelMetadataType(typeof(PaletteMetaData))]
    public class PaletteCreateDto
    {
        public string Name { get; set; } = "Untitled";

        public List<ColourGroupCreateDto> ColourGroups { get; set; } = new List<ColourGroupCreateDto>();

    }
}
