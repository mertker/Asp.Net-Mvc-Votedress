using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class OnlineUser
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }
        public string ConnectionId { get; set; }
        public string Disconnected { get; set; }
        public DateTime OnlineOlmaTarihi { get; set; }


        public virtual VotedressUser User { get; set; }

    }
}
