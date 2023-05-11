using ColourLibrary;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Cl = ColourLibrary;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(ColourMetaData))]
    public class Colour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string HexCode { get; set; } = string.Empty;

        public virtual ICollection<ColourGroup> ColourGroups { get; set; } = new HashSet<ColourGroup>();

        public virtual ICollection<ForegroundColour> ForegroundColours { get; set; } = new HashSet<ForegroundColour>();

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
