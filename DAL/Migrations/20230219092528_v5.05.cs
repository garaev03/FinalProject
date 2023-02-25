using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class v505 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Vehicles",
                newName: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PhoneNumberId",
                table: "Vehicles",
                column: "PhoneNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_PhoneNumbers_PhoneNumberId",
                table: "Vehicles",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_PhoneNumbers_PhoneNumberId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_PhoneNumberId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberId",
                table: "Vehicles",
                newName: "PhoneNumber");
        }
    }
}
