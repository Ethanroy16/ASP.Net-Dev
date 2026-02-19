using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RP1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class num1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    FoundedYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GolfBalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolfBalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GolfBalls_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName", "Country", "FoundedYear" },
                values: new object[,]
                {
                    { 1, "Titleist", "USA", 1932 },
                    { 2, "Callaway", "USA", 1982 },
                    { 3, "TaylorMade", "USA", 1979 },
                    { 4, "Ping", "USA", 1959 },
                    { 5, "Srixon", "Japan", 1996 }
                });

            migrationBuilder.InsertData(
                table: "GolfBalls",
                columns: new[] { "Id", "BrandId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Premium tour-level performance with soft feel and long distance.", null, "Pro V1", 54.99f },
                    { 2, 3, "5-layer tour ball delivering speed and spin control.", null, "TP5", 52.99f },
                    { 3, 5, "Tour performance ball with exceptional greenside spin.", null, "Z-Star", 49.99f },
                    { 4, 2, "Soft feel with high ball speeds and excellent control.", null, "Chrome Soft", 50.99f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GolfBalls_BrandId",
                table: "GolfBalls",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GolfBalls");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
