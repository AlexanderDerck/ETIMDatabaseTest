using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ETIMDatabase;
using ETIMDatabase.Entities;

namespace ETIMDatabaseTest
{
    class Program
    {
        const string xmlPath = @"C:\Users\Alexander Derck\Downloads\ETIM standard\etim 6 - international - e - ixf - endenl\Etim6.xml";
        const string xmlns = "http://www.etim-international.com/etimipx/1";

        static void Main(string[] args)
        {
            using (var ctx = new EtimDB())
            {
                var test = ctx.Classes.Where(c => c.Translations.Where(t => t.Language == Language.Dutch && !t.IsSynonym).Any(t => t.Description.Contains("LED")))
                    .Select(c => c.Translations.FirstOrDefault(t => !t.IsSynonym && t.Language == Language.Dutch).Description).ToList();
            }
        }
    }
}
