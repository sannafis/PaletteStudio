using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletteStudioApi.Models;

namespace PaletteStudioApi.Data.Seeding
{
    public class ColoursConfiguration : IEntityTypeConfiguration<Colour>
    {
        public void Configure(EntityTypeBuilder<Colour> builder)
        {
            builder.HasData(
              new Colour { HexCode = "#000000" },
              new Colour { HexCode = "#FFFFFF" },
              new Colour { HexCode = "#9B111E" },
              new Colour { HexCode = "#89AC76" },
              new Colour { HexCode = "#F3A505" },
              new Colour { HexCode = "#5D9B9B" },
              new Colour { HexCode = "#4C9141" },
              new Colour { HexCode = "#B44C43" },
              new Colour { HexCode = "#3E5F8A" },
              new Colour { HexCode = "#F80000" },
              new Colour { HexCode = "#8B8C7A" }
              );
        }
    }
}
