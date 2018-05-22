using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Category
    {
        [Key]
        public Guid id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual List<ProductCategory> ProductCategory { get; set; }
        public virtual VotedressUser User { get; set; }

    }
}
