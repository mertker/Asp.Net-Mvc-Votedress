using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Franchise
    {
        public int id { get; set; }
        public string FranchiseName { get; set; }
        public string FranchiseLogo { get; set; }


        public bool IsActivated { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
