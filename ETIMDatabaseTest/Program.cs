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
            //var serializer = new XmlSerializer(typeof(IXFType));

            //using (var fs = new FileStream(xmlPath, FileMode.Open))
            //{
            //    var ixf = (IXFType)serializer.Deserialize(fs);
            //    var featureTranslations = ixf.Features.Where(f => f.Translations.Any(feat => feat.Description.Contains("LED"))).ToList();
            //}

            //var bmecatns = "http://www.etim-international.com/bmecat/31";
            //var legrande = @"C:\Users\Alexander Derck\Downloads\Etiml product lists/20160122_LegrandBelgiumBMEcat_v22_ETIM6.xml";
            //var unibright = @"C:\Users\Alexander Derck\Downloads\Etiml product lists/Unibright_2016-12-12.xml";
            //var serializer = new XmlSerializer(typeof(BMECAT), bmecatns);

            //using(var fs = new FileStream(unibright, FileMode.Open))
            //{
            //    var bmecat = (BMECAT)serializer.Deserialize(fs);
            //}

            using (var ctx = new EtimDB())
            {
            }
        }
    }
}
