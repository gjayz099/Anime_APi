using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using anime_api.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace anime_api.db
{
    public class DBAppContex : IdentityDbContext
    {
        public DBAppContex(DbContextOptions<DBAppContex> options) : base(options)
        {

        }

        public DbSet<Anime> Animes {get; set;}
        public DbSet<Image> Images {get; set;}
        public DbSet<Contry> Contries {get; set;}
        public DbSet<Status> Statuses {get; set;}
        public DbSet<Genre> Genres {get; set;}
        public DbSet<Typed> typeds {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>()
                .HasOne(e => e.Image)
                .WithOne(e => e.Anime)
                .HasForeignKey<Image>(e => e.Anime_id)
                .IsRequired();

            modelBuilder.Entity<Anime>()
                .HasOne(e => e.Typed)
                .WithOne(e => e.Anime)
                .HasForeignKey<Typed>(e => e.Anime_id)
                .IsRequired();

            modelBuilder.Entity<Anime>()
                .HasOne(e => e.Contry)
                .WithOne(e => e.Anime)
                .HasForeignKey<Contry>(e => e.Anime_id)
                .IsRequired();

            modelBuilder.Entity<Anime>()
                .HasOne(e => e.Status)
                .WithOne(e => e.Anime)
                .HasForeignKey<Status>(e => e.Anime_id)
                .IsRequired();


            modelBuilder.Entity<Anime>()
                .HasMany(e => e.Genre)
                .WithOne(e => e.Anime)
                .HasForeignKey(e => e.Anime_id)
                .IsRequired();

            base.OnModelCreating(modelBuilder);

            // Define primary key for IdentityUserLogin<string>
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            
        }

    }
}