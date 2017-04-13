using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtimIXF;

namespace ETIMDatabase.Entities
{
    public class EtimUnitTranslation
    {
        public EtimUnitTranslation() { }
        public EtimUnitTranslation(UnitTranslationType xmlUnitTranslation)
        {
            Description = xmlUnitTranslation.Description;
            Language = xmlUnitTranslation.language.GetLanguage();
            Abbreviation = xmlUnitTranslation.Abbreviation;
        }

        [Key, Column(Order = 0)]
        public int UnitCode { get; set; }
        [Key, Column(Order = 1)]
        public Language Language { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }

        public virtual EtimUnit Unit { get; set; }
    }
}
