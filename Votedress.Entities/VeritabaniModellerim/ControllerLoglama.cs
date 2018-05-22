using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class ControllerLoglama
    {
        [Key,ForeignKey("User")]
        public Guid KullaniciId { get; set; }

        public string Burdan { get; set; }
        public string Buraya { get; set; }
        public string parameter { get; set; }
        public DateTime CreatedTime { get; set; }


        public virtual VotedressUser User { get; set; }

    }
}
