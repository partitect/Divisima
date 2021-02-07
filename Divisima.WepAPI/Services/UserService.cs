using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebAPI.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.WebAPI.Services
{
    public class UserService : IUserService
    {
       

        private readonly AppSettings _appSettings;
        WebRepository<User> _userRepo;
       
        public UserService(IOptions<AppSettings> appSettings, WebRepository<User> userRepo)
        {
            _userRepo = userRepo;
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string kullaniciAdi, string sifre)
        {
            var user = _userRepo.GetAll().FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre);

            // Kullanici bulunamadıysa null döner.
            if (user == null)
                return null;

            // Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // Sifre null olarak gonderilir.
            user.Sifre = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // Kullanicilar sifre olmadan dondurulur.
            //return _userRepo.Select(x => {
            //    x.Sifre = null;
            //    return x;
            //});
            return _userRepo.GetAll();
        }
    }
}
