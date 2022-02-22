using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManegment.Infrastructure.EfCore.Migrations
{
    public partial class VehicleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CarFunction = table.Column<double>(type: "float", maxLength: 25, nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Keyword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "VehicleCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CategoryID",
                table: "Vehicle",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
