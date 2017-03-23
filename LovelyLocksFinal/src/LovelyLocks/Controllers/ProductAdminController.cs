using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LovelyLocks.Data;
using LovelyLocks.Models;
using Microsoft.AspNetCore.Authorization;

namespace LovelyLocks.Controllers
{
    [Authorize]
    public class ProductAdminController : Controller
    {
        private readonly ProductDbContext dbcontext;

        public ProductAdminController(ProductDbContext context)
        {
            dbcontext = context;    
        }

        // GET: ProductAdmin
        public async Task<IActionResult> Index()
        {
            return View(await dbcontext.Products.ToListAsync());
        }

        // GET: ProductAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await dbcontext.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Category,Description,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                dbcontext.Add(product);
                await dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: ProductAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await dbcontext.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Category,Description,Name,Price")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbcontext.Update(product);
                    await dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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

        // GET: ProductAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await dbcontext.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await dbcontext.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            dbcontext.Products.Remove(product);
            await dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return dbcontext.Products.Any(e => e.ProductID == id);
        }
    }
}
