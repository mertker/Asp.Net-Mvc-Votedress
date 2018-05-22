using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class PrivateMessage_sade
    {
        public Guid userId { get; set; }
        public string Message { get; set; }
        public string GonderilmeTarihi { get; set; }
        public string ProfilImage { get; set; }
        public string adSoyad { get; set; }
        public bool Sahip { get; set; }
    }
}
