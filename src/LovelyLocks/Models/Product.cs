using System.ComponentModel.DataAnnotations;

namespace LovelyLocks.Models
{
    public class Product
    {
       
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }

    }
}
