using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Divisima.DAL.Entities.Contexts
{
	public class WebContext:DbContext
	{
		public WebContext(DbContextOptions<WebContext> opt) : base(opt) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasOne(o => o.Brand).WithMany(w => w.Products).OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<ProductCategory>().HasKey(hk => new { hk.ProductID, hk.CategoryID });
		}

		public DbSet<Category> Category { get; set; }
		public DbSet<Slide> Slide { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<Brand> Brand { get; set; }
		public DbSet<ProductCategory> ProductCategory { get; set; }
		public DbSet<Pages> Pages { get; set; }
		public DbSet<GeneralInfo> GeneralInfos { get; set; }
		public DbSet<City> City { get; set; }
		public DbSet<District> District { get; set; }

	}
}
