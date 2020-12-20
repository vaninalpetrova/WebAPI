using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProductController : BaseDatabaseController
    {
        public ProductController(ApplicationDbContext context)
            : base(context)
        {
        }

        public IActionResult All()
        {
            var allProducts = this.DbContext.Products.ToArray();
            return View(allProducts);
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await this.DbContext.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("All", "Product", new { area = "" });
            }
            return this.View(product);
        }
    }
}
