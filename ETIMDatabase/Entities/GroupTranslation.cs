using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETIMDatabase.Entities
{
    public class GroupTranslation
    {
        [Key, Column(Order = 0)]
        public int GroupCode { get; set; }
        [Key, Column(Order = 1)]
        public Language Language { get; set; }
        public string Description { get; set; }

        public virtual Group Group { get; set; }
    }
}
