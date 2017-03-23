using Microsoft.EntityFrameworkCore;
using LovelyLocks.Models;

namespace LovelyLocks.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() { }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }   
}
