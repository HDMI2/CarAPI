using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWebApi.Migrations
{
    public partial class Car_GUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IDNummer",
                table: "CarSet",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDNummer",
                table: "CarSet");
        }
    }
}
