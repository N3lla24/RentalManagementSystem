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
            return RedirectToAction("Register", "Tenants");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser([Bind("Tenant_UserName,Tenant_Password")] Tenant tenant)
        {
            return RedirectToAction("Index", "TenantHome");
            /*if (tenant.Tenant_Password != null)
            {
                string hashpass = Hashing.HashPass(tenant.Tenant_Password);
                Tenant tenantregister = await _context.Tenant.SingleOrDefaultAsync(q => q.Tenant_UserName == tenant.Tenant_UserName && q.Tenant_Password == tenant.Tenant_Password); //Add Login Bootstrap in view
                if (tenantregister != null)
                {
                    ViewData["LoginErrorMessage"] = null;

                    string accountlogin = "Tenant " + tenantregister.TenantId + ": " + tenantregister.Tenant_UserName;
                    HttpContext.Session.SetString("accountlogin", accountlogin);

                    //if login success redirect to homepage for the user
                    return RedirectToAction("Index", "TenantHome");
                }
                ViewData["LoginErrorMessage"] = "Incorrect Usernae or Password";
                return View(Index);
            }
            ViewData["LoginErrorMessage"] = "Incorrect Usernae or Password";
            return View(Index);*/
        }
    }
}
