using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("ProductPicture")]
    public class ProductPicture
    {
        public int ID { get; set; }

        [StringLength(30),Column(TypeName = "varchar(30)"),Required(ErrorMessage ="Resim adı boş geçilemez"),Display(Name = "Resim Adı")]
        public string Name { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Resim Dosyası Yolu")]
        public string Path { get; set; }

        [Display(Name = "Ürün Bilgisi")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
