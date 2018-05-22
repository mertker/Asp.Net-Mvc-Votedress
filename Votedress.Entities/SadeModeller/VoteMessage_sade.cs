using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class VoteMessage_sade
    {
        public int id { get; set; }
        public string Message { get; set; }
        public DateTime GondermeTarihi { get; set; }

        public VotedressUser_sade MesajSahibi { get; set; }

        public VoteMessage_sade()
        {
            MesajSahibi = new VotedressUser_sade();
        }
    }
}
