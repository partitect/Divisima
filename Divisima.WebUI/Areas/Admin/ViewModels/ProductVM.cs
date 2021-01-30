using Divisima.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Areas.Admin.ViewModels
{
	public class ProductVM
	{
		public Product Product { get; set; }
		public List<Brand> Brands { get; set; }
		public List<Category> Categories { get; set; }
		public List<ProductPicture> productPictures { get; set; }
		public int[] SelectedCategoryIDs{ get; set; }
	}
}
