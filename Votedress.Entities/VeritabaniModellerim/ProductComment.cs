using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class ProductComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }

        
        public virtual VotedressUser VotedressUser { get; set; }
        public virtual Product Product { get; set; }

        public virtual List<ProductCommentReply> ProductCommentReply { get; set; }
        public virtual List<ProductCommentLike> ProductCommentLike { get; set; }

    }
}
