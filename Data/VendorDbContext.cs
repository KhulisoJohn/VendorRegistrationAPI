using System;
using Microsoft.EntityFrameworkCore;
using VendorRegistrationAPI.Models;

namespace VendorRegistrationAPI.Data
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
            modelBuilder.Entity<Vendor>().Property(static v => v.businessType).HasConversion<string>();

            modelBuilder.Entity<Vendor>().Property(static v => v.NumberOfEmployees).HasConversion<string>();

            modelBuilder.Entity<Vendor>().Property(static v => v.Status).HasConversion<string>();
        }
   }

}


