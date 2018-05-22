using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.Messages;

namespace Votedress.Entities.SadeModeller
{
    public class Collection_sade
    {
        public Guid kategori_id { get; set; }
        public string Kategori_adi { get; set; }

        public List<ErrorMessageObj> Errors { get; set; }
    }
}
