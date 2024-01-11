using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class RoomAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Room_Appliance",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Room_Color",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Room_Flooring",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Room_Furnish",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Room_Size",
                table: "Room",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Room_WiFi",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Room_Appliance",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Room_Color",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Room_Flooring",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Room_Furnish",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Room_Size",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Room_WiFi",
                table: "Room");
        }
    }
}
