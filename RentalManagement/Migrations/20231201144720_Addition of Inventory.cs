using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class AdditionofInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inventory_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inventory_Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory_Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Supplier_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
