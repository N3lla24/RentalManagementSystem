﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Models;

namespace RentalManagement.Data
{
    public class RentalManagementContext : DbContext
    {
        public RentalManagementContext (DbContextOptions<RentalManagementContext> options)
            : base(options)
        {
        }

        public DbSet<RentalManagement.Models.Applicants> Applicants { get; set; } = default!;

        public DbSet<RentalManagement.Models.Inventory>? Inventory { get; set; }

        public DbSet<RentalManagement.Models.Supplier>? Supplier { get; set; }

        public DbSet<RentalManagement.Models.Tenant>? Tenant { get; set; }

        public DbSet<RentalManagement.Models.ApplicantForm> ApplicantForm { get; set; }

        public DbSet<RentalManagement.Models.FAQ> FAQ { get; set; }

        public DbSet<RentalManagement.Models.Feedback> Feedback { get; set; }

        public DbSet<RentalManagement.Models.RentPayment> RentPayment { get; set; }

        public DbSet<RentalManagement.Models.Requisition> Requisition { get; set; }

        public DbSet<RentalManagement.Models.RequisitionItem> RequisitionItem { get; set; }

        public DbSet<RentalManagement.Models.PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<RentalManagement.Models.PurchaseItem> PurchaseItem { get; set; }

        public DbSet<RentalManagement.Models.ReceivingMemo> ReceivingMemo { get; set; }



    }
}
