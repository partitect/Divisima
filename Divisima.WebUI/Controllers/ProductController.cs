using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.Tools;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        [Route("/urun/sepeteekle")]
        public string AddCart(int id, string picture, int quantity)
        {
            Product product = productRepo.GetBy(g => g.ID == id);
            if (Request.Cookies["MyCart"] != null)
            {
                List<CartVM> cartVMs = JsonConvert.DeserializeObject<List<CartVM>>(Request.Cookies["MyCart"]);
                if (!cartVMs.Any(a => a.ID == id))
                {
                    cartVMs.Add(new CartVM { ID = product.ID, Name = product.Name, Picture = picture, Price = product.Price, Quantity = quantity });
                }
                else
                {
                    foreach (CartVM cartVM in cartVMs)
                    {
                        if (cartVM.ID == id) cartVM.Quantity += quantity;
                    }
                }

                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(cartVMs), cookieOptions);

            }
            else
            {
                List<CartVM> cartVMs = new List<CartVM> { new CartVM { ID = product.ID, Name = product.Name, Picture = picture, Price = product.Price, Quantity = quantity } };

                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(cartVMs), cookieOptions);
            }
            return product.Name;
        }
    }
}
