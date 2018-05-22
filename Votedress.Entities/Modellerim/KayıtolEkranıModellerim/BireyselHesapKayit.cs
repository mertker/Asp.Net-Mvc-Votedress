using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.Modellerim.KayıtolEkranıModellerim
{
    public class BireyselHesapKayit
    {
        [Required,DisplayName("Ad"),MinLength(2,ErrorMessage ="Lütfen 2 den büyük giriniz"),MaxLength(20,ErrorMessage ="Lütfen 20 den küçük giriniz")]
        public string Ad { get; set; }
        [Required, DisplayName("Soyad"), MinLength(2, ErrorMessage = "Lütfen 2 den büyük giriniz"), MaxLength(20, ErrorMessage = "Lütfen 20 den küçük giriniz")]
        public string Soyad { get; set; }
        [Required, DisplayName("Email"),EmailAddress(ErrorMessage ="Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }


        [Required, DisplayName("Ad"), MaxLength(15),MinLength(6)]
        public string Sifre { get; set; }

        [Required, DisplayName("DogumTarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DogumTarihi { get; set; }


        [Required, DisplayName("Cinsiyet"), StringLength(20)]
        public string Cinsiyet { get; set; }

    }
}
