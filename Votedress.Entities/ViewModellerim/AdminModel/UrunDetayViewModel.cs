using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.ViewModellerim.AdminModel
{
    public class UrunDetayViewModel
    {

        public Guid productId { get; set; }
        public string  productName { get; set; }
        public int  cost { get; set; }
        public int price { get; set; }
        public string shortdescription { get; set; }
        public string longdescription { get; set; }
        public string productImage { get; set; }
        public List<string> productCategory { get; set; }

        public List<ProductDetail> productDetails { get; set; }

        public UrunDetayViewModel()
        {
            productDetails = new List<ProductDetail>();
        }
    }
}
