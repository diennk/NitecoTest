using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NitecoTestApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NitecoTestApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .ToTable("Category")
                .HasMany(c => c.Products)
                .WithOne(e => e.Category);

            modelBuilder.Entity<Product>()
                .ToTable("Product")
                .HasOne(e => e.Category)
                .WithMany(c => c.Products);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithOne(c => c.Product);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .HasMany(c => c.Orders)
                .WithOne(e => e.Customer);

            modelBuilder.Entity<Order>()
                .ToTable("Order")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.Customer)
                .WithMany(c => c.Orders);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.Product)
                .WithMany(c => c.Orders);


            base.OnModelCreating(modelBuilder);
        }
    }
}
