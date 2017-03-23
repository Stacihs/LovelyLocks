using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using LovelyLocks.Data;

namespace LovelyLocks.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ProductDbContext dbcontext = app.ApplicationServices.GetRequiredService<ProductDbContext>();
            if(!dbcontext.Products.Any())
            {
                dbcontext.Products.AddRange(
                    new Product
                    {
                        Name = "Weaving Needle",
                        Description = "stainless steel needle",
                        Category = "Tools",
                        Price = 2
                    },
                    new Product
                    { Name = "10 inch Jumbo Braid",
                        Description = "100% synthetic hair",
                        Category = "Hair",
                        Price = 8
                    },
                    new Product
                    {
                        Name = "18 inch Black Wavy Hair",
                        Description = "100% Brazilian human hair",
                        Category = "Hair",
                        Price = 15
                    },
                    new Product
                    {
                        Name = "Hair Glue",
                        Description = "3 oz bottle of hair glue",
                        Category = "Upkeep",
                        Price = 2
                    },
                    new Product
                    {
                        Name = "Dry Shampoo",
                        Description = "Dry shampoo that absorbs oils",
                        Category = "Upkeep",
                        Price = 6
                    },
                    new Product
                    {
                        Name = "Thread",
                        Description = "Hair thread",
                        Category = "Tools",
                        Price = 2
                    }
                    );
                dbcontext.SaveChanges();
            }
        }
    }
}
