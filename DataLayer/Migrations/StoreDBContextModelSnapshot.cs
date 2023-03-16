﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(StoreDBContext))]
    partial class StoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid?>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AccountID");

                    b.HasIndex("StoreID");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("DataLayer.Entities.InStoreProduct", b =>
                {
                    b.Property<Guid>("InStoreProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("InStoreProductID");

                    b.HasIndex("ProductID");

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

                    b.HasIndex("StoreAdminAccountID");

                    b.ToTable("stores");
                });

            modelBuilder.Entity("DataLayer.Entities.Account", b =>
                {
                    b.HasOne("DataLayer.Entities.Store", null)
                        .WithMany("Staffs")
                        .HasForeignKey("StoreID");
                });

            modelBuilder.Entity("DataLayer.Entities.InStoreProduct", b =>
                {
                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("InStoreProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataLayer.Entities.Store", b =>
                {
                    b.HasOne("DataLayer.Entities.Account", "StoreAdmin")
                        .WithMany()
                        .HasForeignKey("StoreAdminAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreAdmin");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Navigation("InStoreProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Store", b =>
                {
                    b.Navigation("Staffs");
                });
#pragma warning restore 612, 618
        }
    }
}
