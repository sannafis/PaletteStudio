using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletteStudioApi.Models.Authentication;

namespace PaletteStudioApi.Data.Seeding
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {

            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "608616ab-2cb2-4823-9021-b11452f80986",
                    UserId = "354492fe-30eb-4261-b5b1-4a291cb4001d"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "0e97e6f5-e05f-43fd-b33f-bdb6ff465658",
                    UserId = "dc3fbe21-8f2a-4ac3-9516-91957919b028"
                }
                );
        }
    }
}
