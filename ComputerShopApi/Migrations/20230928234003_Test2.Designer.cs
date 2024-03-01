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
    [Migration("20230928234003_Test2")]
    partial class Test2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ComputerShopApi.Models.Info", b =>
                {
                    b.Property<string>("Author")
                        .HasColumnType("text")
                        .HasColumnName("Author");

                    b.Property<string>("AuthorId")
                        .HasColumnType("text");

                    b.Property<string>("Author2")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Author");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Author", "AuthorId");

                    b.ToTable("Info");
                });

            modelBuilder.Entity("ComputerShopApi.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Photo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ComputerShopApi.Models.SetProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Photo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SetProducts");
                });

            modelBuilder.Entity("ProductsSetProducts", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.Property<int>("SetProductsId")
                        .HasColumnType("integer");

                    b.HasKey("ProductsId", "SetProductsId");

                    b.HasIndex("SetProductsId");

                    b.ToTable("ProductsSetProducts");
                });

            modelBuilder.Entity("ProductsSetProducts", b =>
                {
                    b.HasOne("ComputerShopApi.Models.Products", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerShopApi.Models.SetProducts", null)
                        .WithMany()
                        .HasForeignKey("SetProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
