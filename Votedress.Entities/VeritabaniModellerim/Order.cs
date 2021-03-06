﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Votedress.Entities.VeritabaniModellerim
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public virtual VotedressUser User { get; set; }
        public virtual UserAdress UserAdress { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}
