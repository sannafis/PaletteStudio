using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cl= ColourLibrary;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ForegroundColourMetaData))]
    public class ForegroundColourUpdateDto : BaseDto
    {

        public string ColourHexCode { get; set; } = string.Empty;
    }
}
