using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class Class
    {
        [Key]
        public int Code { get; set; }
        public int GroupCode { get; set; }
        public ClassStatusType Status { get; set; }
        public uint Version { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<ClassTranslation> Translations { get; set; }
        public virtual ICollection<ClassFeature> ClassFeatures { get; set; }
    }
}
