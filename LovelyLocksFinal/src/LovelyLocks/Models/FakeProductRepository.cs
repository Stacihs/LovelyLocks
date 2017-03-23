using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LovelyLocks.Models;

namespace LovelyLocks.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product {Name = "Needle", Price = 2},
            new Product {Name = "Thread", Price = 3},
            new Product {Name = "Hair", Price = 10},

        };
    }
}
