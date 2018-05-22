using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.Modellerim.GirisEkrainModellerim
{
    public class Giris
    {
        [Required(ErrorMessage ="Email zorunlu)"),StringLength(30,ErrorMessage ="En fazla 30 karakter girebilirsiniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password zorunlu"), MaxLength(20,ErrorMessage ="En fazla 20 karakter girebilirsiniz"),MinLength(6,ErrorMessage ="En az 6 karakter girmelisiniz")]
        public string Password { get; set; }

    }
}
