using ColourLibrary;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourGroupMetaData))]
    public class ColourGroupCreateDto
    {
        public string BackgroundColourHexCode { get; set; } = string.Empty;

        public List<ForegroundColourCreateDto> ForegroundColours { get; set; } = new List<ForegroundColourCreateDto>();
    }
}
