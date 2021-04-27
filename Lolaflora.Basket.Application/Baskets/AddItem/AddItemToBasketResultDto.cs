using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Application.Baskets.AddItem
{
    public class AddItemToBasketResultDto
    {
        public Guid CustomerId { get; set; }
        public decimal Value { get; set; }
    }
}
