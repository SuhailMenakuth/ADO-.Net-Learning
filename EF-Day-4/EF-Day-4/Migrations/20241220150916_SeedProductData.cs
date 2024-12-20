using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Day_4.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ManufactureDate", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 20, 20, 39, 15, 68, DateTimeKind.Local).AddTicks(9093), "Laptop", 999.99m },
                    { 2, new DateTime(2024, 6, 20, 20, 39, 15, 70, DateTimeKind.Local).AddTicks(2932), "Smartphone", 699.99m },
                    { 3, new DateTime(2024, 10, 20, 20, 39, 15, 70, DateTimeKind.Local).AddTicks(2950), "Headphones", 199.99m },
                    { 4, new DateTime(2023, 12, 20, 20, 39, 15, 70, DateTimeKind.Local).AddTicks(2952), "Keyboard", 49.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
