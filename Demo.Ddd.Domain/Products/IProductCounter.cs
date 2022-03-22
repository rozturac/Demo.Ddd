using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.Products
{
    public interface IProductCounter
    {
        int GetProductCountByCode(string productCode);
    }
}
