using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Data.Models
{
    public class Product : BaseEntity
    {
        public String Name { get; set; }

        public float Price { get; set; }
        
        public String ImageUrl { get; set; }

        public String Description { get; set; }

        public ProductCategory Category { get; set; }
    }
}