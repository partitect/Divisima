using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Divisima.WebUI.Middlewares
{
	public class TestMiddleWare
	{
		RequestDelegate next;

		public TestMiddleWare(RequestDelegate _next)
		{
			next = _next;
		}

		public async Task Invoke(HttpContext context)
		{
			if (context.Request.Query["deneme"] == "test") context.Response.Redirect("/sepetim");
			else await next(context);
		}

	}
}
