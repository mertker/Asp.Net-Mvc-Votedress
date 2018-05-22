using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Product
    {
        [Key]
        public Guid id { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Price { get; set; }

        public int Cost { get; set; }
        public string ProductImage { get; set; }
        public bool IsForSale { get; set; }  
        public DateTime UploadDate { get; set; }
        public DateTime ModifiedDate { get; set; }




        public virtual List<ProductSize> ProductSize { get; set; }
        public virtual VotedressUser User { get; set; }
        public virtual List<ProductCategory> ProductCategory { get; set; }
        public virtual List<ProductCollection> ProductCollection { get; set; }
        public virtual List<ProductComment> ProductComment { get; set; }
        public virtual List<ProductLike> ProductLike { get; set; }

        public virtual List<OrderDetail> OrderDetail { get; set; }




    }
}
