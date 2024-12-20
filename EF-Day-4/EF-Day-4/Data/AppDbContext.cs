using Microsoft.EntityFrameworkCore;
using EF_Day_4.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EF_Day_4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Price column to have a precision of 18 and scale of 2
           
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            // Or use HasPrecision(18, 2)

            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, Name = "Laptop", Price = 999.99m, ManufactureDate = DateTime.Now.AddMonths(-3) },
               new Product { Id = 2, Name = "Smartphone", Price = 699.99m, ManufactureDate = DateTime.Now.AddMonths(-6) },
               new Product { Id = 3, Name = "Headphones", Price = 199.99m, ManufactureDate = DateTime.Now.AddMonths(-2) },
               new Product { Id = 4, Name = "Keyboard", Price = 49.99m, ManufactureDate = DateTime.Now.AddMonths(-12) }
           );
        }
    }
}
