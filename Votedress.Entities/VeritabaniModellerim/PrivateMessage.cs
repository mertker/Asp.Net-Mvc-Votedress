using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class PrivateMessage
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }
        public string Message { get; set; }
        public bool GorulmeDurumu { get; set; }
        public DateTime GöndermeTarihi { get; set; }


        public virtual VotedressUser User { get; set; }
        public virtual VotedressUser AlanId { get; set; }
    }
}

