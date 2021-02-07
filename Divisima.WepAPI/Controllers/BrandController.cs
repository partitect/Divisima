using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Divisima.WepAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        WebRepository<Brand> brandRepo;
        public BrandController(WebRepository<Brand> _brandRepo)
        {
            brandRepo = _brandRepo;
        }

        [HttpGet]
        public IEnumerable<Brand> Getir()
        {
            return brandRepo.GetAll().OrderBy(o=> o.Name);
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return brandRepo.GetBy(g => g.ID == id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public string Post(Brand model)
        {
            string rtn = "";
            try
            {
                brandRepo.Add(model);
                rtn = model.Name + " markası eklendi...";
            }
            catch (Exception ex)
            {
                rtn = "Bir hata oluştu, açıklaması: " + ex.Message;
            }
            return rtn;
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public string Put(int id, Brand model)
        {
            string rtn = "";
            try
            {
                Brand b = brandRepo.GetBy(g => g.ID == id) ?? null;
                if (b != null)
                {
                    b.Name = model.Name;
                    brandRepo.Update(b);
                    rtn = model.Name + " markası güncellendi...";
                }
                else rtn = "Marka bulunamadı...";
            }
            catch (Exception ex)
            {
                rtn = "Bir hata oluştu, açıklaması: " + ex.Message;
            }
            return rtn;
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string rtn = "";
            try
            {
                Brand b = brandRepo.GetBy(g => g.ID == id) ?? null;
                if (b != null)
                {
                    brandRepo.Remove(b);
                    rtn = b.Name + " markası silindi...";
                }
                else rtn = "Marka Bulunamadı...";
            }
            catch (Exception ex)
            {
                rtn = "Bir hata oluştu, açıklaması: " + ex.Message;
            }
            return rtn;
        }
    }

    //[HttpGet]
    //[Route("/markalar")]
    //public IEnumerable<Brand> Getir(string sort, string filtre)
    //{
    //    if (!string.IsNullOrEmpty(sort))
    //    {
    //        var sortProperty = typeof(Brand).GetProperty(sort.Replace("desc_", ""));//desc_price
    //        if (sort.IndexOf("desc_") != -1) return brandRepo.GetAll().AsEnumerable().OrderByDescending(o => sortProperty.GetValue(o));
    //        else return brandRepo.GetAll().AsEnumerable().OrderBy(o => sortProperty.GetValue(o));
    //    }
    //}

}
