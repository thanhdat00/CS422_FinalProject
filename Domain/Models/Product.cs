using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }

        public int Price { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public short Rating { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<OrderDetail> OrderDetailsList { get; set; }
    }
}