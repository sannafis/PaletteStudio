﻿using ColourLibrary;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourGroupMetaData))]
    public class ColourGroupReadOnlyDto : BaseDto
    {
        public string BackgroundColourHexCode { get; set; } = string.Empty;

        public List<ForegroundColourReadOnlyDto> ForegroundColours { get; set; } = new List<ForegroundColourReadOnlyDto>();
    }
}
