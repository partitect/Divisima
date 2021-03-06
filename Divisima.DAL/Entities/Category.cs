﻿using System;
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

        [StringLength(30),Column(TypeName = "varchar(30)"),Required(ErrorMessage ="Kategori adı boş geçilemez"),Display(Name ="Kategori Adı")]
        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
