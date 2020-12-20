using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Constants;
using WebAPI.Data;
using WebAPI.Data.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Areas.NormalUser.Controllers
{
    public class UserController : BaseNormalUserController
    {
        private readonly UserManager<User> userManager;

        public UserController(ApplicationDbContext context, UserManager<User> userManager)
            : base(context)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Buy(int productId)
        {
            var product = await this.DbContext.Products.FindAsync(productId);

            if (product == null)
            {
                return RedirectToAction("All", "Product", new { area = "" });
            }

            var newUserProduct = new ProductUserMapping();
            newUserProduct.ProductId = productId;
            newUserProduct.UserId = this.userManager.GetUserId(this.User);

            if (newUserProduct.UserId == null)
            {
                return RedirectToAction("All", "Product", new { area = "" });
            }
            bool isAllreadtExist = this.DbContext.ProductsUsersMapping
                .Any(pum => pum.ProductId == newUserProduct.ProductId && pum.UserId == newUserProduct.UserId);

            if (isAllreadtExist)
            {
                return RedirectToAction("All", "Product", new { area = "" });
            }

            await this.DbContext.ProductsUsersMapping.AddAsync(newUserProduct);
            await this.DbContext.SaveChangesAsync();

            return RedirectToAction("MyAll", "User", new { area = GlobalConstants.UserArea });
        }

        public async Task<IActionResult> MyAll()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            var userProducts = this.DbContext.Products
                .Where(product => product.UserMapping.Select(u => u.UserId).Contains(currentUser.Id))
                .ToArray();

            return this.View(userProducts);
        }
    }
}
