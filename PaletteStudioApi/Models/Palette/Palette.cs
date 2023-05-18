﻿using Microsoft.AspNetCore.Mvc;
using PaletteStudioApi.Models.Authentication;
using PaletteStudioApi.Static;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(PaletteMetaData))]
    public class Palette
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Privacy { get; set; } = PrivacySetting.Private;

        public virtual ICollection<ColourGroup> ColourGroups { get; set; } = new HashSet<ColourGroup>();

        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
