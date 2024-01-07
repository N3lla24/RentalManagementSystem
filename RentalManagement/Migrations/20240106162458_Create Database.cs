using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalManagement.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Admin_Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Applicants_FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Applicants_MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Applicants_LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Applicants_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applicants_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applicants_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Application_RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Application_UnitNumber = table.Column<int>(type: "int", nullable: false),
                    Application_Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Application_StatusRemark = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Applicant_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Applicant_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inventory_ItemName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Inventory_ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    Inventory_ItemUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inventory_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inventory_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suppliers_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Suppliers_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suppliers_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suppliers_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Supplier_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Tenant_FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tenant_MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tenant_LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tenant_UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tenant_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tenant_RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Tenant_UnitNumber = table.Column<int>(type: "int", nullable: false),
                    Tenant_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tenant_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit_Num = table.Column<int>(type: "int", nullable: false),
                    Unit_Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unit_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unit_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    FAQId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAQ_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAQ_Content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FAQ_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.FAQId);
                    table.ForeignKey(
                        name: "FK_FAQ_Applicants_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicationId");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feedback_Content = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Feedback_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Feedback_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetail",
                columns: table => new
                {
                    Pay_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pay_DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pay_RentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pay_UtilityFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pay_GarbageFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pay_AirconFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pay_InternetFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pay_RefrigeratorFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pay_WashingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pay_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pay_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetail", x => x.Pay_ID);
                    table.ForeignKey(
                        name: "FK_PaymentDetail_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Requisition",
                columns: table => new
                {
                    RequisitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requisition_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Requisition_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisition_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Requisition_DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Requisition_Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Requisition_StatusRemarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisition", x => x.RequisitionId);
                    table.ForeignKey(
                        name: "FK_Requisition_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Inv_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inv_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inv_Method = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Inv_Status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Inv_ProofPayment = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Pay_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Inv_ID);
                    table.ForeignKey(
                        name: "FK_Invoice_PaymentDetail_Pay_ID",
                        column: x => x.Pay_ID,
                        principalTable: "PaymentDetail",
                        principalColumn: "Pay_ID");
                    table.ForeignKey(
                        name: "FK_Invoice_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Num = table.Column<int>(type: "int", nullable: false),
                    Room_Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Room_Capacity = table.Column<int>(type: "int", nullable: false),
                    Room_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Room_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Pay_ID = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_PaymentDetail_Pay_ID",
                        column: x => x.Pay_ID,
                        principalTable: "PaymentDetail",
                        principalColumn: "Pay_ID");
                    table.ForeignKey(
                        name: "FK_Room_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId");
                    table.ForeignKey(
                        name: "FK_Room_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrder_Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PurchaseOrder_StatusRemarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PurchaseOrder_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PurchaseOrder_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuppliersId = table.Column<int>(type: "int", nullable: true),
                    SuppliersId1 = table.Column<int>(type: "int", nullable: true),
                    RequistitionId = table.Column<int>(type: "int", nullable: true),
                    RequisitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Requisition_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionId");
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Supplier_SuppliersId1",
                        column: x => x.SuppliersId1,
                        principalTable: "Supplier",
                        principalColumn: "SuppliersId");
                });

            migrationBuilder.CreateTable(
                name: "RequisitionItem",
                columns: table => new
                {
                    Req_Item_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Req_Item_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Req_Item_Quantity = table.Column<int>(type: "int", nullable: true),
                    Req_Item_Units = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequisitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionItem", x => x.Req_Item_ID);
                    table.ForeignKey(
                        name: "FK_RequisitionItem_Requisition_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionId");
                });

            migrationBuilder.CreateTable(
                name: "RequisitionService",
                columns: table => new
                {
                    Req_Serv_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Req_Serv_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    RequisitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionService", x => x.Req_Serv_ID);
                    table.ForeignKey(
                        name: "FK_RequisitionService_Requisition_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisition",
                        principalColumn: "RequisitionId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItem",
                columns: table => new
                {
                    PurchaseItem_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseItem_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PurchaseItem_Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseItem_Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItem", x => x.PurchaseItem_Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderId");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseService",
                columns: table => new
                {
                    PurchaseServ_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseServ_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseService", x => x.PurchaseServ_Id);
                    table.ForeignKey(
                        name: "FK_PurchaseService_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderId");
                });

            migrationBuilder.CreateTable(
                name: "ReceivingMemo",
                columns: table => new
                {
                    RMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RM_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RM_Remarks = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RM_Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingMemo", x => x.RMId);
                    table.ForeignKey(
                        name: "FK_ReceivingMemo_PurchaseOrder_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "PurchaseOrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FAQ_ApplicationId",
                table: "FAQ",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_TenantId",
                table: "Feedback",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Pay_ID",
                table: "Invoice",
                column: "Pay_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_TenantId",
                table: "Invoice",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetail_TenantId",
                table: "PaymentDetail",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_PurchaseOrderId",
                table: "PurchaseItem",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_RequisitionId",
                table: "PurchaseOrder",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_SuppliersId1",
                table: "PurchaseOrder",
                column: "SuppliersId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseService_PurchaseOrderId",
                table: "PurchaseService",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingMemo_PurchaseId",
                table: "ReceivingMemo",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisition_TenantId",
                table: "Requisition",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionItem_RequisitionId",
                table: "RequisitionItem",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionService_RequisitionId",
                table: "RequisitionService",
                column: "RequisitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Pay_ID",
                table: "Room",
                column: "Pay_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_TenantId",
                table: "Room",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_UnitId",
                table: "Room",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "PurchaseItem");

            migrationBuilder.DropTable(
                name: "PurchaseService");

            migrationBuilder.DropTable(
                name: "ReceivingMemo");

            migrationBuilder.DropTable(
                name: "RequisitionItem");

            migrationBuilder.DropTable(
                name: "RequisitionService");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "PaymentDetail");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Requisition");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
