using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class AdditionalPrimaryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suppliers_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suppliers_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suppliers_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suppliers_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Supplier_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SuppliersId);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenant_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Tenant_UnitNumber = table.Column<int>(type: "int", nullable: false),
                    Tenant_RentTot = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tenant_RentPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tenant_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tenant_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
