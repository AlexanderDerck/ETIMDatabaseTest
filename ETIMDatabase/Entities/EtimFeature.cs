﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class EtimFeature
    {
        [Key]
        public int Code { get; set; }
        public FeatureType Type { get; set; }

        public virtual ICollection<EtimFeatureTranslation> Translations { get; set; }
    }
}
