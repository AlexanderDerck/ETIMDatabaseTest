using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EtimIXF;

namespace ETIMDatabase.Entities
{
    public class EtimClass
    {
        public EtimClass() { }
        public EtimClass(ClassType xmlClass)
        {
            Code = int.Parse(xmlClass.Code.Substring(2));
            GroupCode = int.Parse(xmlClass.GroupCode.Substring(2));
            Status = (ClassStatusType)xmlClass.Status;
            Version = xmlClass.Version;
        }

        [Key]
        public int Code { get; set; }
        public int GroupCode { get; set; }
        public ClassStatusType Status { get; set; }
        public uint Version { get; set; }

        public virtual EtimGroup Group { get; set; }
        public virtual ICollection<EtimClassTranslation> Translations { get; set; }
        public virtual ICollection<EtimClassFeature> ClassFeatures { get; set; }
    }
}
