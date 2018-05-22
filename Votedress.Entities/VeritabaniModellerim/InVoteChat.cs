using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class InVoteChat
    {
        [Key]
        public int id { get; set; }
        public virtual VotedressUser User { get; set; }
        public virtual Vote Vote { get; set; }
    }
}
