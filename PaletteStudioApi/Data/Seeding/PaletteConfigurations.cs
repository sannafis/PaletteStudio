using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletteStudioApi.Models;
using PaletteStudioApi.Static;

namespace PaletteStudioApi.Data.Seeding
{
    public class PaletteConfiguration : IEntityTypeConfiguration<Palette>
    {
        public void Configure(EntityTypeBuilder<Palette> builder)
        {
            builder.HasData(
                new Palette { Id = 1, Name = "Palette 1", Privacy = PrivacySetting.Public, UserId = "354492fe-30eb-4261-b5b1-4a291cb4001d" },
                new Palette { Id = 2, Name = "Palette 2", UserId = "354492fe-30eb-4261-b5b1-4a291cb4001d" },
                new Palette { Id = 3, Name = "Palette 3", UserId = "354492fe-30eb-4261-b5b1-4a291cb4001d" }
            );
        }
    }

    public class ColourGroupConfiguration : IEntityTypeConfiguration<ColourGroup>
    {
        public void Configure(EntityTypeBuilder<ColourGroup> builder)
        {
            builder.HasData(
                new ColourGroup { Id = 1, BackgroundColourHexCode = "#FFFFFF", PaletteId = 1 },
                new ColourGroup { Id = 2, BackgroundColourHexCode = "#F3A505", PaletteId = 1 },
                new ColourGroup { Id = 3, BackgroundColourHexCode = "#F80000", PaletteId = 2 },
                new ColourGroup { Id = 4, BackgroundColourHexCode = "#000000", PaletteId = 3 },
                new ColourGroup { Id = 5, BackgroundColourHexCode = "#8B8C7A", PaletteId = 3 }
            );
        }
    }

    public class ForegroundColourConfiguration : IEntityTypeConfiguration<ForegroundColour>
    {
        public void Configure(EntityTypeBuilder<ForegroundColour> builder)
        {
            builder.HasData(
                new ForegroundColour { Id = 1, ColourHexCode = "#9B111E", ColourGroupId = 1 },
                new ForegroundColour { Id = 2, ColourHexCode = "#F80000", ColourGroupId = 1 },
                new ForegroundColour { Id = 3, ColourHexCode = "#8B8C7A", ColourGroupId = 1 },
                new ForegroundColour { Id = 4, ColourHexCode = "#4C9141", ColourGroupId = 1 },

                new ForegroundColour { Id = 5, ColourHexCode = "#B44C43", ColourGroupId = 3 },
                new ForegroundColour { Id = 6, ColourHexCode = "#000000", ColourGroupId = 3 },
                new ForegroundColour { Id = 7, ColourHexCode = "#F3A505", ColourGroupId = 3 },

                new ForegroundColour { Id = 8, ColourHexCode = "#3E5F8A", ColourGroupId = 4 },
                new ForegroundColour { Id = 9, ColourHexCode = "#F3A505", ColourGroupId = 4 },

                new ForegroundColour { Id = 10, ColourHexCode = "#9B111E", ColourGroupId = 5 }
                );
        }
    }
}
