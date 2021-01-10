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
		public List<Category> Categories { get; set; }
		
	}
}
