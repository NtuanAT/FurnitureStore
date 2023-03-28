using DataLayer.DataSeed;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StoreDBContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<InStoreProduct> inStoreProducts { get; set; }
        public DbSet<Store> stores { get; set; }
        public StoreDBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string connectionString = config.GetConnectionString("defaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InStoreProduct>()
                .HasOne(i => i.Product)
                .WithMany(p => p.InStoreProducts)
                .HasForeignKey(p => p.ProductID);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.InStoreProducts)
                .WithOne(i => i.Product);

            modelBuilder.Entity<Store>()
            .HasOne(s => s.StoreAdmin)
            .WithOne(a => a.AdminStore)
            .HasForeignKey<Account>(a => a.AdminStoreID);

            modelBuilder.Entity<Store>()
                .HasMany(s => s.Staffs)
                .WithOne(a => a.StaffStore)
                .HasForeignKey(a => a.StaffStoreID)
                .IsRequired(false);


            #region Seed Data
            modelBuilder.SeedAccount();
            modelBuilder.SeedStore();
            modelBuilder.SeedProduct();
            modelBuilder.SeedInStoreProduct();
            #endregion

        }
    }
}
