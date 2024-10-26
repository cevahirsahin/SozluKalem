using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SozluKalem.Data.Context;
using System.Reflection;
using SozluKalem.Data.Extensions;
using SozluKalem.Service.Extensions;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.FileSystemGlobbing;
using SozluKalem.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using SozluKalem.Service.Describers;
using SozluKalem.Service.Services.Abstractions;
using SozluKalem.Service.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.LoadDataLayerExtension(builder.Configuration);
builder.Services.LoadServiceLayerExtension();
builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions(){
        PositionClass = ToastPositions.TopRight,
        TimeOut=3000,
        

    })
    .AddRazorRuntimeCompilation();


builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "SozluKalem",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan=TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();   
app.UseRouting();

app.UseAuthentication();    
app.UseAuthorization();
app.UseNToastNotify();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
      name:"Admin",
      areaName: "Admin",
      pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
      );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
