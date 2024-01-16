using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using System.Threading.Tasks;
using RentalManagement.Services;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using System.Data;
using System.Dynamic;

namespace RentalManagement.Controllers
{
    public class AdminHome : Controller
    {
        private readonly RentalManagementContext _context;

        private readonly ILogger<AdminHome> _logger;

        public AdminHome(ILogger<AdminHome> logger, RentalManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Home()
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }

            return _context.Admin != null ?
                          View(_context.Admin
                          .FirstOrDefault(m => m.AdminId == GetId())) :
                          Problem("Entity set 'RentalManagementContext.Admin'  is null.");
        }

        public IActionResult ManageSupplier()
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }


            return View();
        }

        private Dictionary<string, int> GetInvoiceStatusCountsFromDatabase()
        {
            // Use your Entity Framework context to query the database
            var invoiceStatusCounts = _context.Invoice
                .GroupBy(i => i.Inv_Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Status, x => x.Count);

            invoiceStatusCounts["Unknown"] = _context.Invoice.Count(i => string.IsNullOrEmpty(i.Inv_Status));

            return invoiceStatusCounts;
        }


        [HttpPost]
        public FileResult DownloadTable(string selectedTable)
        {
            // Retrieve the data for the selected table from the database
            var tableData = RetrieveTableData(selectedTable); // Replace this with your actual method to retrieve table data

            // Convert the data to CSV format
            byte[] fileContents = ConvertDataToCsv(tableData); // Replace this with your actual method to convert data to CSV

            // Return the CSV file for download
            return File(fileContents, "text/csv", selectedTable + ".csv");
        }

        // Method to retrieve table data from the database
        private List<dynamic> RetrieveTableData(string tableName)
        {
            var tableData = new List<dynamic>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {tableName}";
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var dataRecord = (IDataRecord)result;
                        var rowData = new ExpandoObject() as IDictionary<string, object>;

                        for (var i = 0; i < dataRecord.FieldCount; i++)
                        {
                            rowData.Add(dataRecord.GetName(i), dataRecord[i]);
                        }

                        tableData.Add(rowData);
                    }
                }
            }

            return tableData;
        }


        // Method to convert data to CSV format
        private byte[] ConvertDataToCsv(object tableData)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords((IEnumerable<dynamic>)tableData);
                streamWriter.Flush();
                return memoryStream.ToArray();
            }
        }

        public async Task<IActionResult> ManageRental()
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            try
            {
                var tenant = await _context.Tenant.ToListAsync();
                var requisition = await _context.Requisition.ToListAsync();
                var room = await _context.Room.ToListAsync();
                var applicants = await _context.Applicants.ToListAsync();
                var invoice = await _context.Invoice.ToListAsync();
                var ph = await _context.PaymentDetail.ToListAsync();
                var rh = await _context.Requisition.ToListAsync();


                if (tenant != null && requisition != null && room != null && invoice != null && applicants != null && ph != null && rh != null)
                {
                    var tenantDisplayList = tenant.Select(tenant => new TenantDisplay
                    {
                        TenantId = tenant.TenantId, 
                        Tenant_FirstName = tenant.Tenant_FirstName,
                        Tenant_LastName = tenant.Tenant_LastName,

                    }).ToList();

                    var requisitionDisplayList = requisition
                        .Where(r => r.Requisition_Status != "Reject")
                        .Select(requisition => new RequisitionDisplay
                    {
                        RequisitionId = requisition.RequisitionId,
                        Requisition_Type = requisition.Requisition_Type,
                        Requisition_CreatedAt = requisition.Requisition_CreatedAt,
                        Requisition_Status = requisition.Requisition_Status,
                   
                    }).ToList();

                    var roomDisplayList = room.Select(room => new RoomDisplay
                    {
                        RoomId = room.RoomId,
                        Room_Num = room.Room_Num,
                        Room_Status = room.Room_Status,
                        Room_Capacity = room.Room_Capacity,

                    }).ToList();

                    var invoiceDisplayList = invoice.Select(invoice => new InvoiceDisplay
                    {
                        Inv_ID = invoice.Inv_ID,
                        Inv_CreatedAt = invoice.Inv_CreatedAt,
                        Inv_Method = invoice.Inv_Method,
                        Inv_Status = invoice.Inv_Status,
                        Inv_ProofPayment = invoice.Inv_ProofPayment,

                    }).ToList();

                    var appDisplayList = applicants.Select(applicants => new ApplicationDisplay
                    {
                        ApplicationId = applicants.ApplicationId,
                        Applicants_FirstName = applicants.Applicants_FirstName,
                        Applicants_MiddleName = applicants.Applicants_MiddleName,
                        Applicants_LastName = applicants.Applicants_LastName,
                        Applicants_Email = applicants.Applicants_Email,
                        Applicants_PhoneNumber = applicants.Applicants_PhoneNumber,
                        Applicants_Address = applicants.Applicants_Address,
                        Application_RoomNumber = applicants.Application_RoomNumber,
                        Application_UnitNumber = applicants.Application_UnitNumber,
                        Application_Status = applicants.Application_Status,
                        Application_StatusRemarks = applicants.Application_StatusRemark,
                        Applicant_CreatedAt = applicants.Applicant_CreatedAt,
                        Applicant_UpdatedAt = applicants.Applicant_UpdatedAt,
                    }).ToList();

                    var paymentHistoryList = ph.Select(ph => new PaymentDetail
                    {
                        Pay_ID = ph.Pay_ID,
                        Pay_DueDate = ph.Pay_DueDate,
                        Pay_RentPrice = ph.Pay_RentPrice,
                        Pay_UtilityFee = ph.Pay_UtilityFee,
                        Pay_GarbageFee = ph.Pay_GarbageFee,
                        Pay_AirconFee = ph.Pay_AirconFee,
                        Pay_InternetFee = ph.Pay_InternetFee,
                        Pay_RefrigeratorFee = ph.Pay_RefrigeratorFee,
                        Pay_WashingFee = ph.Pay_WashingFee,
                        Pay_UpdatedAt = ph.Pay_UpdatedAt,
                        TenantId = ph.TenantId,

                    }).ToList();

                    var requisitionHistoryList = rh.Select(rh => new Requisition
                    {
                        RequisitionId = rh.RequisitionId,
                        Requisition_Type = rh.Requisition_Type,
                        Requisition_CreatedAt = rh.Requisition_CreatedAt,
                        Requisition_Status = rh.Requisition_Status,
                        Requisition_Remarks = rh.Requisition_Remarks,
                        Requisition_DueDate = rh.Requisition_DueDate,
                        TenantId = rh.TenantId,

                    }).ToList();

                    var invoiceStatusCounts = GetInvoiceStatusCountsFromDatabase();

                    var tableNames = _context.Model.GetEntityTypes().Select(t => t.GetTableName()).ToList();
                    var viewModel = new RentalViewModel
                    {
                        // Populate existing data
                        Tenant = tenantDisplayList,
                        Requisition = requisitionDisplayList,
                        Room = roomDisplayList,
                        PaymentHistory = paymentHistoryList,
                        Invoice = invoiceDisplayList,
                        RequisitionHistory = requisitionHistoryList,
                        Applicants = appDisplayList,
                        InvoiceStatusCounts = invoiceStatusCounts,
                        TableNames = tableNames

                    };


                    return View(viewModel);
                }
                else
                {
                    return Problem("Error fetching data from the database.");
                }
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                _logger.LogError(ex, "An error occurred while processing the application.");
                return Content("An unexpected error occurred. Please try again later.");
            }
        }

        public async Task<IActionResult> TenantDetails(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            if (id == null || _context.Tenant == null)
            {
                return NotFound();
            }

            var tenants = await _context.Tenant
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenants == null)
            {
                return NotFound();
            }

            var paymentHistory = _context.PaymentDetail
                .Where(ph => ph.TenantId == id)
                .ToList();

            var reqHistory = _context.Requisition
                .Where(rh => rh.TenantId == id)
                .ToList();

            var viewModel = new RentalViewModel
            {
                Tenant = new List<TenantDisplay>
        {
            new TenantDisplay
            {
                TenantId = tenants.TenantId,
                Tenant_FirstName = tenants.Tenant_FirstName,
                Tenant_MiddleName = tenants.Tenant_MiddleName,
                Tenant_LastName = tenants.Tenant_LastName,
                Tenant_Email = tenants.Tenant_Email,
                Tenant_PhoneNumber = tenants.Tenant_PhoneNumber,
                Tenant_RoomNumber = tenants.Tenant_RoomNumber,
                Tenant_UnitNumber = tenants.Tenant_UnitNumber,
                Tenant_UpdatedAt = tenants.Tenant_UpdatedAt,
            }
        },
                PaymentHistory = paymentHistory,
                RequisitionHistory = reqHistory,
            };

            return View(viewModel);
        }


        //Get Tenant Delete Details
        public async Task<IActionResult> TenantDelete(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            if (id == null || _context.Tenant == null)
            {
                return NotFound();
            }

            var tenants = await _context.Tenant
                .FirstOrDefaultAsync(m => m.TenantId == id);
            if (tenants == null)
            {
                return NotFound();
            }

            return View(tenants);
        }

        // POST: Tenants/Delete/
        [HttpPost, ActionName("TenantDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TenantDeleteConfirmed(int id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            if (_context.Tenant == null)
            {
                return Problem("Entity set 'RentalManagementContext.Tenant'  is null.");
            }
            try
            {
                var tenant = await _context.Tenant.FindAsync(id);
                if (tenant == null)
                {
                    return Content("Tenant can't be found");
                }
                var room = await _context.Room.FirstOrDefaultAsync(r => r.Room_Num == tenant.Tenant_RoomNumber && r.UnitId == tenant.Tenant_UnitNumber);
                if(room == null)
                {
                    return Content("Room can't be found");
                }
                room.Room_Status = "Unoccupied";
                room.TenantId = null;
                _context.Update(room);
                _context.Tenant.Remove(tenant);
                await _context.SaveChangesAsync();
                ViewData["SuccessfulDelete"] = "SuccessDel";
                return RedirectToAction("ManageRental", "AdminHome");
            }
            catch
            {
                return Content("An error occured while processing the application. Try again later");
            }
            
        }
        public async Task<IActionResult> DetailsRequisition(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            if (id == null || _context.Requisition == null)
            {
                return NotFound();
            }
        
            var requisition = await _context.Requisition
                .Include(m => m.Tenant)
                .Include(m => m.RequisitionItems)
                .Include(m => m.RequisitionServices)
                .FirstOrDefaultAsync(m => m.RequisitionId == id);
            if (requisition == null)
            {
                return NotFound();
            }
        
            return View(requisition);
        }
        //Get Applicants Details
        public async Task<IActionResult> AppDetails(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            if (id == null || _context.Applicants == null)
            {
                return NotFound();
            }

            var applicants = await _context.Applicants
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (applicants == null)
            {
                return NotFound();
            }

            return View(applicants);
        }
        public async Task<IActionResult> AcceptRequest(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            var requisition = await _context.Requisition
                .Include(m => m.Tenant)
                .Include(m => m.RequisitionItems)
                .Include(m => m.RequisitionServices)
                .FirstOrDefaultAsync(m => m.RequisitionId == id);
            if (requisition != null)
            {
        
                requisition.Requisition_Status = "Checking Request.";
                _context.Update(requisition);
                await _context.SaveChangesAsync();
        
                return RedirectToAction("ManageRental", "AdminHome");
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Accept(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            var applicants = await _context.Applicants
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (applicants == null)
            {
                return NotFound();
            }
            return View(applicants);
        }


        public async Task<IActionResult> AcceptConfirmed([Bind("ApplicationId, Application_StatusRemark")] Applicants applicants)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            try
            {
                Applicants matchapp = await _context.Applicants.FirstOrDefaultAsync(m => m.ApplicationId == applicants.ApplicationId);
                if (matchapp == null)
                {
                    return Content("An unexpected error occurred. Please try again later.");
                }
                try
                {
                    var room = _context.Room.FirstOrDefault(r => r.UnitId == matchapp.Application_UnitNumber && r.Room_Num == matchapp.Application_RoomNumber);
                    if (room is null) { return Content("An unexpected error occurred. Please try again later."); }
                    room.Room_Status = "Occupied";
                    _context.Update(room);
                    matchapp.Application_Status = "Accept";
                    matchapp.Application_StatusRemark = applicants.Application_StatusRemark;
                    matchapp.Applicant_UpdatedAt = DateTime.Now;
                    _context.Update(matchapp);
                    _context.Tenant.AddRange(
                            new Tenant
                            {
                                Tenant_FirstName = matchapp.Applicants_FirstName,
                                Tenant_MiddleName = matchapp.Applicants_MiddleName,
                                Tenant_LastName = matchapp.Applicants_LastName,
                                Tenant_UserName = "N/A",
                                Tenant_Email = matchapp.Applicants_Email,
                                Tenant_PhoneNumber = matchapp.Applicants_PhoneNumber,
                                Tenant_Password = "N/A",
                                Tenant_RoomNumber = matchapp.Application_RoomNumber,
                                Tenant_UnitNumber = matchapp.Application_UnitNumber,
                                Tenant_CreatedAt = DateTime.Now,
                                Tenant_UpdatedAt = DateTime.Now,
                            }
                        );
                    await _context.SaveChangesAsync();
                    ViewData["SuccessfulAccept"] = "Successful Accept";
                    return RedirectToAction("ManageRental", "AdminHome");
                }
                catch (Exception ex)
                {
                    return Content("An unexpected error occurred. Please try again later.");
                }                
            }
            catch (Exception ex)
            {
                return Content("An unexpected error occurred. Please try again later.");
            }
        }

        public async Task<IActionResult> RejectRequest(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            var requisition = await _context.Requisition
                .Include(m => m.Tenant)
                .Include(m => m.RequisitionItems)
                .Include(m => m.RequisitionServices)
                .FirstOrDefaultAsync(m => m.RequisitionId == id);
            if (requisition != null)
            {
        
                requisition.Requisition_Status = "Reject: Cannot Accept Your Request.";
                _context.Update(requisition);
                await _context.SaveChangesAsync();
        
                return RedirectToAction("ManageRental","AdminHome");
            }
            else
            {
                return NotFound();
            }
        }
        

        public async Task<IActionResult> Reject(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            var applicants = await _context.Applicants
                .FirstOrDefaultAsync(m => m.ApplicationId == id);
            if (applicants == null)
            {
                return NotFound();
            }
            return View(applicants);
        }

        public async Task<IActionResult> RejectForm([Bind("ApplicationId, Application_StatusRemark")] Applicants applicants)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            Applicants matchapp = await _context.Applicants.FirstOrDefaultAsync(m => m.ApplicationId == applicants.ApplicationId);
            if (matchapp == null) { return Content("Application Not Found"); }
            if (matchapp != null)
            {
                try
                {
                    matchapp.Application_Status = "Reject";
                    matchapp.Application_StatusRemark = applicants.Application_StatusRemark;
                    matchapp.Applicant_UpdatedAt = DateTime.Now;
                    _context.Update(matchapp);
                    await _context.SaveChangesAsync();
                    ViewData["SuccessfulRejected"] = "Successful Reject";
                    return RedirectToAction("ManageRental", "AdminHome");
                }
                catch
                {
                    return Content("An unexpected error occurred. Please try again later.");
                }

            }
            return View(applicants);
        }

        //Delete Rejected Applicant
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            if (_context.Applicants == null)
            {
                return Problem("The Applicant can't be found. No Applicants in the database.");
            }
            try
            {
                var applicant = await _context.Applicants.FindAsync(id);
                if (applicant == null)
                {
                    return Content("An unexpected error occurred. Please try again later.");
                }
                _context.Applicants.Remove(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageRental", "AdminHome");
            }
            catch
            {
                return Content("An unexpected error occurred. Please try again later.");
            }
        }

        //Get Account Details for Settings
        public IActionResult Settings()
        {

            if (GetId() == null || _context.Admin == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var admin = _context.Admin.Find(GetId());
            if (admin == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Settings([Bind("AdminId, Admin_UserName, Admin_Email, Admin_PhoneNumber")] Admin admin)
        {
            Admin currentadmin = await _context.Admin.FirstOrDefaultAsync(q => q.AdminId == GetId());

            if (currentadmin != null)
            {
                try
                {
                    Tenant existingusername = await _context.Tenant.FirstOrDefaultAsync(q => q.Tenant_UserName == admin.Admin_UserName);
                    Admin existingadminname = await _context.Admin.FirstOrDefaultAsync(q => q.Admin_UserName == admin.Admin_UserName && q.AdminId != admin.AdminId);
                    if (existingusername != null || existingadminname != null)
                    {
                        ViewData["ExistingUserName"] = "Existing Username";
                        return View(existingadminname);
                    }

                    currentadmin.Admin_UserName = admin.Admin_UserName;
                    currentadmin.Admin_Email = admin.Admin_Email;
                    currentadmin.Admin_PhoneNumber = admin.Admin_PhoneNumber;

                    _context.Update(currentadmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists())
                    {
                        ViewData["SuccessfulEdit"] = null;
                        ViewData["ErrorEdit"] = "Not Found";
                        return View();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["ErrorEdit"] = null;
                ViewData["SuccessfulEdit"] = "Edit Successfully";
                return View();
            }
            ViewData["SuccessfulEdit"] = null;
            ViewData["ErrorEdit"] = "Edit Failed";
            return View(currentadmin);
        }


        public IActionResult ValidatePass()
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidatePass([Bind("Admin_Password")] Admin admin)
        {
            try
            {
                var pass = Hashing.HashPass(admin.Admin_Password);
                if (pass == null)
                {
                    ViewData["ValidationError"] = "ErrorPass";
                    return View();
                }
                Admin currentadmin = await _context.Admin.FirstOrDefaultAsync(q => q.AdminId == GetId() && q.Admin_Password == pass);

                if (currentadmin == null)
                {
                    ViewData["ValidationError"] = "ErrorPass";
                    return View();
                }
                ViewData["ValidationSuccess"] = "ValidateComp";
                return RedirectToAction("ChangePass", "AdminHome");
            }
            catch
            {
                ViewData["ValidationError"] = "ErrorPass";
                return View();
            }
        }

        public IActionResult ChangePass()
        {

            if (GetId() == null || _context.Admin == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var admin = _context.Admin.Find(GetId());
            if (admin == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePass([Bind("Admin_Password")] Admin admin)
        {
            Admin currentadmin = await _context.Admin.FirstOrDefaultAsync(q => q.AdminId == GetId());

            if (currentadmin != null)
            {
                try
                {
                    if (currentadmin.Admin_Password == Hashing.HashPass(admin.Admin_Password))
                    {
                        ViewData["SamePass"] = "Same Password";
                        return View();
                    }
                    currentadmin.Admin_Password = Hashing.HashPass(admin.Admin_Password);
                    _context.Update(currentadmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists())
                    {
                        ViewData["ChangePassSuccessful"] = null;
                        ViewData["ChangePassFail"] = "Not Found";
                        return View();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["ChangePassFail"] = null;
                ViewData["ChangePassSuccessful"] = "Changed Successfully";
                return View();
            }
            ViewData["ChangePassSuccessful"] = null;
            ViewData["ChangePassFail"] = "Changing Failed";
            return View();
        }

        private bool AdminExists()
        {
            return (_context.Admin?.Any(e => e.AdminId == GetId())).GetValueOrDefault();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("adminid");
            return RedirectToAction("Index", "Home");
        }
        private int? GetId()
        {
            var id = HttpContext.Session.GetInt32("adminid");
            if (id is not null) { return id; }
            return null;
        }

        public async Task<IActionResult> DetailsRoom(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(m => m.Tenant)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        public async Task<IActionResult> PaymentHistory(int? id)
        {
            if (GetId() is null) { return RedirectToAction("Index", "Login"); }
            if (id == null || _context.Tenant == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenant
                .FirstOrDefaultAsync(m => m.TenantId == id);

            if (tenant == null)
            {
                return NotFound();
            }

            // Retrieve payment history for the current tenant
            var paymentHistory = _context.PaymentDetail
                .Where(ph => ph.TenantId == id)
                .ToList();

            return View(paymentHistory);
        }
        
        [HttpGet]
        //public async Task<IActionResult> PurchaseRequest(int? id)
        //{
        //    if (GetId() == null || _context.Admin == null)
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var requisition = await _context.Requisition
        //        .Include(m => m.RequisitionItems)
        //        .Include(m => m.RequisitionServices)
        //        .FirstOrDefaultAsync(m => m.RequisitionId == id);

        //    if (requisition == null)
        //    {
        //        return NotFound();
        //    }

        //    //PurchaseVM obj = new PurchaseVM();
        //    //obj.Requisitions = await _context.Requisition
        //    //    .FirstOrDefaultAsync(m => m.RequisitionId == id);
        //    //obj.Suppliers = await _context.Supplier.ToListAsync();         
        //    //obj.PurchaseOrder = new PurchaseOrder();
        //    //obj.PurchaseItems = _context.PurchaseItem.ToList();
        //    //obj.PurchaseServices = _context.PurchaseService.ToList();



        //    //return View(obj);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult PurchaseRequest([Bind("PurchaseOrder, PurchaseItems, PurchaseServices, Supplier, Requisitions, supplierId")] PurchaseVM po)
        //{
        //    if (GetId() == null || _context.Admin == null)
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                
        //        return BadRequest(new { Errors = errors });
        //    }
        //    if (po == null)
        //    {
        //        return NotFound();
        //    }

        //    if (po.PurchaseOrder != null)
        //    {
        //        int suppliersId = po.supplierId;

        //        if (!_context.Supplier.Any(s => s.SuppliersId == suppliersId))
        //        {
        //            return BadRequest("Invalid Supplier ID");
        //        }

        //        PurchaseOrder pur = new PurchaseOrder
        //        {
        //            PurchaseOrder_CreatedAt = DateTime.Now,
        //            PurchaseOrder_Type = po.PurchaseOrder?.PurchaseOrder_Type,
        //            PurchaseOrder_Status = po.PurchaseOrder?.PurchaseOrder_Status,
        //            SuppliersId = suppliersId,
        //            RequisitionId = po.Requisitions?.RequisitionId,
        //        };

                
        //        _context.PurchaseOrder.Add(pur);
        //        _context.SaveChanges();
        //        if (po.PurchaseItems != null && po.PurchaseOrder != null && po.PurchaseOrder.PurchaseOrder_Type == "PURCHASE_ITEM")
        //        {
        //            foreach (var item in po.PurchaseItems)
        //            {
        //                item.PurchaseOrderId = pur.PurchaseOrderId;
        //                _context.PurchaseItem.Add(item);
        //            }
        //            po.PurchaseServices = null;
        //            _context.SaveChanges();
        //        }

        //        else if (po.PurchaseServices != null && po.PurchaseOrder != null && po.PurchaseOrder.PurchaseOrder_Type == "PURCHASE_SERVICE")
        //        {
        //            foreach (var service in po.PurchaseServices)
        //            {
        //                service.PurchaseOrderId = pur.PurchaseOrderId;
        //                _context.PurchaseService.Add(service);
        //            }
        //            po.PurchaseItems = null;
        //            _context.SaveChanges();
        //        }


        //        if (po.Requisitions != null)
        //        {
        //            Requisition existingRequisition = _context.Requisition.Find(po.Requisitions.RequisitionId);
        //            if (existingRequisition != null)
        //            {
        //                existingRequisition.Requisition_Status = "Purchasing Your Request";
        //                existingRequisition.Requisition_Status_Remarks = po.Requisitions.Requisition_Status_Remarks;

        //                _context.Update(existingRequisition);
        //                _context.SaveChanges();
        //            }
        //            return RedirectToAction("Home", "AdminHome");
        //        }

        //    }

        //    return BadRequest("PurchaseOrder cannot be null");

        //}


        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> CheckInventory(int id)
        {
            if (GetId() == null || _context.Admin == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var ri = _context.Requisition
                .Include(r => r.RequisitionItems)
                .ThenInclude(ri => ri.Inventory)
                .Include(r => r.Tenant)
                .FirstOrDefault(r => r.RequisitionId == id);

            if (ri == null)
            {
                return NotFound();
            }

            if (Request.Method == "POST")
            {
                var requisitionStatusRemarks = Request.Form["Requisition_Status_Remarks"];
                var submitType = Request.Form["submitType"];

                if (submitType == "SendItem")
                {

                    foreach (var requisitionItem in ri.RequisitionItems)
                    {
                        int remainingQuantity = requisitionItem.Inventory.Inventory_ItemQuantity - requisitionItem.Req_Item_Quantity.GetValueOrDefault();

                        if (remainingQuantity >= 0)
                        {
                            requisitionItem.Inventory.Inventory_ItemQuantity = remainingQuantity;
                            requisitionItem.Inventory.Inventory_Status = "Item Purchased";
                        }
                        else
                        {
                            requisitionItem.Inventory.Inventory_Status = "Item Need to Restock";
                        }
                    }
                    ri.Requisition_Status = "Approve: Preparing Your Item.";
                    ri.Requisition_Status_Remarks = requisitionStatusRemarks;

                    await _context.SaveChangesAsync();

                    return RedirectToAction("ManageRental", "AdminHome");

                }
            }

            return View(ri);
        }






    }
}
