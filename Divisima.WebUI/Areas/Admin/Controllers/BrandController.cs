using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Areas.Admin.Controllers
{
	[Area("admin"), Route("/admin/[controller]/[action]"), Authorize]
	public class BrandController : Controller
	{
		WebRepository<Brand> brandRepo;

		public BrandController(WebRepository<Brand> _brandRepo)
		{
			brandRepo = _brandRepo;
		}

		public IActionResult Index()
		{
			return View(brandRepo.GetAll());
		}

		public IActionResult Edit(int id)
		{
			return View(brandRepo.GetBy(g => g.ID == id));
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Edit(Brand model)
		{
			if (ModelState.IsValid)
			{
				//brandRepo.Update(model, u => u.Name,u.Price);

				brandRepo.Update(model, u => u.Name);
				TempData["guncellemeBilgisi"] = model.Name + "Markası Başarıyla Güncellendi";
				return RedirectToAction("Index", "Brand");
			}
			else
			{
				return View(model);
			}
		}


		public IActionResult Insert()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Insert(Brand model)
		{
			if (ModelState.IsValid)
			{
				brandRepo.Add(model);
				TempData["guncellemeBilgisi"] = model.Name + "markası başarıyla eklendi";
				return RedirectToAction("Index");
			}
			else return View(model);
		}

		[HttpPost]
		public string Delete(int id)
		{
			Brand brand = brandRepo.GetBy(g => g.ID == id) ?? null;
			if (brand != null)
			{
				brandRepo.Remove(brand);
				return brand.Name;
			}
			else return "";
		}
	}
}
