using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LovelyLocks.Data;


namespace LovelyLocks.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ProductDbContext dbcontext;

        public EFOrderRepository(ProductDbContext context)
        {
            dbcontext = context;
        }


        public IEnumerable<Order> Orders => dbcontext.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);


        public void SaveOrder(Order order)
        {
            dbcontext.AttachRange(order.Lines.Select(l => l.Product));

            if (order.OrderID == 0)
            {
                dbcontext.Orders.Add(order);
            }
            dbcontext.SaveChanges();
        }
    }
}
