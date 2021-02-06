using Divisima.BL.Repositories;
using Divisima.DAL.Entities.Contexts;
using Divisima.WebUI.Middlewares;
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
using System.Text.Encodings.Web;
using System.Text.Unicode;
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
			services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA }));
			services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.Name);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//app.Run(async(context)=> {
			//	if (context.Request.Path == "/kurumsal")
			//	{
			//		await context.Response.WriteAsync("Hello World");
			//	}

			//});

			//app.Use(async (context, next) =>
			//{
			//	if (context.Request.Query["bilgi"] == "test")
			//	{
			//		context.Response.Redirect("/sepetim");
			//	}
			//	else
			//	{
			//		await next();
			//	}
			//});


			//app.Use(async (context, next) =>
			//{
			//	if (context.Request.Query["bilgi"] == "test" && !context.User.Identity.IsAuthenticated)
			//	{
			//		context.Response.Redirect("/sepetim");
			//	}
			//	else
			//	{
			//		await next();
			//	}
			//});

			//app.Use(async (context, next) =>
			//{
			//	if (context.Request.Query["bilgi"] == "test" && !context.User.Identity.IsAuthenticated && context.Request.Method == "POST")
			//	{
			//		context.Response.Redirect("/sepetim");
			//	}
			//	else
			//	{
			//		await next();
			//	}
			//});

			//app.Map("/kurumsal", mapping => mapping.Use(async (context,next) => {
			//	await context.Response.WriteAsync("Kurumsal Ýstendi");
			//}));

			//app.MapWhen(context => context.Request.IsHttps && context.Request.Host.Value.Contains(".com"), mapping => mapping.Use(async (context, next) =>
			//{
			//	context.Response.Redirect("https://teka.com");
			//}));

			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
			else app.UseStatusCodePagesWithReExecute("/hata", "?sCode={0}");

			app.UseStaticFiles();
			//app.UseSecurityMiddleware();
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
