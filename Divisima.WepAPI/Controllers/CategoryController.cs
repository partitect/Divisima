using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WepAPI.Controllers
{
	[ApiController]
	public class CategoryController : ControllerBase
	{

		WebRepository<Category> categoryRepo;
		public CategoryController(WebRepository<Category> _categoryRepo)
		{
			categoryRepo = _categoryRepo;
		}
		/// <summary>
		///	Tüm Kategorileri Getirir
		/// </summary>
		/// <returns></returns>
		[Route("/api/kategoriler")]
		public IActionResult getAll()
		{
			try
			{
				return Ok(categoryRepo.GetAll());
			}
			catch (Exception)
			{

				return NoContent();
			}
			
		}

		[Route("/api/kategori/{id}")]
		public IActionResult getByID(int id)
		{
			Category c = categoryRepo.GetBy(g => g.ID == id) ?? null;
			if (c != null)
			{
				return Ok(c);
			}
			return NotFound();
		}

		[HttpPost,Route("/api/kategori")]
		public IActionResult Add(Category model)
		{
			if (ModelState.IsValid)
			{
				categoryRepo.Add(model);
				return Ok(model);
			}
			else
			{
				return BadRequest(model);
			}
		
		}

		[HttpDelete, Route("/api/kategori/{id}")]
		public IActionResult Delete(int id)
		{
			Category c = categoryRepo.GetBy(g => g.ID == id) ?? null;
			if (c != null)
			{
				categoryRepo.Remove(c);
				return Ok(c);
			}
			return NotFound();

		}
		[HttpPut, Route("/api/kategori")]
		public IActionResult Update(Category model)
		{
			if (ModelState.IsValid)
			{
				categoryRepo.Update(model);
				return Ok(model);
			}
			return BadRequest(model);
		}
	}
}
