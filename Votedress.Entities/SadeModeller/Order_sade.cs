using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class Order_sade
    {
        public int id { get; set; }
        public DateTime orderDate { get; set; }
        public string orderStatus { get; set; }
        public int toplamTutar { get; set; }
        public Adress_sade adress_Sade { get; set; }
        public List<orderDetail_sade> orderDetails { get; set; }
    }
}
