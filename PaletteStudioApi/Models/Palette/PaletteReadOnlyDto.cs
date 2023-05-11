using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace PaletteStudioApi.Models {
    [ModelMetadataType(typeof(PaletteMetaData))]
    public class PaletteReadOnlyDto : BaseDto
    {
        public string? Name { get; set; }
    
        public List<ColourGroupReadOnlyDto> ColourGroups { get; set; } = new List<ColourGroupReadOnlyDto>();

    }
}
