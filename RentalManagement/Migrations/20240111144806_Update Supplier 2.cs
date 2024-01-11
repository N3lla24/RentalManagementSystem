using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class UpdateSupplier2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Suppliers_Remarks",
                table: "Supplier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Suppliers_Remarks",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
