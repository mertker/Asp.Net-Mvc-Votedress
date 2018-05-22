using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.Modellerim.Oylamalarim;
using Votedress.Entities.SadeModeller;

namespace Votedress.Entities.ViewModellerim
{
    public class OylamalarimViewModel
    {
        public List<OylamalarimModel> oylamalarimModels { get; set; }
        public Vote_sade vote_Sade { get; set; }

        public OylamalarimViewModel()
        {
            oylamalarimModels = new List<OylamalarimModel>();
        }

    }
}
