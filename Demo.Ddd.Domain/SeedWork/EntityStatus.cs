using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.SeedWork
{
    public enum EntityStatus : byte
    {
        Deleted = 0,
        Active = 1,
        Passive = 2
    }
}