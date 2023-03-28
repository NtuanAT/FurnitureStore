﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(StoreDBContext))]
    [Migration("20230327150316_fixInStoreProductagain")]
    partial class fixInStoreProductagain
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<Guid?>("AdminStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid?>("StaffStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AccountID");

                    b.HasIndex("AdminStoreID")
                        .IsUnique()
                        .HasFilter("[AdminStoreID] IS NOT NULL");

                    b.HasIndex("StaffStoreID");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("DataLayer.Entities.InStoreProduct", b =>
                {
                    b.Property<Guid>("InStoreProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BelongTo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WareHouseID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InStoreProductID");

                    b.HasIndex("ProductID");

                    b.HasIndex("StoreID");

                    b.HasIndex("WareHouseID");

                    b.ToTable("inStoreProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("products");
                });

            modelBuilder.Entity("DataLayer.Entities.Store", b =>
                {
                    b.Property<Guid>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("StoreAdminAccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("StoreID");

                    b.ToTable("stores");
                });

            modelBuilder.Entity("DataLayer.Entities.Warehouse", b =>
                {
                    b.Property<Guid>("WareHouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminAccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WareHouseID");

                    b.HasIndex("AdminAccountID");

                    b.ToTable("wareHouses");
                });

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.HasOne("DataLayer.Entities.Store", "AdminStore")
                        .WithOne("StoreAdmin")
                        .HasForeignKey("DataLayer.Entities.Account", "AdminStoreID");

                    b.HasOne("DataLayer.Entities.Store", "StaffStore")
                        .WithMany("Staffs")
                        .HasForeignKey("StaffStoreID");

                    b.Navigation("AdminStore");

                    b.Navigation("StaffStore");
                });

            modelBuilder.Entity("DataLayer.Entities.InStoreProduct", b =>
                {
                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("InStoreProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Warehouse", null)
                        .WithMany("products")
                        .HasForeignKey("WareHouseID");

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DataLayer.Entities.Warehouse", b =>
                {
                    b.HasOne("DataLayer.Entities.Account", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Navigation("InStoreProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Store", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Staffs");

                    b.Navigation("StoreAdmin")
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.Warehouse", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
