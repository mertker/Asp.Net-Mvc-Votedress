using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityID { get; set; }
        public int CountryID { get; set; }

        public string CityName { get; set; }
        public int PlateNo { get; set; }
        public int PhoneCode { get; set; }
        public string RegionName { get; set; }

        public virtual List<County> Counties { get; set; }
    }
}
