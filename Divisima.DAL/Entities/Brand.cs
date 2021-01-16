using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("Brand")]
    public class Brand
    {
        public int ID { get; set; }

        [StringLength(30),Column(TypeName = "varchar(30)"),Required(ErrorMessage ="Marka adı boş geçilemez"),Display(Name = "Marka Adı")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
