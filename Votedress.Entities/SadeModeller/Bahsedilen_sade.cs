using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class Bahsedilen_sade
    {
        public int id { get; set; }
        public VotedressUser_sade Bahseden { get; set; }
        public Guid TipId { get; set; }
        public bool GorulmeDurumu { get; set; }
        public DateTime BahsetmeTarihi { get; set; }
        public string Mesaj { get; set; }
        public string Tip { get; set; }

        public string bahsedilenYerAdi { get; set; }

    }
}
