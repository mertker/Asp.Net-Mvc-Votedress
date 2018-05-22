using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.Entities.Modellerim.KayıtolEkranıModellerim
{
    public class KurumsalHesapKayit
    {
        [Required,DisplayName("Ad"),MinLength(2,ErrorMessage ="Lütfen 2 den büyük giriniz"),MaxLength(20,ErrorMessage ="Lütfen 20 den küçük giriniz")]
        public string Ad { get; set; }
        [Required, DisplayName("Soyad"), MinLength(2, ErrorMessage = "Lütfen 2 den büyük giriniz"), MaxLength(20, ErrorMessage = "Lütfen 20 den küçük giriniz")]
        public string Soyad { get; set; }
        [Required, DisplayName("Email"),EmailAddress(ErrorMessage ="Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }


        [Required, DisplayName("Ad"), MaxLength(15),MinLength(6)]
        public string Sifre { get; set; }



        [Required(ErrorMessage ="Cep telefon numarası zorunlu"), DisplayName("Ceptelefonno"), MinLength(11, ErrorMessage = "Lütfen 11 hane giriniz"), MaxLength(11, ErrorMessage = "Lütfen 11 hane giriniz")]
        public string Ceptelefonno { get; set; }



        [Required(ErrorMessage = "İşletme türü zorunlu"), DisplayName("Isletmeturu")]
        public string Isletmeturu { get; set; }


        [Required(ErrorMessage = "Ticari ünvan zorunlu"), DisplayName("Ticariunvan")]
        public string Ticariunvan { get; set; }

        [Required(ErrorMessage = "Şirket adı zorunlu"), DisplayName("Sirketadi")]
        public string Sirketadi { get; set; }

        [Required(ErrorMessage = "İl ünvan zorunlu"), DisplayName("Il")]
        public string Il { get; set; }

        [Required(ErrorMessage = "İlçe ünvan zorunlu"), DisplayName("Ilce")]
        public string Ilce { get; set; }

        [Required(ErrorMessage = "Mahalle ünvan zorunlu"), DisplayName("Mahalle")]
        public string Mahalle { get; set; }


        [Required(ErrorMessage = "Adres detayı zorunlu"), DisplayName("Adresdetayi")]
        public string Adresdetayi { get; set; }

        [Required(ErrorMessage = "Vergi dairesi zorunlu"), DisplayName("Vergidairesi")]
        public string Vergidairesi { get; set; }


        [Required(ErrorMessage = "TC ünvan zorunlu"),StringLength(11,MinimumLength =11), DisplayName("Tcno")]
        public string Tcno { get; set; }


        [Required(ErrorMessage = "Sabit numara zorunlu"), DisplayName("Sabitno")]
        public string Sabitno { get; set; }
    }
}
