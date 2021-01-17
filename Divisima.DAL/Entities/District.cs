using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("District")]
    public class District
    {
        public int ID { get; set; }

        [StringLength(50), Column(TypeName = "Varchar(50)"), Display(Name = "İlçe Adı"), Required(ErrorMessage = "İlçe Adı boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Şehir")]
        public int CityID { get; set; }

        public City City { get; set; }
    }

}
