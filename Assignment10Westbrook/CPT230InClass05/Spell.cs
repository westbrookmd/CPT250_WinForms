using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230InClass05
{
    abstract class Spell
    {
        public int Cost { set;  get; }
        public Damage TheDamage { set;  get; }
        public abstract void CalculateDamage(int magiStrength);
        public abstract string DisplayName();

    }
}
