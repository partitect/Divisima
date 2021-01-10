using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Divisima.DAL.Entities.Contexts
{
	public class WebContext:DbContext
	{
		public WebContext(DbContextOptions<WebContext> opt) : base(opt) { }

		public DbSet<Category> Category { get; set; }
		public DbSet<Slide> Slide { get; set; }
	}
}
