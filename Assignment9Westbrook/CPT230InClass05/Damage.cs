﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230InClass05
{
    class Damage
    {
        public int Amount
        {
            set; get;
        }
        public string Type
        { set; get; }

        public Damage(int Amount, string Type)
        {
            this.Amount = Amount;
            this.Type = Type;
        }
    }
}
