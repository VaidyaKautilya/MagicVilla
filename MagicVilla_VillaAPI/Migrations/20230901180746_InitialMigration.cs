using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    SqFt = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aminity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Aminity", "DateCreated", "DateUpdated", "Details", "ImageUrl", "Name", "Occupation", "Rate", "SqFt" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 9, 1, 23, 37, 46, 638, DateTimeKind.Local).AddTicks(7193), new DateTime(2023, 9, 1, 23, 37, 46, 638, DateTimeKind.Local).AddTicks(7211), "This is a test roayal villa", "http://surl.li/kokus", "Royal Villa", 5, 200.0, 550 },
                    { 2, "", new DateTime(2023, 9, 1, 23, 37, 46, 638, DateTimeKind.Local).AddTicks(7213), new DateTime(2023, 9, 1, 23, 37, 46, 638, DateTimeKind.Local).AddTicks(7214), "This is a test roayal villa natural", "http://surl.li/kokvu", "Royal Villa 1", 3, 500.0, 750 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
