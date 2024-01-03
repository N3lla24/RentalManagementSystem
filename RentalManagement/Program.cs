using Microsoft.EntityFrameworkCore;
using RentalManagement.Data;
using RentalManagement.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RentalManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentalManagementContext") ?? throw new InvalidOperationException("Connection string 'RentalManagementContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(
    options => {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    }
    );

var app = builder.Build();
//Seeding Tenants, Suppliers, and Applicants
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedAdmin.Initialize(services);
    SeedTenant.Initialize(services);
    SeedSuppliers.Initialize(services);
    SeedApplicants.Initialize(services);
    SeedApplicantForms.Initialize(services);
    SeedInventory.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
