using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votedress.Entities.ViewModellerim.AdminModel
{
    public class chart1Model
    {
        public string BolgeAdi { get; set; }
        public string SehirAdi { get; set; }
        public int KisiSayisi { get; set; }
        public int Gelir { get; set; }
        private int yas;
        public int Yas
        {
            get
            {
                return yas;
            }
            set
            {

                yas = YasYuvarla(value);
            }

        }

        public string toString()
        {
            /*
               {
                    "Country": "Afghanistan",
                    "CountryCode": "AFG",
                    "Region": "Asia | South & West",
                    "Continent": "Asia",
                    "GDP": 15936784437.22,
                    "GDP_perCapita": 561.2,
                    "lifeExpectancy": 59.60009756
                },*/

            return string.Format("{}", BolgeAdi, SehirAdi, KisiSayisi, yas);
        }

        private string tirnak(string key, string value)
        {
            return '"' + key + '"' + ":\"" + value + "\"\n'";
        }


        public static int YasYuvarla(int yas)
        {
            int mod = yas % 5;
            if(mod<3)
            {
                return yas -= mod;
            }

            mod = 5 - mod;
            return yas += mod;
        }
    }
}