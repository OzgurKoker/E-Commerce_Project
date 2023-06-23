using ETicaretApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ETicaretApp.DAL
{
    public class ETicaretAppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryProperty> CategoryProperties { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=ETicaretApp;TrustServerCertificate=true;Trusted_Connection=true");
            }   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AppDbInitializer.SeedData(modelBuilder);
        }


    }
}
