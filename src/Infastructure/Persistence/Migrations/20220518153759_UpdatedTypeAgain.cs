using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Persistence.Migrations
{
    public partial class UpdatedTypeAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "Events",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
