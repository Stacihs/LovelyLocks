using LovelyLocks.Models;
using Microsoft.EntityFrameworkCore;

namespace LovelyLocks.Data
{

    public class ProductDbContext : DbContext
    {
        public ProductDbContext() {}

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) { }


        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}

