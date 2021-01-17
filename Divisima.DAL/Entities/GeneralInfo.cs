using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("GeneralInfo")]
    public class GeneralInfo
    {
        public int ID { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Başlık")]
        public string Title { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Column(TypeName = "text"), Display(Name = "Detay")]
        public string Detail { get; set; }

        [StringLength(20), Column(TypeName = "varchar(20)"), Display(Name = "Filtre")]
        public string Filter { get; set; }
    }
}
