using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class BlockedUser
    {
        [Key]
        public int id { get; set; }
        public DateTime BlockedTime { get; set; }

        public virtual VotedressUser BlockingUser { get; set; }
        public virtual VotedressUser BlockedUser1 { get; set; }
    }
}
