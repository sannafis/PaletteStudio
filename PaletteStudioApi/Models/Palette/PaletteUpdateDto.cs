using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using PaletteStudioApi.Static;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace PaletteStudioApi.Models {
    [ModelMetadataType(typeof(PaletteMetaData))]
    public class PaletteUpdateDto : BaseDto
    {
        public string? Name { get; set; }

        public string Privacy { get; set; } = PrivacySetting.Private;

        public List<ColourGroupUpdateDto> ColourGroups { get; set; } = new List<ColourGroupUpdateDto>();

    }
}
