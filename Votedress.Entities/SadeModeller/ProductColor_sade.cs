using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.SadeModeller
{
    public class ProductColor_sade
    {
        public int id { get; set; }

        public ProductSize ProductSize { get; set; }
        public List<ProductColorDetail> ProductColorDetail { get; set; }


    }
}
