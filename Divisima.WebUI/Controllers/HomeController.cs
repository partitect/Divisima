using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		WebRepository<Product> productRepo;
		WebRepository<Brand> brandRepo;
		WebRepository<Pages> pagesRepo;
		WebRepository<City> cityRepo;
		WebRepository<District> districtRepo;







		public HomeController(WebRepository<Category> _categoryRepo, WebRepository<Slide> _slideRepo, WebRepository<Product> _productRepo, WebRepository<Brand> _brandRepo, WebRepository<Pages> _pagesRepo, WebRepository<City> _cityRepo, WebRepository<District> _districRepo)
		{
			categoryRepo = _categoryRepo;
			slideRepo = _slideRepo;
			productRepo = _productRepo;
			brandRepo = _brandRepo;
			pagesRepo = _pagesRepo;
			cityRepo = _cityRepo;
			districtRepo = _districRepo;

		}
		public IActionResult Index()
		{
			HomeVM homeVM = new HomeVM
			{
				Slides = slideRepo.GetAll().OrderBy(o=>o.DisplayIndex).ToList(),
				Products = productRepo.GetAll().Include(i=>i.ProductPictures).OrderBy(o => o.DisplayIndex).Take(6).ToList(),
				BestSellerProducts = productRepo.GetAll().Include(i => i.ProductPictures).OrderBy(o => Guid.NewGuid()).Take(8).ToList(),
				Brands = brandRepo.GetAll().Take(6).ToList(),
				Pageies = pagesRepo.GetAll().Where(a=> a.Type == 3).Take(3).ToList(),

				//Categories = categoryRepo.GetAll().ToList(),

			};
			return View(homeVM);
		}

		[Route("/sehirler")]
		public IActionResult getCities()
		{
			return Json(cityRepo.GetAll());
		}

		[Route("/ilceler")]
		public IActionResult getDistrict(int cityId)
		{
			return Json(districtRepo.GetAll(g=> g.CityID == cityId));
		}
	}
}
