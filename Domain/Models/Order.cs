using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; }
        public string CustomerAddress { get; }
        public EPaymentMethod PaymentMethod { get; set; }
        //public IList<OrderDetail> OrderDetails { get; set; }
    }
}
