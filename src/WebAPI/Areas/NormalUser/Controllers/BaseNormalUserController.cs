using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Constants;
using WebAPI.Controllers;
using WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Areas.NormalUser.Controllers
{
    [Area(GlobalConstants.UserArea)]
    [Authorize(Roles = GlobalConstants.UserRole)]
    public abstract class BaseNormalUserController : BaseDatabaseController
    {
        protected BaseNormalUserController(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
