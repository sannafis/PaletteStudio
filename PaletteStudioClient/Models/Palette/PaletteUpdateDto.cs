using Microsoft.AspNetCore.Mvc;
using PaletteStudioApi.Static;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models
{
    public class PaletteUpdateDto : BaseDto
    {
        [StringLength(50, ErrorMessage = "Max character limit: 50.")]
        public string Name { get; set; } = "Untitled";

        public string Privacy { get; set; } = PrivacySetting.Private;

        public List<ColourGroupUpdateDto> ColourGroups { get; set; } = new List<ColourGroupUpdateDto>();

    }
}
