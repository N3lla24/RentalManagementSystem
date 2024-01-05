﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalManagement.Data;

#nullable disable

namespace RentalManagement.Migrations
{
    [DbContext(typeof(RentalManagementContext))]
    [Migration("20240105204531_Requisition Attributes Changes")]
    partial class RequisitionAttributesChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RentalManagement.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("Admin_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("RentalManagement.Models.Applicants", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationId"), 1L, 1);

                    b.Property<DateTime>("Applicant_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Applicant_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Applicants_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicants_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicants_FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Applicants_LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Applicants_MiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Applicants_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Application_RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("Application_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Application_UnitNumber")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("RentalManagement.Models.FAQ", b =>
                {
                    b.Property<int>("FAQId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FAQId"), 1L, 1);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("FAQ_Content")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("FAQ_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FAQ_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FAQId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("FAQ");
                });

            modelBuilder.Entity("RentalManagement.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<string>("Feedback_Content")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("Feedback_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Feedback_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("TenantId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("RentalManagement.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"), 1L, 1);

                    b.Property<DateTime>("Inventory_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Inventory_ItemName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Inventory_ItemQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Inventory_ItemUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Inventory_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("RentalManagement.Models.Invoice", b =>
                {
                    b.Property<int>("Inv_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Inv_ID"), 1L, 1);

                    b.Property<DateTime>("Inv_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Inv_Method")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte[]>("Inv_ProofPayment")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Inv_Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Pay_ID")
                        .HasColumnType("int");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Inv_ID");

                    b.HasIndex("Pay_ID");

                    b.HasIndex("TenantId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("RentalManagement.Models.PaymentDetail", b =>
                {
                    b.Property<int>("Pay_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pay_ID"), 1L, 1);

                    b.Property<decimal>("Pay_AirconFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Pay_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Pay_DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Pay_GarbageFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pay_InternetFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pay_RefrigeratorFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pay_RentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Pay_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Pay_UtilityFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pay_WashingFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Pay_ID");

                    b.HasIndex("TenantId");

                    b.ToTable("PaymentDetail");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseItem", b =>
                {
                    b.Property<int>("PurchaseItem_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseItem_Id"), 1L, 1);

                    b.Property<string>("PurchaseItem_Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("PurchaseItem_Quantity")
                        .HasColumnType("int");

                    b.Property<string>("PurchaseItem_Unit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PurchaseOrderId")
                        .HasColumnType("int");

                    b.HasKey("PurchaseItem_Id");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseItem");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("PurchaseOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseOrderId"), 1L, 1);

                    b.Property<DateTime>("PurchaseOrder_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PurchaseOrder_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PurchaseOrder_Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RequisitionId")
                        .HasColumnType("int");

                    b.Property<int?>("RequistitionId")
                        .HasColumnType("int");

                    b.Property<int?>("SuppliersId")
                        .HasColumnType("int");

                    b.Property<int?>("SuppliersId1")
                        .HasColumnType("int");

                    b.HasKey("PurchaseOrderId");

                    b.HasIndex("RequisitionId");

                    b.HasIndex("SuppliersId1");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseService", b =>
                {
                    b.Property<int>("PurchaseServ_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseServ_Id"), 1L, 1);

                    b.Property<int?>("PurchaseOrderId")
                        .HasColumnType("int");

                    b.Property<string>("PurchaseServ_Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("PurchaseServ_Id");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseService");
                });

            modelBuilder.Entity("RentalManagement.Models.ReceivingMemo", b =>
                {
                    b.Property<int>("RMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RMId"), 1L, 1);

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RM_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("RM_Remarks")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("RM_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RMId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("ReceivingMemo");
                });

            modelBuilder.Entity("RentalManagement.Models.Requisition", b =>
                {
                    b.Property<int>("RequisitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequisitionId"), 1L, 1);

                    b.Property<DateTime>("Requisition_DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Requisition_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Requisition_Status_Remarks")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Requisition_Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Requistition_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("RequisitionId");

                    b.HasIndex("TenantId");

                    b.ToTable("Requisition");
                });

            modelBuilder.Entity("RentalManagement.Models.RequisitionItem", b =>
                {
                    b.Property<int>("Req_Item_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Req_Item_ID"), 1L, 1);

                    b.Property<string>("Req_Item_Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Req_Item_Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Req_Item_Units")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("RequisitionId")
                        .HasColumnType("int");

                    b.HasKey("Req_Item_ID");

                    b.HasIndex("RequisitionId");

                    b.ToTable("RequisitionItem");
                });

            modelBuilder.Entity("RentalManagement.Models.RequisitionService", b =>
                {
                    b.Property<int>("Req_Serv_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Req_Serv_ID"), 1L, 1);

                    b.Property<string>("Req_Serv_Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("RequisitionId")
                        .HasColumnType("int");

                    b.HasKey("Req_Serv_ID");

                    b.HasIndex("RequisitionId");

                    b.ToTable("RequisitionService");
                });

            modelBuilder.Entity("RentalManagement.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<int?>("Pay_ID")
                        .HasColumnType("int");

                    b.Property<int>("Room_Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Room_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Room_Num")
                        .HasColumnType("int");

                    b.Property<decimal>("Room_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Room_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Room_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("Pay_ID");

                    b.HasIndex("TenantId");

                    b.HasIndex("UnitId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("RentalManagement.Models.Supplier", b =>
                {
                    b.Property<int>("SuppliersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuppliersId"), 1L, 1);

                    b.Property<DateTime>("Supplier_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Supplier_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Suppliers_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suppliers_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suppliers_Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Suppliers_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuppliersId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("RentalManagement.Models.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantId"), 1L, 1);

                    b.Property<DateTime>("Tenant_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tenant_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tenant_LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tenant_MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tenant_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tenant_RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("Tenant_UnitNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Tenant_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tenant_UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TenantId");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"), 1L, 1);

                    b.Property<DateTime>("Unit_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Unit_Num")
                        .HasColumnType("int");

                    b.Property<string>("Unit_Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Unit_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UnitId");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("RentalManagement.Models.FAQ", b =>
                {
                    b.HasOne("RentalManagement.Models.Applicants", "Applicants")
                        .WithMany()
                        .HasForeignKey("ApplicationId");

                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("RentalManagement.Models.Feedback", b =>
                {
                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.Invoice", b =>
                {
                    b.HasOne("RentalManagement.Models.PaymentDetail", "PaymentDetail")
                        .WithMany()
                        .HasForeignKey("Pay_ID");

                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("PaymentDetail");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.PaymentDetail", b =>
                {
                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseItem", b =>
                {
                    b.HasOne("RentalManagement.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany()
                        .HasForeignKey("PurchaseOrderId");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseOrder", b =>
                {
                    b.HasOne("RentalManagement.Models.Requisition", "Requisition")
                        .WithMany()
                        .HasForeignKey("RequisitionId");

                    b.HasOne("RentalManagement.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SuppliersId1");

                    b.Navigation("Requisition");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseService", b =>
                {
                    b.HasOne("RentalManagement.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany()
                        .HasForeignKey("PurchaseOrderId");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("RentalManagement.Models.ReceivingMemo", b =>
                {
                    b.HasOne("RentalManagement.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany()
                        .HasForeignKey("PurchaseId");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("RentalManagement.Models.Requisition", b =>
                {
                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.RequisitionItem", b =>
                {
                    b.HasOne("RentalManagement.Models.Requisition", "Requisition")
                        .WithMany()
                        .HasForeignKey("RequisitionId");

                    b.Navigation("Requisition");
                });

            modelBuilder.Entity("RentalManagement.Models.RequisitionService", b =>
                {
                    b.HasOne("RentalManagement.Models.Requisition", "Requisition")
                        .WithMany()
                        .HasForeignKey("RequisitionId");

                    b.Navigation("Requisition");
                });

            modelBuilder.Entity("RentalManagement.Models.Room", b =>
                {
                    b.HasOne("RentalManagement.Models.PaymentDetail", "PaymentDetail")
                        .WithMany()
                        .HasForeignKey("Pay_ID");

                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.HasOne("RentalManagement.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("PaymentDetail");

                    b.Navigation("Tenant");

                    b.Navigation("Unit");
                });
#pragma warning restore 612, 618
        }
    }
}
