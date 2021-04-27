using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Products
{
    public interface IProductCounter
    {
        int GetProductCountByCode(string productCode);
    }
}
