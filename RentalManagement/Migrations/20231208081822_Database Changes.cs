using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class DatabaseChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inventory_Name",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Inventory_Quantity",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Supplier_CreatedAt",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "Tenant_Name",
                table: "Tenant",
                newName: "Tenant_LastName");

            migrationBuilder.RenameColumn(
                name: "Supplier_UpdatedAt",
                table: "Inventory",
                newName: "Inventory_CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Inventory_Unit",
                table: "Inventory",
                newName: "Inventory_ItemName");

            migrationBuilder.RenameColumn(
                name: "Applicants_Name",
                table: "Applicants",
                newName: "Applicants_LastName");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tenant_RentPaid",
                table: "Tenant",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Tenant_FirstName",
                table: "Tenant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tenant_MiddleName",
                table: "Tenant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Requistition_Quantity",
                table: "RequisitionItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Requistition_Type",
                table: "RequisitionItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Requistition_Remarks",
                table: "Requisition",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RM_Remarks",
                table: "ReceivingMemo",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Purchase_Quantity",
                table: "PurchaseItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Purchase_Type",
                table: "PurchaseItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Inventory_ItemQuantity",
                table: "Inventory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Inventory_ItemUnit",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Inventory_UpdatedAt",
                table: "Inventory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Feedback_UpdatedAt",
                table: "Feedback",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Feedback_CreatedAt",
                table: "Feedback",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback_Content",
                table: "Feedback",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FAQ_Content",
                table: "FAQ",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Applicant_UpdatedAt",
                table: "Applicants",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Applicants_FirstName",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Applicants_MiddleName",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tenant_FirstName",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "Tenant_MiddleName",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "Requistition_Type",
                table: "RequisitionItem");

            migrationBuilder.DropColumn(
                name: "Purchase_Type",
                table: "PurchaseItem");

            migrationBuilder.DropColumn(
                name: "Inventory_ItemQuantity",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Inventory_ItemUnit",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Inventory_UpdatedAt",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Applicants_FirstName",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Applicants_MiddleName",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "Tenant_LastName",
                table: "Tenant",
                newName: "Tenant_Name");

            migrationBuilder.RenameColumn(
                name: "Inventory_ItemName",
                table: "Inventory",
                newName: "Inventory_Unit");

            migrationBuilder.RenameColumn(
                name: "Inventory_CreatedAt",
                table: "Inventory",
                newName: "Supplier_UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Applicants_LastName",
                table: "Applicants",
                newName: "Applicants_Name");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tenant_RentPaid",
                table: "Tenant",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Requistition_Quantity",
                table: "RequisitionItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Requistition_Remarks",
                table: "Requisition",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "RM_Remarks",
                table: "ReceivingMemo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<decimal>(
                name: "Purchase_Quantity",
                table: "PurchaseItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Inventory_Name",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Inventory_Quantity",
                table: "Inventory",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Supplier_CreatedAt",
                table: "Inventory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Feedback_UpdatedAt",
                table: "Feedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Feedback_CreatedAt",
                table: "Feedback",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Feedback_Content",
                table: "Feedback",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FAQ_Content",
                table: "FAQ",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Applicant_UpdatedAt",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
