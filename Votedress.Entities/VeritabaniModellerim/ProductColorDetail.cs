using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class ProductColorDetail
    {
        [Key]
        public int id { get; set; }

        public virtual ProductColor ProductColor { get; set; }
        public virtual Color Color { get; set; }
    }
}
