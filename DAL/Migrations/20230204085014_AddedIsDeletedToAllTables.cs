using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddedIsDeletedToAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Years",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "VehicleSupplies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "VehicleReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "VehicleImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Statuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Seats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "OwnerCounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Models",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "MileageTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Makes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "HUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "GearBoxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Fuels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "EngineCapacities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "DriveTrains",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Currencies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Colors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Bans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Years");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "VehicleSupplies");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "VehicleReports");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "VehicleImages");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "OwnerCounts");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "MileageTypes");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Makes");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "HUs");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "GearBoxes");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Fuels");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "EngineCapacities");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "DriveTrains");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Bans");
        }
    }
}
