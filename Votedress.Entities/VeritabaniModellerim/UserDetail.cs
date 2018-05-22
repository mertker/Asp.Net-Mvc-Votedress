using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class UserDetail
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        
        public DateTime? Birthday { get; set; }

        public string Sex { get; set; }

        public string PhoneNumber { get; set; }

        public string TypeOfBusiness { get; set; }

        public string CommencialTitle { get; set; }

        public string CompanyName { get; set; }

        public string AdressDetail { get; set; }

        public string TcNo { get; set; }

        public string LandPhone { get; set; }



        public virtual VotedressUser User { get; set; }
        public virtual City City { get; set; }
        public virtual County County { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
    }
}
