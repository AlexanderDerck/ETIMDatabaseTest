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
    [Table("Etim_Class_Feature")]
    public class EtimClassFeature
    {
        public EtimClassFeature() { }
        public EtimClassFeature(ClassFeatureType xmlFeature)
        {
            FeatureCode = int.Parse(xmlFeature.FeatureCode.Substring(2));
            FeatureValues = xmlFeature.Values?.Select(v => new EtimClassFeatureValue(v)).ToList();
            OrderNumber = xmlFeature.OrderNumber;

            if(!String.IsNullOrEmpty(xmlFeature.UnitCode))
                UnitCode = int.Parse(xmlFeature?.UnitCode.Substring(2));
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ClassCode { get; set; }
        public int FeatureCode { get; set; }
        public int? UnitCode { get; set; }
        public int OrderNumber { get; set; }

        public virtual EtimClass Class { get; set; }
        public virtual EtimFeature Feature { get; set; }
        //There will be either a unit or a collection of values (or none at all), never both at the same time
        public virtual EtimUnit Unit { get; set; }
        public virtual ICollection<EtimClassFeatureValue> FeatureValues { get; set; }
    }
}
