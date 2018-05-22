using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    [Table("VotedressUsers")]
    public class VotedressUser
    {


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }


        [StringLength(100, ErrorMessage = "Sosyal id karakter sınırı hatası")]
        public string SocialId { get; set; }


        [Required(ErrorMessage = "Mail Adresi Zorunlu"), StringLength(50, ErrorMessage = "Mail karakter sınırı hatası")]
        public string Email { get; set; }


        [StringLength(50, ErrorMessage = "Password karakter sınır hatası")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "Password karakter sınır hatası")]
        public string Role { get; set; }


        public bool IsActive { get; set; }
        public Guid ActivateGuid { get; set; }


        [StringLength(200, ErrorMessage = "Resim Linki karakter sınır hatası")]
        public string ProfileImage { get; set; }


        [Required(ErrorMessage = "Sosyal ağ adı girilmedi"), StringLength(200, ErrorMessage = "sosyal ağ adı karakter sınır hatası")]
        public string SocialName { get; set; }

        public int OnlineCount { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }


        public virtual Franchise Franchise {get;set;}
        public virtual UserDetail UserDetail { get; set; }

        [InverseProperty("User")]
        public virtual List<Friend> Friends { get; set; }

        public virtual List<Category> Collections { get; set; }

        [InverseProperty("User")]
        public virtual List<Vote> Votes { get; set; }

        public virtual List<MyVoted> MyVoteds { get; set; }

        public virtual List<UserAdress> UserAdresses { get; set; }

        [InverseProperty("User")]
        public virtual List<Order> Orders { get; set; }

        [InverseProperty("BlockingUser")]
        public virtual List<BlockedUser> BlockedUsers { get; set; }

    }
}
