using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TinyCrm.Core.Model;


namespace TinyCrm.Core.Data
{
    public class TinyCrmDbContext : DbContext
    {
        private readonly string connectionString_;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Product>()
                .ToTable("Product");
            modelBuilder
               .Entity<Customer>()
               .ToTable("Customer");
            modelBuilder
              .Entity<Order>()
              .ToTable("Order");
            modelBuilder
              .Entity<ContactPerson>()
              .ToTable("Contact");
           
            //modelBuilder
            //    .Entity<Product>()
            //    .Property(p => p.Discount)
            //    .HasMaxLength(50);
        }
        public TinyCrmDbContext() : base()
        {
            connectionString_= "Server=localhost;Database =tinycrm;User Id = sa;Password = QWE123!@#";
        }
        public TinyCrmDbContext(string connString)
        {
            connectionString_ = connString;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString_);
        }

    }
}
