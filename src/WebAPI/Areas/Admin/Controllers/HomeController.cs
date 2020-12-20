using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;

namespace WebAPI.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public HomeController(ApplicationDbContext context) 
            : base(context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
