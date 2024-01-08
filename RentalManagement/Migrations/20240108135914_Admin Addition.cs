using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class AdminAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requisition_StatusRemarks",
                table: "Requisition");

            migrationBuilder.AddColumn<string>(
                name: "Admin_Email",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Admin_PhoneNumber",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin_Email",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Admin_PhoneNumber",
                table: "Admin");

            migrationBuilder.AddColumn<string>(
                name: "Requisition_StatusRemarks",
                table: "Requisition",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);
        }
    }
}
