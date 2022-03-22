using System;
using System.Collections.Generic;
using System.Text;
using Demo.Ddd.Domain.SharedKernel;

namespace Demo.Ddd.Application.Baskets.AddItem
{
    public class AddItemToBasketResultDto
    {
        public Guid CustomerId { get; set; }
        public MoneyValue Value { get; set; }
    }
}
