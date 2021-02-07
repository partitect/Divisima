using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Divisima.DAL.Entities;
using Divisima.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous, HttpPost, Route("/users/authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            var user = _userService.Authenticate(userParam.KullaniciAdi, userParam.Sifre);
            if (user == null) return BadRequest(new { message = "Kullanici veya şifre hatalı!" });
            return Ok(user);
        }

        [HttpGet, Route("/users/all")]
        public IActionResult GetAll()
        {

            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
