using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models
{
    public class PaletteCreateDto
    {
        [StringLength(50, ErrorMessage = "Max character limit: 50.")]
        public string Name { get; set; } = "Untitled";

        public List<ColourGroupCreateDto> ColourGroups { get; set; } = new List<ColourGroupCreateDto>();

    }
}
