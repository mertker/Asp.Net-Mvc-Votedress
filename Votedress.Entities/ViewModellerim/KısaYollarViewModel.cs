using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.SadeModeller;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.ViewModellerim
{
    public class KısaYollarViewModel
    {
        public List<PrivateMessage_sade> GorulmemisMesajlar { get; set; }
        public List<Bahsedilen_sade> Bahsedenler { get; set; }
        public List<Friend_sade> ArkadaslikIsteklerim { get; set; }
        public List<Cart_sade> Cart_Sades { get; set; }

        public KısaYollarViewModel()    
        {
            Bahsedenler = new List<Bahsedilen_sade>();
            GorulmemisMesajlar = new List<PrivateMessage_sade>();
            ArkadaslikIsteklerim = new List<Friend_sade>();
            Cart_Sades = new List<Cart_sade>();
        }
    }
}
