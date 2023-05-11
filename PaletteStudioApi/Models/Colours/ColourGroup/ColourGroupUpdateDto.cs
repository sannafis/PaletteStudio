using ColourLibrary;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourGroupMetaData))]
    public class ColourGroupUpdateDto : BaseDto
    {
        public string BackgroundColourHexCode { get; set; } = string.Empty;

        public List<ForegroundColourUpdateDto> ForegroundColours { get; set; } = new List<ForegroundColourUpdateDto>();
    }
}
