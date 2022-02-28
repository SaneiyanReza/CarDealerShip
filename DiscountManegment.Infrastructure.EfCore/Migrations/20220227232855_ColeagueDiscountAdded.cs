using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountManegment.Infrastructure.EfCore.Migrations
{
    public partial class ColeagueDiscountAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerDiscount",
                table: "CustomerDiscount");

            migrationBuilder.RenameTable(
                name: "CustomerDiscount",
                newName: "CustomerDiscounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerDiscounts",
                table: "CustomerDiscounts",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ColleagueDiscounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<double>(type: "float", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColleagueDiscounts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColleagueDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerDiscounts",
                table: "CustomerDiscounts");

            migrationBuilder.RenameTable(
                name: "CustomerDiscounts",
                newName: "CustomerDiscount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerDiscount",
                table: "CustomerDiscount",
                column: "ID");
        }
    }
}
