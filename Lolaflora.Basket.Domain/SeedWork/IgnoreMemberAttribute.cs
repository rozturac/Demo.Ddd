using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.SeedWork
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class IgnoreMemberAttribute : Attribute
    {

    }
}