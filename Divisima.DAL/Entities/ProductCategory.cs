using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Divisima.DAL.Entities
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        //[Key,Column(Order =1)]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        //[Key, Column(Order = 2)]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
