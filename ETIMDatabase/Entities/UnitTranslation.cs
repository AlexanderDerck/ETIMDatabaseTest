﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class UnitTranslation
    {
        [Key, Column(Order = 0)]
        public int UnitCode { get; set; }
        [Key, Column(Order = 1)]
        public Language Language { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }

        public virtual Unit Unit { get; set; }
    }
}