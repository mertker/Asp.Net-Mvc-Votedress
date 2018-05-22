using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.SadeModeller
{
    public class Vote_sade
    {
        public Guid id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string TypeOfVote { get; set; }
        public bool PaylasimaAcikmi { get; set; }
        public bool ProfilGorunsunMu { get; set; }
        public Guid VoteLink { get; set; }
        public List<VoteProduct_sade> OylamaUrunleri { get; set; }
        public VotedressUser_sade OylamaSahibi { get; set; }
        public List<VoteMessage_sade> OylamaMesajlari { get; set; }
        public List<VotedressUser_sade> Chattekiler { get; set; }
        public Guid SessionUserId { get; set; }
        public Vote_sade()
        {
            OylamaUrunleri = new List<VoteProduct_sade>();
            OylamaSahibi = new VotedressUser_sade();
            OylamaMesajlari = new List<VoteMessage_sade>();
            Chattekiler = new List<VotedressUser_sade>();
        }

    }
}
