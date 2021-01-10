using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
	[Table("Category")]
	public class Category
	{
		public int ID { get; set; }

		[StringLength(300),Column(TypeName ="varchar(30)"),Required(ErrorMessage ="Kategori Adı Boş Geçilemez"),Display(Name="Kategori Adı")]
		public string Name { get; set; }
	}
}
