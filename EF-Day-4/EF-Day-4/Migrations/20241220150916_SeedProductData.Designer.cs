﻿// <auto-generated />
using System;
using EF_Day_4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Day_4.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241220150916_SeedProductData")]
    partial class SeedProductData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Day_4.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManufactureDate = new DateTime(2024, 9, 20, 20, 39, 15, 68, DateTimeKind.Local).AddTicks(9093),
                            Name = "Laptop",
                            Price = 999.99m
                        },
                        new
                        {
                            Id = 2,
                            ManufactureDate = new DateTime(2024, 6, 20, 20, 39, 15, 70, DateTimeKind.Local).AddTicks(2932),
                            Name = "Smartphone",
                            Price = 699.99m
                        },
                        new
                        {
                            Id = 3,
                            ManufactureDate = new DateTime(2024, 10, 20, 20, 39, 15, 70, DateTimeKind.Local).AddTicks(2950),
                            Name = "Headphones",
                            Price = 199.99m
                        },
                        new
                        {
                            Id = 4,
                            ManufactureDate = new DateTime(2023, 12, 20, 20, 39, 15, 70, DateTimeKind.Local).AddTicks(2952),
                            Name = "Keyboard",
                            Price = 49.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}