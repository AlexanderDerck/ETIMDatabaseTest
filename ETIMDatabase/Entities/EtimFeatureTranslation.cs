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
    public class EtimFeatureTranslation
    {
        public EtimFeatureTranslation() { }
        public EtimFeatureTranslation(ShortTranslationType xmlShortTranslation)
        {
            Description = xmlShortTranslation.Description;
            Language = xmlShortTranslation.language.GetLanguage();
        }

        [Key, Column(Order = 0)]
        public int FeatureCode { get; set; }
        [Key, Column(Order = 1)]
        public Language Language { get; set; }
        public string Description { get; set; }

        public virtual EtimFeature Feature { get; set; }
    }
}
