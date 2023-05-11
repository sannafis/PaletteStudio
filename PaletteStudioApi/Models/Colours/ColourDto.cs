
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourMetaData))]
    public class ColourDto
    {
        public string HexCode { get; set; } = string.Empty;

        //public RGB RGB
        //{
        //    get
        //    {
        //        return Cl.Colour.ToRGB(this.HexCode);
        //    }
        //}

        //public HSV HSV
        //{
        //    get
        //    {
        //        return Cl.Colour.ToHSV(this.RGB);
        //    }
        //}

        //public ICollection<ColourGroup> ColourGroups = new HashSet<ColourGroup>();
    }
}
