using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PortfolioApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApp.Database
{
    public class PortfolioDb : IdentityDbContext<PortfolioUser>
    {

        public PortfolioDb(DbContextOptions<PortfolioDb> options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Status>().HasData(

                new Status() { Id = 1, Description = "Afgewerkt" },
                new Status() { Id = 2, Description = "Huidig" },
                new Status() { Id = 3, Description = "Toekomstig" }
                );

            modelBuilder.Entity<Tag>().HasData(

                new Tag() { Id = 1, Description = "C#" },
                new Tag() { Id = 2, Description = "JavaScript" },
                new Tag() { Id = 3, Description = "CSS" },
                new Tag() { Id = 4, Description = "CONCEPT ART" },
                new Tag() { Id = 5, Description = "ANIMATION" },
                new Tag() { Id = 6, Description = "PIXEL ART" },
                new Tag() { Id = 7, Description = "3D" }
                );

            modelBuilder.Entity<PortfolioTag>().HasKey(pt => new { pt.TagId, pt.PortfolioId });

            modelBuilder.Entity<PortfolioTag>()

                .HasOne(pt => pt.Portfolio)
                .WithMany(p => p.PortfolioTags)
                .HasForeignKey(pt => pt.PortfolioId);


            modelBuilder.Entity<PortfolioTag>()

                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PortfolioTags)
                .HasForeignKey(pt => pt.TagId);

        }

        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PortfolioTag> PortfolioTags { get; set; }
    }






}
