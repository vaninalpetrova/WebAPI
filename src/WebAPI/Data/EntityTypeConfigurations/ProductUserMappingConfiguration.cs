using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Data.EntityTypeConfigurations
{
    public class ProductUserMappingConfiguration : IEntityTypeConfiguration<ProductUserMapping>
    {
        public void Configure(EntityTypeBuilder<ProductUserMapping> builder)
        {
           builder.HasKey(pum => new { pum.ProductId, pum.UserId });

            builder.HasOne(pum => pum.Product)
                .WithMany(p => p.UserMapping)
                .HasForeignKey(pum => pum.ProductId);

            builder.HasOne(pum => pum.User)
                .WithMany(u => u.ProductMapping)
                .HasForeignKey(pum => pum.UserId);
        }
    }
}
