using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }

        [StringLength(100),Column(TypeName ="Varchar(100)"),Required(ErrorMessage ="Ürün Adı Gerekli"),Display(Name ="Ürün Adı")]
        public string Name { get; set; }

        [Display(Name = "Fiyatı"), Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Stok Miktarı")]
        public int Stock { get; set; }

        [Column(TypeName = "text"), Display(Name = "Ürün Açıklaması")]
        public string Detail { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }

        [Display(Name = "Markası")]
        public int? BrandID { get; set; }
        public Brand Brand { get; set; }

        public List<ProductPicture> ProductPictures { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
