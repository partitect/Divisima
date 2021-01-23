using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Areas.Admin.Controllers
{
	public class ProductController : Controller
	{
		[Area("admin"), Route("/admin/urunler"), Authorize]
		public IActionResult Index()
		{
			return View();
		}
	}
}
