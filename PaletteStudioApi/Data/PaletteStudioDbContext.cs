using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Models;
using System.Numerics;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PaletteStudioApi.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using PaletteStudioApi.Data.Seeding;

namespace PaletteStudioApi.Data
{
    public class PaletteStudioDbContext : IdentityDbContext<User>
    {

        public PaletteStudioDbContext(DbContextOptions<PaletteStudioDbContext> options)
           : base(options)
        {
        }

        public DbSet<Palette> Palettes { get; set; } 
        public DbSet<Colour> Colours { get; set; }
        public DbSet<ColourGroup> ColourGroups { get; set; }
        public DbSet<ForegroundColour> ForegroundColours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasMany(u => u.Palettes)
            .WithOne(p => p.User)
            .HasForeignKey(r => r.UserId);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleConfiguration());

            modelBuilder.Entity<Colour>().HasKey(c => c.HexCode);

            modelBuilder.Entity<Palette>()
             .HasMany(p => p.ColourGroups)
             .WithOne(cg => cg.Palette)
             .HasForeignKey(cg => cg.PaletteId);

            modelBuilder.Entity<ColourGroup>()
             .HasMany(cg => cg.ForegroundColours)
             .WithOne(f => f.ColourGroup)
             .HasForeignKey(f => f.ColourGroupId);

            modelBuilder.Entity<Colour>()
                .HasMany(c => c.ColourGroups)
                .WithOne(cg => cg.BackgroundColour)
                .HasForeignKey(cg => cg.BackgroundColourHexCode);
            
            modelBuilder.Entity<Colour>()
                .HasMany(c => c.ForegroundColours)
                .WithOne(f => f.Colour)
                .HasForeignKey(f => f.ColourHexCode);


            modelBuilder.ApplyConfiguration(new ColoursConfiguration());
            modelBuilder.ApplyConfiguration(new PaletteConfiguration());
            modelBuilder.ApplyConfiguration(new ColourGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ForegroundColourConfiguration());
        }
    }
}
