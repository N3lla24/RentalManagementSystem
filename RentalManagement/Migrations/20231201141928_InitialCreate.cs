using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applicants_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applicants_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applicants_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applicants_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applicant_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Applicant_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
