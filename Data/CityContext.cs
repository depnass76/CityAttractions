using CityAttractions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityAttractions.Data
{
    public class CityContext:DbContext
    {
        private readonly IConfiguration _config;

        public CityContext(IConfiguration config)
        {
            this._config = config;
        }
        public DbSet<Result> result { get; set; }

        public DbSet<Root> root { get; set; }

        public DbSet<Image> image { get; set; }

        public DbSet<Thumbnail> thumbnail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:CitiesContextDb"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Result>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Result>().Property(p => p.rId).ValueGeneratedOnAdd();


            modelBuilder.Entity<Root>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Root>().Property(p => p.rId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Attribution>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Attribution>().Property(p => p.rId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Coordinates>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Coordinates>().Property(p => p.rId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Image>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Image>().Property(p => p.rId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Medium>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Medium>().Property(p => p.rId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Original>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Original>().Property(p => p.rId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Sizes>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Sizes>().Property(p => p.rId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Thumbnail>().HasKey(p => new { p.rId });
            modelBuilder.Entity<Thumbnail>().Property(p => p.rId).ValueGeneratedOnAdd();




            //modelBuilder.Entity<Coordinates>().HasNoKey();
            //modelBuilder.Entity<Root>().HasNoKey();

            //modelBuilder.Entity<Thumbnail>().HasNoKey();



            //modelBuilder.Entity<Image>().HasNoKey();

            //modelBuilder.Entity<Attribution>().HasNoKey();
            //modelBuilder.Entity<Sizes>().HasNoKey();
            //modelBuilder.Entity<Original>().HasNoKey();
            //modelBuilder.Entity<Medium>().HasNoKey();


            //modelBuilder.Ignore<Sizes>();
            //modelBuilder.Ignore<Coordinates>();
            //modelBuilder.Ignore<Attribution>();


        }
    }
}
