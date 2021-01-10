using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Controllers
{
	public class HomeController : Controller
	{
		WebRepository<Category> categoryRepo;
		WebRepository<Slide> slideRepo;


		public HomeController(WebRepository<Category> _categoryRepo, WebRepository<Slide> _slideRepo)
		{
			categoryRepo = _categoryRepo;
			slideRepo = _slideRepo;

		}
		public IActionResult Index()
		{
			HomeVM homeVM = new HomeVM
			{
				Slides = slideRepo.GetAll().ToList(),
				Categories = categoryRepo.GetAll().ToList(),

			};
			return View(homeVM);
		}
	}
}
