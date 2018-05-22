using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Neighborhood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NeighborhoodID { get; set; }
        public virtual Area Area { get; set; }
        public string NeighborhoodName { get; set; }
        public string ZipCode { get; set; } 

       
    }
}
