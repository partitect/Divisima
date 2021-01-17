using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Areas.Admin.Controllers
{
	[Area("admin")]
	//[Authorize]
	public class HomeController : Controller
	{
		[Route("/admin")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
