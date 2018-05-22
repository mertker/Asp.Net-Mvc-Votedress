using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.SadeModeller
{
    public class orderDetail_sade
    {
        public int id { get; set; }
        public Guid productId { get; set; }
        public string productName { get; set; }
        public int productPrice { get; set; }
        public string productCompanyName { get; set; }
        public string productImage { get; set; }
        public int productCount { get; set; }
        public string productSize { get; set; }
        public List<Color> colors { get; set; }
    }
}
