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
		WebRepository<Pages> pagesRepo;

		public HeaderViewComponent(WebRepository<Pages> _pagesRepo)
		{
			pagesRepo = _pagesRepo;
			

		}

		public IViewComponentResult Invoke()
		{
			HeaderVM homeVM = new HeaderVM
			{

				Pageies = pagesRepo.GetAll().ToList(),

			};
			return View(homeVM);
		}
	}
}
