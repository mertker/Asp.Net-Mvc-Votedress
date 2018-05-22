using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class VoteBanned
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual Vote BanlayanId { get; set; }
        public virtual Vote BanlananId { get; set; }

    }
}
