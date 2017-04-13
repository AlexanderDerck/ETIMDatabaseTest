using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    [Table("Class_Feature")]
    public class ClassFeature
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ClassCode { get; set; }
        public int FeatureCode { get; set; }    
        public int OrderNumber { get; set; }

        public virtual Class Class { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual ICollection<ClassFeatureValue> FeatureValues { get; set; }
    }
}
