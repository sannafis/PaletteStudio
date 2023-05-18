using Microsoft.AspNetCore.Mvc;
using Cl = ColourLibrary;
using ColourLibrary;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourMetaData))]
    public class ColourDto
    {
        public string HexCode { get; set; } = string.Empty;

        public RGB RGB
        {
            get { return Cl.Colour.ToRGBFromHex(this.HexCode); }
        }

        public HSV HSV
        {
            get { return Cl.Colour.ToHSVFromRGB(this.RGB); }
        }
    }
}
