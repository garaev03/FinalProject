using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class v506 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MonthlyCreateDate",
                table: "PhoneNumbers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MonthlyExpireDate",
                table: "PhoneNumbers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyCreateDate",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "MonthlyExpireDate",
                table: "PhoneNumbers");
        }
    }
}
