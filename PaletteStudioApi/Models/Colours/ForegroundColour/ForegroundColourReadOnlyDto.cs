using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Cl = ColourLibrary;
using PaletteStudioApi.Static;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ForegroundColourMetaData))]
    public class ForegroundColourReadOnlyDto : BaseDto
    {
        public string ColourHexCode { get; set; } = string.Empty;

        public double Contrast { get; set; }

        public string RegularTextRating { get; set; } = "N/A";

        public string LargeTextRating { get; set; } = "N/A";
    }
}
