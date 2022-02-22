using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManegment.Infrastructure.EfCore.Migrations
{
    public partial class ThirdInitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarFunction",
                table: "VehicleCategories");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "VehicleCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CarFunction",
                table: "VehicleCategories",
                type: "float",
                maxLength: 25,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "VehicleCategories",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                defaultValue: "");
        }
    }
}
