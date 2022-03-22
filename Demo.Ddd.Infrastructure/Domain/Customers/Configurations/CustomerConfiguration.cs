using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Infrastructure.Domain.Customers.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.CustomerStatus).HasConversion(o => o.Value, v => Enumeration.FromValue<CustomerStatus>(v));

            builder.HasQueryFilter(p => p.Status != EntityStatus.Deleted);
        }
    }
}
