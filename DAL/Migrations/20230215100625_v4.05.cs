using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class v405 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleConditions_VehicleConditionId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleConditionId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleConditionId",
                table: "Vehicles");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "VehicleConditionId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleConditionId",
                table: "Vehicles",
                column: "VehicleConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleConditions_VehicleConditionId",
                table: "Vehicles",
                column: "VehicleConditionId",
                principalTable: "VehicleConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
