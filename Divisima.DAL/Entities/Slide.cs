using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("Slide")]
    public class Slide
    {
        public int ID { get; set; }

        [StringLength(100),Column(TypeName = "varchar(100)"),Display(Name ="Slayt Başlığı")]
        public string Title { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Slayt Açıklaması")]
        public string Description { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Slayt Resim Dosyası")]
        public string Image { get; set; }

        [Display(Name = "Fiyat Bilgisi")]
        public decimal Price { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Slayt Linki")]
        public string Link { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }
    }
}
