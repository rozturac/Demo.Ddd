using Demo.Ddd.Domain.Baskets;
using Demo.Ddd.Domain.SeedWork;
using Demo.Ddd.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Infrastructure.Domain.Customers.Baskets.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.OwnsOne(p => p.Value, m =>
            {
                m.Property(p => p.Currency).HasConversion(o => o.Value, v => Enumeration.FromValue<Currency>(v)).HasColumnName("Currency");
                m.Property(p => p.Value).HasColumnName("Value");
            });

            builder.OwnsOne(p => p.ValueInEUR, m =>
            {
                m.Property(p => p.Currency).HasConversion(o => o.Value, v => Enumeration.FromValue<Currency>(v)).HasColumnName("CurrencyInEUR");
                m.Property(p => p.Value).HasColumnName("ValueInEUR");
            });
        }
    }
}
