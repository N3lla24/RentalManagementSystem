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
                    b.Property<int>("ApplicationFormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationFormId"), 1L, 1);

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Application_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Application_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationFormId");

                    b.HasIndex("ApplicationId");

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

                    b.Property<DateTime>("Applicant_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Applicants_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicants_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicants_Name")
                        .IsRequired()
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FAQ_Date")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Feedback_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Feedback_UpdatedAt")
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

                    b.Property<string>("Inventory_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Inventory_Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Inventory_Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Supplier_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Supplier_UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("RentalManagement.Models.PurchaseItem", b =>
                {
                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<string>("Purchase_Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Purchase_Quantity")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<DateTime>("PurchaseOrder_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PurchaseOrder_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequisitionRequistitionId")
                        .HasColumnType("int");

                    b.Property<int>("RequistitionId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersId1")
                        .HasColumnType("int");

                    b.HasKey("PurchaseOrderId");

                    b.HasIndex("RequisitionRequistitionId");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RM_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RMId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("ReceivingMemo");
                });

            modelBuilder.Entity("RentalManagement.Models.RentPayment", b =>
                {
                    b.Property<int>("RentPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentPaymentId"), 1L, 1);

                    b.Property<decimal>("RentPayment_Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RentPayment_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("RentPayment_Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RentPayment_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("RentPaymentId");

                    b.HasIndex("TenantId");

                    b.ToTable("RentPayment");
                });

            modelBuilder.Entity("RentalManagement.Models.Requisition", b =>
                {
                    b.Property<int>("RequistitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequistitionId"), 1L, 1);

                    b.Property<DateTime>("Requistition_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Requistition_Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requistition_Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("RequistitionId");

                    b.HasIndex("TenantId");

                    b.ToTable("Requisition");
                });

            modelBuilder.Entity("RentalManagement.Models.RequisitionItem", b =>
                {
                    b.Property<int>("RequistitionId")
                        .HasColumnType("int");

                    b.Property<string>("Requistition_Item")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Requistition_Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Requistition_Units")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequistitionId");

                    b.ToTable("RequisitionItem");
                });

            modelBuilder.Entity("RentalManagement.Models.Supplier", b =>
                {
                    b.Property<int>("SuppliersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuppliersId"), 1L, 1);

                    b.Property<DateTime>("Supplier_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Supplier_UpdatedAt")
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

                    b.Property<string>("Tenant_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tenant_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Tenant_RentPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tenant_RentTot")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tenant_RoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("Tenant_UnitNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tenant_UpdatedAt")
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
                        .HasForeignKey("RequisitionRequistitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalManagement.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SuppliersId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("RentalManagement.Models.RentPayment", b =>
                {
                    b.HasOne("RentalManagement.Models.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
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
                        .HasForeignKey("RequistitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requisition");
                });
#pragma warning restore 612, 618
        }
    }
}
