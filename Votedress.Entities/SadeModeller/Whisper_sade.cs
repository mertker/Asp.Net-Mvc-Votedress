using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class Whisper_sade
    {
        public int id { get; set; }
        public bool WhisperStatus { get; set; }

        public int GorulmemisMesajSayisi { get; set; }

        public Guid UserId { get; set; }     
        public string FullName { get; set; }
        public string UserProfileImage { get; set; }
    }
}
