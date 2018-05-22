using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.Modellerim.Oylamalarim
{
    public class OylamalarimModel
    {
        public Guid OylamaId { get; set; }
        public DateTime OylamaBaslangicZamani { get; set; }
        public DateTime OylamaBitisZamani { get; set; }
        public bool OylamaDurumu { get; set; }
    }
}
