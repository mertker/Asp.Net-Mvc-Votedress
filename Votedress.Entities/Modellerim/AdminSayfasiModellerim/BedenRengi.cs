using System.Collections.Generic;
using System.Web;

namespace Votedress.Entities.Modellerim.AdminUrunEkleModellerim
{
    public class BedenRengi
    {

        public int stokAdeti { get; set; }

        public List<HttpPostedFileBase> urunResimleri { get; set; }

        public List<string> renkleri { get; set; }

    }
}