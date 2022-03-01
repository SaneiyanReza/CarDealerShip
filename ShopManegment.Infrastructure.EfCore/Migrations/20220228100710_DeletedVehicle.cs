using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManegment.Infrastructure.EfCore.Migrations
{
    public partial class DeletedVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleCategories_CategoryID",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePictures_Vehicle_VehicleID",
                table: "VehiclePictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_CategoryID",
                table: "Vehicles",
                newName: "IX_Vehicles_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePictures_Vehicles_VehicleID",
                table: "VehiclePictures",
                column: "VehicleID",
                principalTable: "Vehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleCategories_CategoryID",
                table: "Vehicles",
                column: "CategoryID",
                principalTable: "VehicleCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePictures_Vehicles_VehicleID",
                table: "VehiclePictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleCategories_CategoryID",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CategoryID",
                table: "Vehicle",
                newName: "IX_Vehicle_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleCategories_CategoryID",
                table: "Vehicle",
                column: "CategoryID",
                principalTable: "VehicleCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePictures_Vehicle_VehicleID",
                table: "VehiclePictures",
                column: "VehicleID",
                principalTable: "Vehicle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
