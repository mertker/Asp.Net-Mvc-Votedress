using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class Category_sade
    {
        public Guid id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
