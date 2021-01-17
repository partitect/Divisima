using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Controllers
{
	public class CategoryController : Controller
	{
		[Route("/category/{name}/{id}")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
