using Divisima.BL.Repositories;
using Divisima.DAL.DbContexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MSSQLDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlBaglanti")));


builder.Services.AddScoped(typeof(MSSQLRepo<>));

builder.Services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA }));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
	opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
	opt.LoginPath = "/admin/giris";
	opt.LogoutPath = "/";
});




var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseStatusCodePages();
else app.UseStatusCodePagesWithReExecute("/hata/{0}");

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");

app.MapControllerRoute(name : "areas", pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.Run();
