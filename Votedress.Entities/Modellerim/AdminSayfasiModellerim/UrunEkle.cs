using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Votedress.Entities.Modellerim.AdminUrunEkleModellerim
{
    public class UrunEkle
    {
        [Required]
        public string UrunAdi { get; set; }
        public string KisaUrunAciklamasi { get; set; }
        public string UzunUrunAciklamasi { get; set; }
        public bool SatilikMi { get; set; }
        public int UrunFiyati { get; set; }
        public int UrunMaliyeti { get; set; }
        public Guid KategoriId { get; set; }
        public int StokAdeti { get; set; }
        public HttpPostedFileBase KapakResmi { get; set; }

        public List<UrunIcerigi> urunIcerigi { get; set; }





    }
}
