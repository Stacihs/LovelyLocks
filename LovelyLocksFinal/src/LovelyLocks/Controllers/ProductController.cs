using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LovelyLocks.Models;
using LovelyLocks.Models.ViewModels;

namespace LovelyLocks.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        //Get List of Products
        public ViewResult List(string category, int page = 1) => View(new ProductsListViewModel
            { Products = repository.Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null?
                        repository.Products.Count():
                        repository.Products.Where(e => e.Category == category).Count()
                },
            CurrentCategory = category

            });
    }
}
