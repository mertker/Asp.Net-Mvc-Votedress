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
    public class PersonalUsersDetail
    {
        [Key]
        public Guid  id { get; set; }

        [Required(ErrorMessage ="İsim girmeniz şart"),StringLength(50), DisplayName("Ad")]
        public string Name { get; set; }


        [Required(ErrorMessage = "İsim girmeniz şart"), StringLength(50), DisplayName("Soyad")]
        public string SurName { get; set; }


        [Required(ErrorMessage = "Doğum günü girmeniz şart"), DisplayName("Dogumgunu")]
        public DateTime Birthday { get; set; }


        [Required(ErrorMessage = "Cinsiyet girmeniz şart") ,StringLength(30), DisplayName("Cinsiyet")]
        public string Sex { get; set; }


        public virtual City City { get; set; }
        public virtual County County { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }

    }
}
