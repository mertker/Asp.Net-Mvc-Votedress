using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class Magazalar_sade
    {
        public Guid MagazaGuid { get; set; }
        public string SirketAdi { get; set; }
        public string SirketResmi { get; set; }
        public string FranchiseAdi { get; set; }
        public string FranchiseLogo { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public int MagazadakilerSayisi { get; set; }
        public string TelNo { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }


    }
}
