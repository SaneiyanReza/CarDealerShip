using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManegment.Infrastructure.EfCore.Migrations
{
    public partial class EditColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "VehiclePictures",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "VehicleCategories",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Slides",
                newName: "IsRemoved");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "VehiclePictures",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "VehicleCategories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Slides",
                newName: "IsDeleted");
        }
    }
}
