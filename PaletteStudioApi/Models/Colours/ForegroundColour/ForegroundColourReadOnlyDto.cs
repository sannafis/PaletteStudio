using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Cl= ColourLibrary;
using PaletteStudioApi.Static;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ForegroundColourMetaData))]
    public class ForegroundColourReadOnlyDto : BaseDto
    {

        public string ColourHexCode { get; set; } = string.Empty;
        //public double? Contrast => CalculateContrast();

        //public string RegularTextRating
        //{
        //    get
        //    {
        //        if (this.Contrast >= WCAGRequirement.RegularTextAAA)
        //        {
        //            return "AAA";
        //        }
        //        else
        //        if (this.Contrast >= WCAGRequirement.RegularTextAA)
        //        {
        //            return "AA";
        //        }
        //        return "Fail";
        //    }
        //}

        //public string LargeTextRating
        //{
        //    get
        //    {
        //        if (this.Contrast >= WCAGRequirement.LargeTextAAA)
        //        {
        //            return "AAA";
        //        }
        //        else if (this.Contrast >= WCAGRequirement.LargeTextAA)
        //        {
        //            return "AA";
        //        }
        //        return "Fail";
        //    }
        //}

        //internal double CalculateContrast()
        //{
        //    return Cl.Colour.ContrastRatio(this.RGB, this.ColourGroup.BackgroundColour.RGB, out string ratio);

        //}

        //public double ContrastRatio(out string ratio)
        //{
        //    return Cl.Colour.ContrastRatio(this.RGB, this.ColourGroup.BackgroundColour.RGB, out ratio);
        //}
    }
}
