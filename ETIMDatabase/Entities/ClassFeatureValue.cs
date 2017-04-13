using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    [Table("Class_Feature_Value")]
    public class ClassFeatureValue
    {
        [Key, Column(Order = 0)]
        public int ClassFeatureID { get; set; }
        [Key, Column(Order = 1)]
        public int ValueCode { get; set; }
        public int OrderNumber { get; set; }

        public virtual ClassFeature ClassFeature { get; set; }
        public virtual Value Value { get; set; }
    }
}
