using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LovelyLocks.Data;
using LovelyLocks.Models;
using System;
using LovelyLocks.Models.ViewModels;

namespace LovelyLocks.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext dbcontext;

        public ProductsController(ProductDbContext context)
        {
            dbcontext = context;
        }

        //public ViewData Index(new ProductAdminViewModel);
        // GET: Products
        //        public async Task<IActionResult> Index(string sortOrder, string currentFilter,
        //            string searchString, int? page)
        //        {
        //            ViewData["CurrentSort"] = sortOrder;
        //            ViewData["CategorySortParm"] = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
        //            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";

//            if (searchString != null)
//            {
//                page = 1;
//            }
//            else
//            {
//                searchString = currentFilter;
//            }

//ViewData["CurrentFilter"] = searchString;

//            var products = from p in dbcontext.Products
//                           select p;
//            if (!String.IsNullOrEmpty(searchString))
//            {
//                products = products.Where(p => p.Name.Contains(searchString));

//            }
//            switch (sortOrder)
//            {
//                case "category_desc":
//                    products = products.OrderByDescending(p => p.Category);
//                    break;
//                case "Name":
//                    products = products.OrderBy(p => p.Name);
//                    break;
//                case "name_desc":
//                    products = products.OrderByDescending(p => p.Name);
//                    break;
//                default:
//                    products = products.OrderBy(p => p.Category);
//                    break;
//            }

//            int pageSize = 4;
//            //return View(await products.AsNoTracking().ToListAsync());
//            //return View(await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), page ?? 1, pageSize));


//        }

//        // GET: Products/Details/5
//        public async Task<IActionResult> Details(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var product = await dbcontext.Products.SingleOrDefaultAsync(m => m.ProductID == id);
//    if (product == null)
//    {
//        return NotFound();
//    }

//    return View(product);
//}

//// GET: Products/Create
//public IActionResult Create()
//{
//    return View();
//}

//// POST: Products/Create
//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create([Bind("ProductID,Category,Description,Name,Price")] Product product)
//{
//    if (ModelState.IsValid)
//    {
//        dbcontext.Add(product);
//        await dbcontext.SaveChangesAsync();
//        return RedirectToAction("Index");
//    }
//    return View(product);
//}

//// GET: Products/Edit/5
//public async Task<IActionResult> Edit(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var product = await dbcontext.Products.SingleOrDefaultAsync(m => m.ProductID == id);
//    if (product == null)
//    {
//        return NotFound();
//    }
//    return View(product);
//}

//// POST: Products/Edit/5
//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Edit(int id, [Bind("ProductID,Category,Description,Name,Price")] Product product)
//{
//    if (id != product.ProductID)
//    {
//        return NotFound();
//    }

//    if (ModelState.IsValid)
//    {
//        try
//        {
//            dbcontext.Update(product);
//            await dbcontext.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!ProductExists(product.ProductID))
//            {
//                return NotFound();
//            }
//            else
//            {
//                throw;
//            }
//        }
//        return RedirectToAction("Index");
//    }
//    return View(product);
//}

//// GET: Products/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var product = await dbcontext.Products.SingleOrDefaultAsync(m => m.ProductID == id);
//    if (product == null)
//    {
//        return NotFound();
//    }

//    return View(product);
//}

//// POST: Products/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    var product = await dbcontext.Products.SingleOrDefaultAsync(m => m.ProductID == id);
//    dbcontext.Products.Remove(product);
//    await dbcontext.SaveChangesAsync();
//    return RedirectToAction("Index");
//}

//private bool ProductExists(int id)
//{
//    return dbcontext.Products.Any(e => e.ProductID == id);
//}
    }
}