using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Whisper
    {
        [Key]
        public int id { get; set; }
        public bool WhisperStatus { get; set; }

        public virtual VotedressUser User1 { get; set; }
        public virtual VotedressUser User2 { get; set; }
    }
}
