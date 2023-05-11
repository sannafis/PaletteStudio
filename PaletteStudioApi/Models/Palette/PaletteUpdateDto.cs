﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace PaletteStudioApi.Models {
    [ModelMetadataType(typeof(PaletteMetaData))]
    public class PaletteUpdateDto : BaseDto
    {
        public string? Name { get; set; }

        public List<ColourGroupUpdateDto> ColourGroups { get; set; } = new List<ColourGroupUpdateDto>();

    }
}
