using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Vote
    {
        [Key]
        public Guid id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string TypeOfVote { get; set; }
        public bool PaylasimaAcikmi { get; set; }
        public bool ProfilGorunsunMu { get; set; }
        public Guid  VoteLink { get; set; }

        public int Counter { get; set; }

        public virtual VotedressUser User { get; set; }

        public virtual List<VoteProduct> VoteProduct { get; set; }
        public virtual List<VoteMessage> VoteMessage { get; set; }
    }
}
