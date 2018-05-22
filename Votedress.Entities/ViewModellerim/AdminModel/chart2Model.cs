using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votedress.Entities.ViewModellerim.AdminModel
{
    public class chart2Model
    {
        public string State { get; set; }
        public Freq freq { get; set; }

    }


    public class Freq
    {
        public int beyaz { get; set; }
        public int siyah { get; set; }
        public int yesil { get; set; }
        public int kirmizi { get; set; }
        public int sari { get; set; }
        public int mavi { get; set; }
        public int kahverengi { get; set; }
        public int mor { get; set; }
    }
}