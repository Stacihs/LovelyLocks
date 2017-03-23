using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LovelyLocks.Models.ViewModels
{
    public class ProductAdminViewModel
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

        public string ReturnUrl { get; set; }
    }
}
