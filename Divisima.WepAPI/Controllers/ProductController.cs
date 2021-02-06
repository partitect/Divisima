using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WepAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{

		WebRepository<Product> productRepo;
		public ProductController(WebRepository<Product> _productRepo)
		{
			productRepo = _productRepo;
		}

		[Route("/api/urunler")]
		public IEnumerable<Product> Urunler()
		{
			return productRepo.GetAll();
		}

		[Route("/api/bayi/urunler")]
		public IEnumerable<Product> BayiUrunler()
		{
			return productRepo.GetAll(g=> g.Price < 100);
		}
	}
}
