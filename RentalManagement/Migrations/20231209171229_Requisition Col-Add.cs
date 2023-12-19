using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class RequisitionColAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Requistition_Deadline",
                table: "Requisition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requistition_Deadline",
                table: "Requisition");
        }
    }
}
