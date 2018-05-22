using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.SadeModeller
{
    public class Cart_sade
    {
        public int id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int ProductPrice { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public int ProductColorId { get; set; }

    }
}
