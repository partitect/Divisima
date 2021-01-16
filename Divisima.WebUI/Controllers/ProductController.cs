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
	public class ProductController : Controller
	{
        WebRepository<Product> productRepo;
        public ProductController(WebRepository<Product> _productRepo)
        {
            productRepo = _productRepo;
        }

        [Route("/urun/{name}/{id}")]
        public IActionResult Detail(string name, int id)
        {
            Product p = productRepo.GetAll(g => g.ID == id && g.Name == name).Include(i => i.ProductPictures).FirstOrDefault();
            ProductVM productVM = new ProductVM
            {
                Product = p,
                RelatedProducts = productRepo.GetAll(g => g.BrandID == p.BrandID && g.ID != p.ID).Include(i => i.ProductPictures).ToList()
            };
            return View(productVM);
        }
    }
}
