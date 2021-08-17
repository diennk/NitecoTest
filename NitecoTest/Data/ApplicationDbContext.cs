using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NitecoTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NitecoTest.Data
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
                .ToTable("Category");

            modelBuilder.Entity<Product>()
                .ToTable("Product");

            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Order>()
                .ToTable("Order");

            base.OnModelCreating(modelBuilder);
        }
    }
}
