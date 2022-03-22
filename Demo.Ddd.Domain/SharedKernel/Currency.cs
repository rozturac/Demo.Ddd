using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.SharedKernel
{
    public class Currency : Enumeration
    {
        public static readonly Currency TRY = new Currency(56, nameof(TRY));
        public static readonly Currency USD = new Currency(840, nameof(USD));
        public static readonly Currency EUR = new Currency(978, nameof(EUR));

        public Currency(int value, string name) : base(value, name)
        {
        }
    }
}
