using System;
using System.Collections.Generic;

namespace Votedress.Entities.SadeModeller
{
    public class VoteProduct_sade
    {
        public int id { get; set; }
        public int VoteCount { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Price { get; set; }

        public string ProductImage { get; set; }
        public bool IsForSale { get; set; }

        public Magazalar_sade UrunSahibi { get; set; }


        public List<VoteImage_sade> OylamaResimleri { get; set; }

        public VoteProduct_sade()
        {
            OylamaResimleri = new List<VoteImage_sade>();
        }
    }
}