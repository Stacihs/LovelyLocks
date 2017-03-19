using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LovelyLocks.Models
{
    public class Cart
    {
        [Key]
        public int TransactionID { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

    }
}
