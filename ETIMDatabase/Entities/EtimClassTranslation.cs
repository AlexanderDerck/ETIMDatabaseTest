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
    public class EtimClassTranslation
    {
        public EtimClassTranslation() { }
        public EtimClassTranslation(string description, string language, bool isSynonym)
        {
            Description = description;
            Language = language.GetLanguage();
            IsSynonym = isSynonym;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ClassCode { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public bool IsSynonym { get; set; }

        public virtual EtimClass Class { get; set; }
    }
}
