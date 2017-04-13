using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class ClassTranslation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ClassCode { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public bool IsSynonym { get; set; }

        public virtual Class Class { get; set; }
    }
}
