using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.SadeModeller
{
    public class Adress_sade
    {
        public int id { get; set; }
        public string AdressTitle { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public string CityName { get; set; }
        public string CountyName { get; set; }
        public string NeighborhoodName { get; set; }
    }

}

