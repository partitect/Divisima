using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		WebRepository<Category> categoryRepo;

		public HeaderViewComponent(WebRepository<Category> _categoryRepo)
		{
			categoryRepo = _categoryRepo;
			

		}

		public IViewComponentResult Invoke()
		{
			HeaderVM homeVM = new HeaderVM
			{
				
				Categories = categoryRepo.GetAll().ToList(),

			};
			return View(homeVM);
		}
	}
}
