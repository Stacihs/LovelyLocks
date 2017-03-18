using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LovelyLocks.Models
{
    public class Cart
    {
        [Key]
        public int TransactionID { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
