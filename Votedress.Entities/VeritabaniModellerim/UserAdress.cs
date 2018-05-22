using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class UserAdress
    {
        [Key]
        public int id { get; set; }
        public string AdressTitle { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        

        public virtual VotedressUser User { get; set; }
        public virtual City City { get; set; }
        public virtual County County { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
    }
}
