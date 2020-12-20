using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.DataModels;

namespace WebAPI.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        public ProductController(ApplicationDbContext context) 
            : base(context)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product productModel)
        {

            if (this.ModelState.IsValid == false)
            {
                return this.View(productModel);
            }

            await this.DbContext.Products.AddAsync(productModel);
            await this.DbContext.SaveChangesAsync();
            return RedirectToAction("All", "Product", new { area = "" });
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {

            var product = await this.DbContext.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("All", "Product", new { area = "" });
            }

            return this.View(product);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Product productModel)
        {

            if (this.ModelState.IsValid == false)
            {
                return this.View(productModel);
            }

            var product = await this.DbContext.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("All", "Product", new { area = "" });
            }

            product.Brand = productModel.Brand;
            product.Description = productModel.Description;
            product.ImageURL = productModel.ImageURL;
            product.Year = productModel.Year;
            product.Price = productModel.Price;
            product.Model = productModel.Model;

            this.DbContext.Products.Update(product);
            await this.DbContext.SaveChangesAsync();
            return RedirectToAction("All", "Product", new { area = "" });
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {

            var product = await this.DbContext.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("All", "product", new { area = "" });
            }
            return this.View(product);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id, Product productModel)
        {

            var product = await this.DbContext.Products.FindAsync(id);
            if (product == null)
            {
                return RedirectToAction("All", "Product", new { area = "" });
            }

            this.DbContext.Products.Remove(product);
            await this.DbContext.SaveChangesAsync();

            return RedirectToAction("All", "Product", new { area = "" });
        }
    }
}
