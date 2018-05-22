using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Bahsedilen
    {
        [Key]
        public int id { get; set; }
        public string Mesaj { get; set; }
        public  bool GorulmeDurumu { get; set; }
        public DateTime BahsedilmeTarihi { get; set; }


        public virtual VotedressUser BahsedenId { get; set; }
        public virtual VotedressUser BahsedilenId { get; set; }
 
       
        public virtual Product Product { get; set; }
        public virtual Category Collection { get; set; }
        public virtual SocialShare SocialShare { get; set; }

        public virtual Vote Vote { get; set; }
    }
}
