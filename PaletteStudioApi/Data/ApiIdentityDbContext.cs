using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Models;
using System.Numerics;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PaletteStudioApi.Models.Authentication;
using PaletteStudioApi.Data.Seeding;

namespace PaletteStudioApi.Data
{
    public class ApiIdentityDbContext : IdentityDbContext<User>
    {

        public ApiIdentityDbContext(DbContextOptions<ApiIdentityDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<RefreshToken>().HasNoKey();

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            var hasher = new PasswordHasher<Models.Authentication.User>();

            modelBuilder.Entity<User>().HasData(
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
                }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
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

            //modelBuilder.Entity<User>()
            //.HasOne<RefreshToken>(s => s.RefreshToken)
            //.WithOne(ad => ad.User)
            //.HasForeignKey<RefreshToken>(r=>r.UserId);

        }
    }


}
