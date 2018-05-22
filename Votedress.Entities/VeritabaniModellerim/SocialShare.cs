using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class SocialShare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid id { get; set; }
        public string SocialName { get; set; }
        public string ShareName { get; set; }
        public DateTime ShareDate { get; set; }


        public virtual VotedressUser VotedressUser { get; set; }

        public virtual Product  Product { get; set; }
        public virtual Collection Collection { get; set; }
        public virtual Vote Vote { get; set; }

        //Paylaşılacak çeşit arttıkça buraya ekliyecem
    }
}
