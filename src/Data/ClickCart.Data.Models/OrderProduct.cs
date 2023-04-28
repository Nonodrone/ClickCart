using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Data.Models
{
    public class OrderProduct : BaseEntity
    {
        public Product Product { get; set; }

        public Order Order { get; set; }

        public int ProductCount { get; set; }
    }
}
