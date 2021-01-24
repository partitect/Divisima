using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.ViewModels
{
	public class CartVM
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
