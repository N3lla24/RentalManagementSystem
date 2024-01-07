using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;
using RentalManagement.Services;


namespace RentalManagement.Controllers
{
    public class Login : Controller
    {
        private readonly RentalManagementContext _context;

        public Login(RentalManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ForgotPass()
        {
            return View();
        }

        //Recover Process
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Recover([Bind("Tenant_Email, Tenant_PhoneNumber, Tenant_RoomNumber, Tenant_UnitNumber, Tenant_Password")] Tenant tenant)
        {
            Tenant existingacc = await _context.Tenant.FirstOrDefaultAsync(q => q.Tenant_Email == tenant.Tenant_Email && q.Tenant_PhoneNumber == tenant.Tenant_PhoneNumber && q.Tenant_RoomNumber == tenant.Tenant_RoomNumber && q.Tenant_UnitNumber == tenant.Tenant_UnitNumber);

            if (existingacc != null)
            {
                string hashpass = Hashing.HashPass(tenant.Tenant_Password);
                existingacc.Tenant_Password = hashpass;
                try
                {
                    _context.Update(existingacc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (existingacc == null)
                    {
                        ViewData["Success"] = null;
                        ViewData["Errormessage"] = "Not Found";
                        return View("ForgotPass");
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["Success"] = "success";
                ViewData["Errormessage"] = null;
                return View("ForgotPass");
            }
            ViewData["Success"] = null;
            ViewData["Errormessage"] = "Not Found";
            return View("ForgotPass");
        }

        public IActionResult RegisterAccount()
        {
            return RedirectToAction("Create", "Tenants");
        }

        //Login Checking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Tenant tenant)
        {
            /*return RedirectToAction("Index", "TenantHome");*/
            if (tenant.Tenant_Password != null && tenant.Tenant_UserName != null)
            {
                string hashpass = Hashing.HashPass(tenant.Tenant_Password);
                Tenant loginuser = await _context.Tenant.SingleOrDefaultAsync(q => q.Tenant_UserName == tenant.Tenant_UserName && q.Tenant_Password == hashpass);
                if (loginuser != null)
                {
                    ViewData["LoginErrorMessage"] = null;

                    HttpContext.Session.SetInt32("accountid", loginuser.TenantId);

                    return RedirectToAction("Index", "TenantHome");
                }
                ViewData["LoginErrorMessage"] = "Incorrect Username or Password";
                return View(tenant);
            }
            ViewData["LoginErrorMessage"] = "Incorrect Username or Password";
            return View(tenant);
        }
    }
}
