using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Resources
{
    public class SaveOrderResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerAddress { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        public List<int> ProductIDs { get; set; }
    }
}
