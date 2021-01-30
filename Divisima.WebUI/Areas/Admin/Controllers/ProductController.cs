using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Areas.Admin.Controllers
{
	[Area("admin"), Route("/admin/[controller]/[action]"), Authorize]
	public class ProductController : Controller
	{
		WebRepository<Product> productRepo;
		WebRepository<Brand> brandRepo;
		WebRepository<Category> categoryRepo;
		WebRepository<ProductCategory> productCategoryRepo;
		WebRepository<ProductPicture> productPictureRepo;

		public ProductController(WebRepository<Product> _productRepo, WebRepository<Brand> _brandRepo, WebRepository<Category> _categoryRepo, WebRepository<ProductCategory> _productCategoryRepo, WebRepository<ProductPicture> _productPictureRepo)
		{
			productRepo = _productRepo;
			brandRepo = _brandRepo;
			categoryRepo = _categoryRepo;
			productCategoryRepo = _productCategoryRepo;
			productPictureRepo = _productPictureRepo;
		}

		public IActionResult Index()
		{
			return View(productRepo.GetAll().Include(i=> i.ProductPictures).Include(i => i.Brand).Include(i => i.ProductCategories).ThenInclude(th => th.Category));
		}

		public IActionResult Edit(int id)
		{
			ProductVM productVM = new ProductVM
			{
				Product = productRepo.GetBy(g => g.ID == id),
				Brands = brandRepo.GetAll().ToList(),
				productPictures = productPictureRepo.GetAll().ToList(),
			};
			return View(productVM);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Edit(ProductVM model)
		{
			if (ModelState.IsValid)
			{
				productRepo.Update(model.Product, u1 => u1.Name, u2 => u2.BrandID);
				TempData["guncellemeBilgisi"] = model.Product.Name + "ürünü başarıyla güncellenedi";
				return RedirectToAction("Index");
			}
			else return View(model);
		}

		public IActionResult Insert()
		{
			ProductVM productVm = new ProductVM
			{
				Brands = brandRepo.GetAll().ToList(),
				Categories = categoryRepo.GetAll().ToList()
			};
			return View(productVm);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Insert(ProductVM model)
		{
			if (ModelState.IsValid)
			{
				productRepo.Add(model.Product);
				if (model.SelectedCategoryIDs != null)
				{
					for (int i = 0; i < model.SelectedCategoryIDs.Length; i++)
					{
						productCategoryRepo.Add(new ProductCategory
						{
							CategoryID = model.SelectedCategoryIDs[i],
							ProductID = model.Product.ID
						});
					}
				}
				if (Request.Form.Count() != null)
				{
					string pictureDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "product");
					if (Directory.Exists(pictureDir))
					{
						Directory.CreateDirectory(pictureDir);
					}
					for (int i = 0; i < HttpContext.Request.Form.Files.Count(); i++)
					{
						if (Request.Form.Files[i] != null)
						{
							string picturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "product", Request.Form.Files[i].FileName);
							using (var stream = new FileStream(picturePath, FileMode.Create))
							{
								Request.Form.Files[i].CopyTo(stream);
								productPictureRepo.Add(new ProductPicture
								{
									Name = "Resim" + i.ToString(),
									Path = "/img/product/" + Request.Form.Files[i].FileName,
									ProductID = model.Product.ID

								});
							}
						}
					}

				}
				TempData["guncellemeBilgisi"] = model.Product.Name + "markası başarıyla eklendi";
				return RedirectToAction("Index");
			}
			else return View(model);
		}

		[HttpPost]
		public string Delete(int id)
		{
			Product product = productRepo.GetBy(g => g.ID == id) ?? null;
			if (product != null)
			{
				productRepo.Remove(product);
				return product.Name;
			}
			else return "";
		}
	}
}
