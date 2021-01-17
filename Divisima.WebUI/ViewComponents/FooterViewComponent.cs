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
	public class FooterViewComponent:ViewComponent
	{
		WebRepository<Pages> pagesRepo;

		public FooterViewComponent(WebRepository<Pages> _pagesRepo)
		{
			pagesRepo = _pagesRepo;


		}

		public IViewComponentResult Invoke()
		{
			FooterVM footerVM = new FooterVM
			{

				FooterPages = pagesRepo.GetAll().ToList(),

			};
			return View(footerVM);
		}
	}
}
