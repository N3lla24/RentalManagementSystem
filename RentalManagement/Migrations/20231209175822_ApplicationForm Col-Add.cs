using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class ApplicationFormColAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantForm",
                table: "ApplicantForm");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantForm_ApplicationId",
                table: "ApplicantForm");

            migrationBuilder.DropColumn(
                name: "ApplicationFormId",
                table: "ApplicantForm");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantForm",
                table: "ApplicantForm",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantForm",
                table: "ApplicantForm");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationFormId",
                table: "ApplicantForm",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantForm",
                table: "ApplicantForm",
                column: "ApplicationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantForm_ApplicationId",
                table: "ApplicantForm",
                column: "ApplicationId");
        }
    }
}
