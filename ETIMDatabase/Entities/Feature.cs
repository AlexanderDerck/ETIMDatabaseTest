using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class Feature
    {
        [Key]
        public int Code { get; set; }
        public FeatureType Type { get; set; }

        public virtual ICollection<FeatureTranslation> Translations { get; set; }
    }
}
