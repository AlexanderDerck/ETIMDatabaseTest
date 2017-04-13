using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class Unit
    {
        [Key]
        public int Code { get; set; }

        public virtual ICollection<UnitTranslation> Translations { get; set; }
    }
}
