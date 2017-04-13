using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class Group
    {
        [Key]
        public int Code { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<GroupTranslation> Translations { get; set; }
    }
}
