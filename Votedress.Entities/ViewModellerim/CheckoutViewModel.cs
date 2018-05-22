using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.ViewModellerim
{
    public class CheckoutViewModel
    {
        public int id { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; }
        public int Mahalle { get; set; }
        public int Ilce { get; set; }
        public int Sehir { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Email { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }

    }
}
