using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Votedress.Entities.VeritabaniModellerim
{
    public class Friend
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime ArkadaslikTarihi { get; set; }

        public bool Durum { get; set; }

        public virtual VotedressUser User { get; set; }    
        public virtual VotedressUser MyFriend { get; set; }

    }
}
