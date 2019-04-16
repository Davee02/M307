using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace M307_Project.Migrations
{
    public partial class AddDateTimeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RepairStartDateTime",
                table: "RepairOrders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairStartDateTime",
                table: "RepairOrders");
        }
    }
}
