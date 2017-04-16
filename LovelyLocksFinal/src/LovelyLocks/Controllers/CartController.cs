using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LovelyLocks.Models;
using LovelyLocks.Models.ViewModels;

namespace LovelyLocks.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        
        {
            repository = repo;
            cart = cartService;
        }


        //Get Cart
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        //Add a product to cart
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //Remove item from cart
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);

            }

                return RedirectToAction("Index", new { returnUrl });
        }
    }
}
