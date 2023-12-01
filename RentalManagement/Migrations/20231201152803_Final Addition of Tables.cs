using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class FinalAdditionofTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantForm",
                columns: table => new
                {
                    ApplicationFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Application_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Application_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantForm", x => x.ApplicationFormId);
                    table.ForeignKey(
                        name: "FK_ApplicantForm_Applicants_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    FAQId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAQ_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAQ_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAQ_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.FAQId);
                    table.ForeignKey(
                        name: "FK_FAQ_Applicants_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feedback_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feedback_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Feedback_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentPayment",
                columns: table => new
                {
                    RentPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentPayment_Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentPayment_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentPayment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentPayment_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPayment", x => x.RentPaymentId);
                    table.ForeignKey(
                        name: "FK_RentPayment_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisition",
                columns: table => new
                {
                    RequistitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requistition_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requistition_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Requistition_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisition", x => x.RequistitionId);
                    table.ForeignKey(
                        name: "FK_Requisition_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrder_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseOrder_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuppliersId = table.Column<int>(type: "int", nullable: false),
                    SuppliersId1 = table.Column<int>(type: "int", nullable: false),
                    RequistitionId = table.Column<int>(type: "int", nullable: false),
                    RequisitionRequistitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Requisition_RequisitionRequistitionId",
                        column: x => x.RequisitionRequistitionId,
                        principalTable: "Requisition",
                        principalColumn: "RequistitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Supplier_SuppliersId1",
                        column: x => x.SuppliersId1,
                        principalTable: "Supplier",
                        principalColumn: "SuppliersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionItem",
                columns: table => new
                {
                    RequistitionId = table.Column<int>(type: "int", nullable: false),
                    Requistition_Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requistition_Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Requistition_Units = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionItem", x => x.RequistitionId);
                    table.ForeignKey(
                        name: "FK_RequisitionItem_Requisition_RequistitionId",
                        column: x => x.RequistitionId,
                        principalTable: "Requisition",
                        principalColumn: "RequistitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItem",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    Purchase_Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purchase_Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Purchase_Units = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItem", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_PurchaseOrder_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingMemo",
                columns: table => new
                {
                    RMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RM_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RM_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RM_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingMemo", x => x.RMId);
                    table.ForeignKey(
                        name: "FK_ReceivingMemo_PurchaseOrder_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantForm_ApplicationId",
                table: "ApplicantForm",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQ_ApplicationId",
                table: "FAQ",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_TenantId",
                table: "Feedback",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_RequisitionRequistitionId",
                table: "PurchaseOrder",
                column: "RequisitionRequistitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_SuppliersId1",
                table: "PurchaseOrder",
                column: "SuppliersId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingMemo_PurchaseId",
                table: "ReceivingMemo",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_RentPayment_TenantId",
                table: "RentPayment",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_TenantId",
                table: "Requisition",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantForm");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "PurchaseItem");

            migrationBuilder.DropTable(
                name: "ReceivingMemo");

            migrationBuilder.DropTable(
                name: "RentPayment");

            migrationBuilder.DropTable(
                name: "RequisitionItem");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Requisition");
        }
    }
}
