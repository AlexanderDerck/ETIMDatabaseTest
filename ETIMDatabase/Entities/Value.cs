using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class Value
    {
        [Key]
        public int Code { get; set; }

        public virtual ICollection<ValueTranslation> Translations { get; set; }
    }
}
