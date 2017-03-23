using System.Collections.Generic;
using LovelyLocks.Data;

namespace LovelyLocks.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ProductDbContext dbcontext;

        public EFProductRepository(ProductDbContext context)
        {
            dbcontext = context;
        }

        public IEnumerable<Product> Products => dbcontext.Products;
    }
}
