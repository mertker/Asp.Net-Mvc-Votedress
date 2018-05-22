using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AreaID { get; set; }
        public virtual County County { get; set; }  
        public string AreaName { get; set; }

       
       
        public virtual List<Neighborhood> Neighborhoods { get; set; }
    }
}
