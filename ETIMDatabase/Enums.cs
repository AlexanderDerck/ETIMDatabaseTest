using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase
{
    public enum Language : byte
    {
        Default = 0,
        Dutch = 0,
        French = 1,
        English = 2,
    }

    public enum ClassStatusType : byte
    {
        Defined,
        UnderConstruction,
        ReadyForPublication,
        Published,
    }

    public enum FeatureType : byte
    {
        Alphanumeric,
        Numeric,
        Range,
        Logical,
    }
}
