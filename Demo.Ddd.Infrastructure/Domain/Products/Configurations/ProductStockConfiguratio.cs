using Demo.Ddd.Domain.Products;
using Demo.Ddd.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Infrastructure.Domain.Products.Configurations
{
    public class ProductStockConfiguratio : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quentity).IsRequired();
            builder.Property(p => p.Status).IsRequired();

            builder.HasQueryFilter(p => p.Status != EntityStatus.Deleted);
        }
    }
}