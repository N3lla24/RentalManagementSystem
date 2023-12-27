using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class PaymentUti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pay_ElectricityFee",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "Pay_GasFee",
                table: "PaymentDetail");

            migrationBuilder.DropColumn(
                name: "Pay_TapwaterFee",
                table: "PaymentDetail");

            migrationBuilder.RenameColumn(
                name: "Pay_WaterFee",
                table: "PaymentDetail",
                newName: "Pay_UtilityFee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pay_UtilityFee",
                table: "PaymentDetail",
                newName: "Pay_WaterFee");

            migrationBuilder.AddColumn<decimal>(
                name: "Pay_ElectricityFee",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Pay_GasFee",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Pay_TapwaterFee",
                table: "PaymentDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
