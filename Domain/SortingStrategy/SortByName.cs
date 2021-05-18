using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.SortingStrategy
{
    public class SortByName : ISorting
    {
        public void ProductSort(ref List<Product> productList)
        {
            productList.Sort(delegate (Product a, Product b)
                             {
                                 return a.Name.CompareTo(b.Name);
                             });
        }
    }
}
