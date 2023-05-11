using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Authentication;

namespace PaletteStudioApi.Data.Seeding
{
    public class AccountConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            builder.HasData(
            new User
            {
                Id = "dc3fbe21-8f2a-4ac3-9516-91957919b028",
                Email = "admin@palettestudio.ca",
                NormalizedEmail = "ADMIN@PALETTESTUDIO.CA",
                EmailConfirmed = true,
                UserName = "admin@palettestudio.ca",
                NormalizedUserName = "ADMIN@PALETTESTUDIO.CA",
                FirstName = "Palette Studio",
                LastName = "Admin",
                Nickname = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd")
            },
            new User
            {
                Id = "354492fe-30eb-4261-b5b1-4a291cb4001d",
                Email = "user@palettestudio.ca",
                NormalizedEmail = "USER@PALETTESTUDIO.CA",
                EmailConfirmed = true,
                UserName = "user@palettestudio.ca",
                NormalizedUserName = "USER@PALETTESTUDIO.CA",
                FirstName = "Palette Studio",
                LastName = "User",
                Nickname = "Test User",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd")
            });
        }
    }
}
