using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Models.Data;

namespace WebApp.DAL
{
    public partial class ProductManagerDbContext : DbContext, IProductManagerDbContex
    {
        public ProductManagerDbContext() { }
        public ProductManagerDbContext(DbContextOptions<ProductManagerDbContext> options) : base(options) { }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProductManager;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime2(7)");
                entity.Property(e => e.LastUpdated).HasColumnType("datetime2(7)");

                entity.Property(e => e.Price).HasColumnType("decimal(5,2)");

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(200);

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
