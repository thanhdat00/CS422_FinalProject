using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int PriceAtCheckOut { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
