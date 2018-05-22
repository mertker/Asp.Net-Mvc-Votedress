using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class VotedressUser_sade
    {
        public Guid id { get; set; }
        public string SocialId { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public string SocialName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public DateTime? Birthday { get; set; }

        public string Sex { get; set; }
    }
}
