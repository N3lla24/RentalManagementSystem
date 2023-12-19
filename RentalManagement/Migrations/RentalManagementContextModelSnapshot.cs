﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalManagement.Data;

#nullable disable

namespace RentalManagement.Migrations
{
    [DbContext(typeof(RentalManagementContext))]
    partial class RentalManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RentalManagement.Models.ApplicantForm", b =>
                {
                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Application_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Application_RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("Application_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Application_UnitNumber")
                        .HasColumnType("int");

                    b.HasKey("ApplicationId");

                    b.ToTable("ApplicantForm");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicants_LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicants_MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicants_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("RentalManagement.Models.FAQ", b =>
                {
                    b.Property<int>("FAQId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FAQId"), 1L, 1);

                    b.Property<int>("ApplicationId")
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Feedback_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Feedback_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TenantId")
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
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<decimal>("Pay_ElectricityFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pay_GarbageFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pay_GasFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pay_InternetFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Pay_Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pay_RentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Pay_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pay_TapwaterFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pay_WaterFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Pay_ID");

                    b.HasIndex("TenantId");

                    b.ToTable("PaymentDetail");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseItem", b =>
                {
                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<string>("Purchase_ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Purchase_Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Purchase_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purchase_Units")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PurchaseId");

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

                    b.Property<DateTime>("PurchaseOrder_ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PurchaseOrder_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequisitionId")
                        .HasColumnType("int");

                    b.Property<int>("RequistitionId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.Property<int?>("SuppliersId1")
                        .HasColumnType("int");

                    b.HasKey("PurchaseOrderId");

                    b.HasIndex("RequisitionId");

                    b.HasIndex("SuppliersId1");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("RentalManagement.Models.ReceivingMemo", b =>
                {
                    b.Property<int>("RMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RMId"), 1L, 1);

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RM_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("RM_Remarks")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("RM_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Requisition_Remarks")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Requisition_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requisition_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Requistition_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TenantId")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Req_Item_Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Req_Item_Units")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequisitionId")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequisitionId")
                        .HasColumnType("int");

                    b.HasKey("Req_Serv_ID");

                    b.HasIndex("RequisitionId");

                    b.ToTable("RequisitionService");
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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tenant_RoomNumber")
                        .HasColumnType("int");

                    b.Property<decimal?>("Tenant_TotPay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tenant_UnitNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Tenant_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TenantId");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.ApplicantForm", b =>
                {
                    b.HasOne("RentalManagement.Models.Applicants", "Applicants")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("RentalManagement.Models.FAQ", b =>
                {
                    b.HasOne("RentalManagement.Models.Applicants", "Applicants")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("RentalManagement.Models.Feedback", b =>
                {
                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.PaymentDetail", b =>
                {
                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseItem", b =>
                {
                    b.HasOne("RentalManagement.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany()
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("RentalManagement.Models.ReceivingMemo", b =>
                {
                    b.HasOne("RentalManagement.Models.PurchaseOrder", "PurchaseOrder")
                        .WithMany()
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("RentalManagement.Models.Requisition", b =>
                {
                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RentalManagement.Models.RequisitionItem", b =>
                {
                    b.HasOne("RentalManagement.Models.Requisition", "Requisition")
                        .WithMany()
                        .HasForeignKey("RequisitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requisition");
                });

            modelBuilder.Entity("RentalManagement.Models.RequisitionService", b =>
                {
                    b.HasOne("RentalManagement.Models.Requisition", "Requisition")
                        .WithMany()
                        .HasForeignKey("RequisitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requisition");
                });
#pragma warning restore 612, 618
        }
    }
}
