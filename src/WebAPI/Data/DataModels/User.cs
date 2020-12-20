using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Data.DataModels
{
    public class User : IdentityUser
    {
        public User()
        {
            this.ProductMapping = new HashSet<ProductUserMapping>();
            this.ServicePackages = new HashSet<ServicePackage>();
        }

        public ICollection<ProductUserMapping> ProductMapping { get; set; }

        public ICollection<ServicePackage> ServicePackages { get; set; }
    }
}
