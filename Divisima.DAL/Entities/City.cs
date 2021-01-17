using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("City")]
    public class City
    {
        public int ID { get; set; }

        [StringLength(50), Column(TypeName = "Varchar(50)"), Display(Name = "Şehir Adı"), Required(ErrorMessage = "Şehir Adı boş geçilemez")]
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }
    }

}
