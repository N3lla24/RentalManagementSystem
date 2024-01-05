using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class RequisitionAttributesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseService_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseService");

            migrationBuilder.DropColumn(
                name: "Req_Serv_DueDate",
                table: "RequisitionService");

            migrationBuilder.DropColumn(
                name: "Req_Serv_Remarks",
                table: "RequisitionService");

            migrationBuilder.DropColumn(
                name: "Req_Item_DueDate",
                table: "RequisitionItem");

            migrationBuilder.DropColumn(
                name: "Req_Item_Remarks",
                table: "RequisitionItem");

            migrationBuilder.AddColumn<DateTime>(
                name: "Requisition_DueDate",
                table: "Requisition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Requisition_Status_Remarks",
                table: "Requisition",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderId",
                table: "PurchaseService",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderId",
                table: "PurchaseItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseItem",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseService_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseService",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "PurchaseOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseService_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseService");

            migrationBuilder.DropColumn(
                name: "Requisition_DueDate",
                table: "Requisition");

            migrationBuilder.DropColumn(
                name: "Requisition_Status_Remarks",
                table: "Requisition");

            migrationBuilder.AddColumn<DateTime>(
                name: "Req_Serv_DueDate",
                table: "RequisitionService",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Req_Serv_Remarks",
                table: "RequisitionService",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Req_Item_DueDate",
                table: "RequisitionItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Req_Item_Remarks",
                table: "RequisitionItem",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderId",
                table: "PurchaseService",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderId",
                table: "PurchaseItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseItem",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseService_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseService",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
