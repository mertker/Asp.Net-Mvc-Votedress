using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.Modellerim.BusinessLayerResult
{
    public class OnOffArkadaslar
    {
        public Guid id { get; set; }
        public string AdSoyad { get; set; }
        public string ProfilImage { get; set; }
        public bool Online { get; set; }
        public int GorulmemisMesajSayisi { get; set; }
    }
}
