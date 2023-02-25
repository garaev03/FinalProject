using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class v403 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSupplies_Vehicles_VehicleId",
                table: "VehicleSupplies");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSupplies_VehicleId",
                table: "VehicleSupplies");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehicleSupplies");

            migrationBuilder.AddColumn<bool>(
                name: "isBarter",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isCredit",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBarter",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "isCredit",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehicleSupplies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSupplies_VehicleId",
                table: "VehicleSupplies",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSupplies_Vehicles_VehicleId",
                table: "VehicleSupplies",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
