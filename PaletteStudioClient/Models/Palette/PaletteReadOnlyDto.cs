using Microsoft.AspNetCore.Mvc;
using PaletteStudioApi.Static;
using System.Collections.Generic;

namespace PaletteStudioClient.Models
{
    public class PaletteReadOnlyDto : BaseDto
    {
        public string Name { get; set; } = "Untitled";

        public string Privacy { get; set; } = PrivacySetting.Private;

        public List<ColourGroupReadOnlyDto> ColourGroups { get; set; } = new List<ColourGroupReadOnlyDto>();

    }
}
