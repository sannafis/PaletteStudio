using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioClient.Models
{
    public class ColourGroupReadOnlyDto : BaseDto
    {
        public string? BackgroundColourHexCode { get; set; } = string.Empty;

        public List<ForegroundColourReadOnlyDto> ForegroundColours { get; set; } = new List<ForegroundColourReadOnlyDto>();
    }
}
