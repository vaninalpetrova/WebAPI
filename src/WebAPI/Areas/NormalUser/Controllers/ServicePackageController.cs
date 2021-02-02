using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Constants;
using WebAPI.Data;
using WebAPI.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Areas.NormalUser.Controllers
{
    public class ServicePackageController : BaseNormalUserController
    {
        private readonly UserManager<User> userManager;

        public ServicePackageController(ApplicationDbContext context, UserManager<User> userManager)
            : base(context)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> MyAll()
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await this.DbContext.Users.Include(u => u.ServicePackages).SingleOrDefaultAsync(u => u.Id == currentUserId);

            var userServicePackages = user.ServicePackages.ToArray();

            return this.View(userServicePackages);
        }

        public async Task<IActionResult> Buy(int servicePackageId)
        {

            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await this.DbContext.Users.FindAsync(currentUserId);


            var servicePackage = await this.DbContext.ServicePackages.FindAsync(servicePackageId);

            if (servicePackage == null)
            {
                return RedirectToAction("All", "ServicePackage", new { area = "" });
            }

            bool isAllreadtExist = user.ServicePackages.Any(s => s.Id == servicePackageId);

            if (isAllreadtExist)
            {
                return RedirectToAction("All", "ServicePackage", new { area = "" });
            }

            servicePackage.UserId = currentUserId;

            this.DbContext.ServicePackages.Update(servicePackage);
            await this.DbContext.SaveChangesAsync();

            return RedirectToAction("MyAll", "ServicePackage", new { area = GlobalConstants.UserArea });
        }
    }
}
