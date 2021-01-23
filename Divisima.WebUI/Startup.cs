using Divisima.BL.Repositories;
using Divisima.DAL.Entities.Contexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Divisima.WebUI
{
	public class Startup
	{


		IConfiguration configuration;
		public Startup(IConfiguration _configuration)
		{
			configuration = _configuration;
		}


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddDbContext<WebContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("WebCs")));
			services.AddScoped(typeof(WebRepository<>));
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
			{
				opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
				opt.LoginPath = "/admin/login";
				opt.LogoutPath = "/admin/logout";
				opt.AccessDeniedPath = "/admin/login?access=denied";
			});
			services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.Name);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
			else app.UseStatusCodePagesWithReExecute("/hata", "?sCode={0}");

			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(name: "areas", pattern: "{area:exist}/{controller=Home}/{action=Index}/{id?}");
				endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
