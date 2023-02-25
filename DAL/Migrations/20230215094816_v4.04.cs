using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class v404 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleReports_Vehicles_VehicleId",
                table: "VehicleReports");

            migrationBuilder.DropIndex(
                name: "IX_VehicleReports_VehicleId",
                table: "VehicleReports");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehicleReports");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehicleReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleReports_VehicleId",
                table: "VehicleReports",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleReports_Vehicles_VehicleId",
                table: "VehicleReports",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
