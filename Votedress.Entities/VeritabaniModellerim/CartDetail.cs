using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class CartDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime AddToCartDate { get; set; }

        public int ProductCount { get; set; }

        public int ProductColorId { get; set; }

        public string Size { get; set; }


        [ForeignKey("ProductColorId")]
        public virtual ProductColor ProductColor { get; set; }

        public virtual Product Product { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
