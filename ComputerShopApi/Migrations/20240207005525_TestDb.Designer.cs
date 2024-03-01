﻿// <auto-generated />
using System;
using ComputerShopApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ComputerShopApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240207005525_TestDb")]
    partial class TestDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ComputerShopApi.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("ComputerShopApi.Models.BranchProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BranchId")
                        .IsUnique();

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("BranchProducts");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("TypeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ComputerShopApi.Models.DeviceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DeviceId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("DeviceInfo");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Photo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("ComputerShopApi.Models.SetProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("SetProducts");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("DeviceSetProduct", b =>
                {
                    b.Property<int>("DevicesId")
                        .HasColumnType("integer");

                    b.Property<int>("SetProductsId")
                        .HasColumnType("integer");

                    b.HasKey("DevicesId", "SetProductsId");

                    b.HasIndex("SetProductsId");

                    b.ToTable("DeviceSetProduct");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Branch", b =>
                {
                    b.HasOne("ComputerShopApi.Models.Company", "Company")
                        .WithMany("Branch")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ComputerShopApi.Models.BranchProductModel", b =>
                {
                    b.HasOne("ComputerShopApi.Models.Branch", "Branch")
                        .WithOne()
                        .HasForeignKey("ComputerShopApi.Models.BranchProductModel", "BranchId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ComputerShopApi.Models.Product", "Product")
                        .WithOne()
                        .HasForeignKey("ComputerShopApi.Models.BranchProductModel", "ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Device", b =>
                {
                    b.HasOne("ComputerShopApi.Models.Product", "Product")
                        .WithOne("Device")
                        .HasForeignKey("ComputerShopApi.Models.Device", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerShopApi.Models.Type", "Type")
                        .WithMany("Devices")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ComputerShopApi.Models.DeviceInfo", b =>
                {
                    b.HasOne("ComputerShopApi.Models.Device", "Device")
                        .WithMany("Info")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Sales", b =>
                {
                    b.HasOne("ComputerShopApi.Models.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ComputerShopApi.Models.SetProduct", b =>
                {
                    b.HasOne("ComputerShopApi.Models.Product", "Product")
                        .WithOne("SetProduct")
                        .HasForeignKey("ComputerShopApi.Models.SetProduct", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DeviceSetProduct", b =>
                {
                    b.HasOne("ComputerShopApi.Models.Device", null)
                        .WithMany()
                        .HasForeignKey("DevicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerShopApi.Models.SetProduct", null)
                        .WithMany()
                        .HasForeignKey("SetProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerShopApi.Models.Company", b =>
                {
                    b.Navigation("Branch");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Device", b =>
                {
                    b.Navigation("Info");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Product", b =>
                {
                    b.Navigation("Device")
                        .IsRequired();

                    b.Navigation("Sales");

                    b.Navigation("SetProduct")
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerShopApi.Models.Type", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
