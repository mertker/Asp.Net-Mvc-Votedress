using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class County
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountyID { get; set; }
        public virtual City City { get; set; }
        public string CountyName { get; set; }

        public virtual List<Area> Areas { get; set; }
     
    }
}
