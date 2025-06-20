using System;
using Microsoft.EntityFrameworkCore;
using VendorRegistration.API.Models;

namespace VendorRegistration.API.Data
{
    public class VendorDbContext : DbContext
    {
        public VendorDbContext(DbContextOptions<VendorDbContext> options) : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Enums stored as readable on the database
            modelBuilder.Entity<Vendor>().Property(v => v.businessType).HasConversion<string>();

            modelBuilder.Entity<Vendor>().Property(v => v.NumberOfEmployees).HasConversion<string>();

            modelBuilder.Entity<Vendor>().Property(v => v.Status).HasConversion<string>();
        }
   }

}


