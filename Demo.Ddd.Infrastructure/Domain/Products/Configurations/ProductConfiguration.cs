using Demo.Ddd.Domain.Products;
using Demo.Ddd.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Infrastructure.Domain.Products.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            //builder.Property(p => p.Code).HasMaxLength(5);
            //builder.Property(p => p.Name).HasMaxLength(50);

            builder.HasQueryFilter(p => p.Status != EntityStatus.Deleted);
        }
    }
}
