using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class AdditionalAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseOrder_ReceivedDate",
                table: "PurchaseOrder");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseOrder_Type",
                table: "PurchaseOrder",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Pay_RefrigeratorFee",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Pay_WashingFee",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseOrder_Type",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "Pay_RefrigeratorFee",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "Pay_WashingFee",
                table: "PaymentDetail");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseOrder_ReceivedDate",
                table: "PurchaseOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
