using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class ProductColor
    {
        [Key]
        public int id { get; set; }
        public int StockCount { get; set; }

        public virtual ProductSize ProductSize { get; set; }
        public virtual List<ProductImageGallery> ProdutImageGallery { get; set; }
        public virtual List<ProductColorDetail> ProductColorDetail { get; set; }


    }
}
