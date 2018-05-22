using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.Modellerim.BusinessLayerResult;
using Votedress.Entities.SadeModeller;

namespace Votedress.Entities.ViewModellerim
{
    public class SohbetViewModel
    {
        public List<OnOffArkadaslar> onOffArkadaslar { get; set; }
        public List<Whisper_sade> whisper_Sades { get; set; }

        public SohbetViewModel()
        {
            onOffArkadaslar = new List<OnOffArkadaslar>();
            whisper_Sades = new List<Whisper_sade>();
        }
    }
}
