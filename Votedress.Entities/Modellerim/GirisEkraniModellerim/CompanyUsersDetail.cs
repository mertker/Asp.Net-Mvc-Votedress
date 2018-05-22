using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.GirisEkraniModellerim
{
    public class CompanyUsersDetail
    {


        [Required(ErrorMessage = "İsminizi girmeniz zorunludur"),StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisminiz girmeniz zorunludur"), StringLength(50)]
        public string SurName { get; set; }


        [Required(ErrorMessage = "Telefon Numaranızı girmeniz zorunludur"), StringLength(50)]
        public string PhoneNumber { get; set; }




        [Required(ErrorMessage = "İş türünü girmeniz zorunludur"), StringLength(50)]
        public string TypeOfBusiness { get; set; }


        [Required(ErrorMessage = "Ticari ünvanınızı girmeniz zorunludur"), StringLength(50)]
        public string CommencialTitle { get; set; }


     


        [Required(ErrorMessage = "Adres detayı girmeniz zorunludur"), StringLength(500)]
        public string AdressDetail { get; set; }


        [Required(ErrorMessage = "Tc Numaranızı girmeniz zorunludur"), MaxLength(11),MinLength(11)]
        public string TcNo { get; set; }


        [StringLength(50)]
        public string LandPhone { get; set; }


        [Required(ErrorMessage = "İl girmeniz zorunludur")]
        public virtual City Cities { get; set; }

        [Required(ErrorMessage = "İlçe girmeniz zorunludur")]
        public virtual County County { get; set; }

        [Required(ErrorMessage = "Mahalle girmeniz zorunludur")]
        public virtual Neighborhood Neighborhood { get; set; }

    }
}
