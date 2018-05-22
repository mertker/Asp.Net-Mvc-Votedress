using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class VoteProduct
    {
        [Key]
        public int id { get; set; }
        public int VoteCount { get; set; }

        public virtual Vote Vote { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<VoteImage> VoteImages { get; set; }
    }
}
