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
    [Table("Etim_Class_Feature_Value")]
    public class EtimClassFeatureValue
    {
        public EtimClassFeatureValue() { }
        public EtimClassFeatureValue(ClassFeatureValueType xmlClassFeatureValue)
        {
            OrderNumber = xmlClassFeatureValue.OrderNumber;
            ValueCode = int.Parse(xmlClassFeatureValue.ValueCode.Substring(2));
        }

        public int ID { get; set; }
        [Key, Column(Order = 0)]
        public int ClassFeatureID { get; set; }
        [Key, Column(Order = 1)]
        public int ValueCode { get; set; }
        public int OrderNumber { get; set; }

        public virtual EtimClassFeature ClassFeature { get; set; }
        public virtual EtimValue Value { get; set; }
    }
}
