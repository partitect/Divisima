using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.Tools;
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
        WebRepository<GeneralInfo> ginfoRepo;

        public ProductController(WebRepository<Product> _productRepo, WebRepository<GeneralInfo> _ginfoRepo)
        {
            productRepo = _productRepo;
            ginfoRepo = _ginfoRepo;
        }

        [Route("/urun/{name}/{id}")]
        public IActionResult Detail(string name, int id)
        {
            Product p = productRepo.GetAll().Include(i => i.ProductPictures).Include(i => i.Brand).AsEnumerable().Where(g => g.ID == id && GeneralTool.KarakterDuzelt(g.Name) == name).FirstOrDefault();
            ProductVM productVM = new ProductVM
            {
                Product = p,
                RelatedProducts = productRepo.GetAll(g => g.BrandID == p.BrandID && g.ID != p.ID).Include(i => i.ProductPictures).ToList()
            };
            return View(productVM);
        }

        [Route("/bilgi")]
        public string GetCareDetail(string filter)
		{
            return ginfoRepo.GetBy(g => g.Filter == filter).Detail;

        }
    }
}
