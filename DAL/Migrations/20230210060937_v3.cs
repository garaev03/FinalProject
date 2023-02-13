using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Cities_CityId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleConditions_HuId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BarterAvailable",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "inCredit",
                table: "Vehicles",
                newName: "isVip");

            migrationBuilder.RenameColumn(
                name: "HuId",
                table: "Vehicles",
                newName: "VehicleConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_HuId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleConditionId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Cities_CityId",
                table: "Vehicles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleConditions_VehicleConditionId",
                table: "Vehicles",
                column: "VehicleConditionId",
                principalTable: "VehicleConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Cities_CityId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleConditions_VehicleConditionId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "isVip",
                table: "Vehicles",
                newName: "inCredit");

            migrationBuilder.RenameColumn(
                name: "VehicleConditionId",
                table: "Vehicles",
                newName: "HuId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleConditionId",
                table: "Vehicles",
                newName: "IX_Vehicles_HuId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "BarterAvailable",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Cities_CityId",
                table: "Vehicles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleConditions_HuId",
                table: "Vehicles",
                column: "HuId",
                principalTable: "VehicleConditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
