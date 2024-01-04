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

        public IActionResult RegisterAccount()
        {
            return RedirectToAction("Create", "Tenants");
        }

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
