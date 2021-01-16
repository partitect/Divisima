using Divisima.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.ViewModels
{
	public class HomeVM
	{
		public List<Slide> Slides { get; set; }
		public List<Product> Products { get; set; }
		public List<Product> BestSellerProducts { get; set; }
		public List<Brand> Brands { get; set; }
	}
}
