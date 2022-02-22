using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManegment.Infrastructure.EfCore.Migrations
{
    public partial class SecondInitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CarFunction",
                table: "VehicleCategories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarFunction",
                table: "VehicleCategories");
        }
    }
}
