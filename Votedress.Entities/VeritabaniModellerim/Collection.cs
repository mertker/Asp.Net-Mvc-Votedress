using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Collection
    {
        [Key]
        public Guid id { get; set; }
        public string CollectionName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual List<ProductCollection> ProductCollection { get; set; }
        public virtual VotedressUser User { get; set; }
    }
}
