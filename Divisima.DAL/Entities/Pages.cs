using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("MenuPages")]
    public class Pages
    {
        public int ID { get; set; }

        [StringLength(30),Column(TypeName = "varchar(30)"),Required(ErrorMessage = "Sayfa adı boş geçilemez"),Display(Name ="Sayfa Adı")]
        public string Name { get; set; }

        [StringLength(500), Column(TypeName = "varchar(500)"), Display(Name = "Sayfa Bağlantısı")]
        public string Link { get; set; }

        [Column(TypeName = "text"), Display(Name = "Sayfa Açıklaması")]
        public string Desc { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Link Icon")]
        public string Icon { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Link Statusu")]
        public string Status { get; set; }

        public int Type { get; set; }
        public int? ParentId { get; set; }
        public int DisplayIndex { get; set; }
        public int? ShowCount { get; set; }


    }
}
