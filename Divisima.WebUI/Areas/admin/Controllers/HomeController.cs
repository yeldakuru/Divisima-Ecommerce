using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;

namespace Divisima.WebUI.Areas.admin.Controllers
{
	[Area("admin"), Authorize]
	public class HomeController : Controller
	{
		MSSQLRepo<Admin> repoAdmin;
        public HomeController(MSSQLRepo<Admin> _repoAdmin)
        {
            repoAdmin = _repoAdmin;
        }

        [Route("/admin")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("/admin/giris"), AllowAnonymous]
		public IActionResult Login(string ReturnUrl)
		{
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}


        [Route("/admin/giris"), AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string ReturnUrl, string username, string password, bool remember)
        {
			Admin admin = repoAdmin.GetBy(g => g.UserName == username && g.Password == GeneralTool.getMD5(password)) ?? null;

            if (admin != null)
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity("Divisima");
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, admin.Name + " " + admin.Surname)); // Admin bilgileri
                claimsIdentity.AddClaim(new Claim(ClaimTypes.PrimarySid, admin.ID.ToString())); // Admin ID

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
                claimsPrincipal.AddIdentity(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties() { IsPersistent = remember });

                if (string.IsNullOrEmpty(ReturnUrl)) return Redirect("/admin");
                else return Redirect(ReturnUrl);
            }

            else ViewBag.hataMesaji = "Hatalı Kullanıcı Adı Veya Şifre";
            return View();
        }

        [Route("/admin/cikis")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/admin");
        }
    }
}
