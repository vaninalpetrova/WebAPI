using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Areas.Admin.Controllers
{
    public class ServicePackageController : BaseAdminController
    {
        private readonly UserManager<User> userManager;

        public ServicePackageController(ApplicationDbContext context, UserManager<User> userManager)
            : base(context)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicePackage servicePackageModel)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(servicePackageModel);
            }

            //string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //servicePackageModel.UserId = currentUserId;

            await this.DbContext.ServicePackages.AddAsync(servicePackageModel);
            await this.DbContext.SaveChangesAsync();

            return RedirectToAction("All", "ServicePackage", new { area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var servicePackage = await this.DbContext.ServicePackages.FindAsync(id);

            if (servicePackage == null)
            {
                return RedirectToAction("All", "ServicePackage", new { area = "" });
            }

            return this.View(servicePackage);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ServicePackage servicePackageModel)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(servicePackageModel);
            }

            var servicePackage = await this.DbContext.ServicePackages.FindAsync(id);

            if (servicePackage == null)
            {
                return RedirectToAction("All", "ServicePackage", new { area = "" });
            }

            servicePackage.Name = servicePackageModel.Name;
            servicePackage.Description = servicePackageModel.Description;
            servicePackage.Price = servicePackageModel.Price;
            servicePackage.DurationTime = servicePackageModel.DurationTime;

            this.DbContext.ServicePackages.Update(servicePackage);
            await this.DbContext.SaveChangesAsync();

            return RedirectToAction("All", "ServicePackage", new { area = "" });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var servicePackage = await this.DbContext.ServicePackages.FindAsync(id);

            if (servicePackage == null)
            {
                return RedirectToAction("All", "ServicePackage", new { area = "" });
            }

            return this.View(servicePackage);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ServicePackage servicePackageModel)
        {
            var servicePackage = await this.DbContext.ServicePackages.FindAsync(id);

            if (servicePackage == null)
            {
                return RedirectToAction("All", "ServicePackage", new { area = "" });
            }

            this.DbContext.ServicePackages.Remove(servicePackage);
            await this.DbContext.SaveChangesAsync();

            return RedirectToAction("All", "ServicePackage", new { area = "" });
        }
    }
}
