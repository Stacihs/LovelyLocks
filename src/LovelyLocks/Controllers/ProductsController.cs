using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LovelyLocks.Data;
using LovelyLocks.Models;
using LovelyLocks.Infrastructure;

namespace LovelyLocks.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;    
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder, string currentFilter,
            string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CategorySortParm"] = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "Name";
            ViewData["DescriptionSortParm"] = sortOrder == "description" ? "description_desc" : "Description";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var product = from p in _context.Product
                        select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.Category.Contains(searchString)
                || p.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "category_desc":
                    product = product.OrderByDescending(p => p.Category);
                    break;
                case "name":
                    product = product.OrderBy(p => p.Name);
                    break;

                case "name_desc":
                    product = product.OrderByDescending(p => p.Name);
                    break;
                case "description":
                    product = product.OrderBy(s => s.Description);
                    break;

                case "description_desc":
                    product = product.OrderByDescending(p => p.Description);
                    break;
                default:
                    product = product.OrderBy(p => p.ProductId);
                    break;

            }

            int pageSize = 20;
            return View(await PaginatedList<Product>.CreateAsync(product.AsNoTracking(), page ?? 1, pageSize));


        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Category,Description,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Category,Description,Name,Price")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ProductId == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
