using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Divisima.BL.Repositories;
using Divisima.WebUI.Tools;
using System.IdentityModel.Tokens.Jwt;

namespace Divisima.WebUI.Areas.Admin.Controllers
{
	[Area("admin"), Route("/admin/[controller]/[action]"), Authorize]
	//[Authorize]
	public class HomeController : Controller
	{
		WebRepository<Divisima.DAL.Entities.Admin> adminRepo;

		public HomeController(WebRepository<Divisima.DAL.Entities.Admin> _adminRepo)
		{
			adminRepo = _adminRepo;
		}

		[Route("/admin")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("/admin/login"), AllowAnonymous]
		public IActionResult Login(string ReturnUrl)
		{
			ViewBag.ReturnUrl = ReturnUrl;
			if (HttpContext.User.Identity.IsAuthenticated)
			{
				if (Url.IsLocalUrl(ViewBag.ReturnUrl))
					return Redirect(ViewBag.ReturnUrl);

				return RedirectToAction("Index");
			}
			else
			{
				return View();

			}
		}

		[Route("/admin/login"), AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(Divisima.DAL.Entities.Admin model,string ReturnUrl)
		{
			ViewBag.ReturnUrl = ReturnUrl;
			string password = GeneralTool.getMD5(model.Password);
			Divisima.DAL.Entities.Admin admin = adminRepo.GetBy(g => g.EmailAddress == model.EmailAddress && g.Password == password) ?? null;
			if (admin != null)
			{
				JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
				ClaimsIdentity claimsIdentity = new ClaimsIdentity("DivisimaAuthentitation");
				claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, model.EmailAddress));
				claimsIdentity.AddClaim(new Claim(ClaimTypes.PrimarySid, model.ID.ToString()));
				claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, admin.Name + " " + admin.Surname));

				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties() { IsPersistent = true });
				if (Url.IsLocalUrl(ViewBag.ReturnUrl))
					return Redirect(ViewBag.ReturnUrl);


				return RedirectToAction("Index");

			}
			else
			{
				ViewBag.hata = "Kullanıcı Bulunamadı!";
				return View(model);
			}

		}

		[Route("/admin/logout")]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index");
		}
	}
}
