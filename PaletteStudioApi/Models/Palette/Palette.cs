using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaletteStudioApi.Models
{
    [ModelMetadataType(typeof(PaletteMetaData))]
    public class Palette
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<ColourGroup> ColourGroups { get; set; } = new HashSet<ColourGroup>();


    }
}
