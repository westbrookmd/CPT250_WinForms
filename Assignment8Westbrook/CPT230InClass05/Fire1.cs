using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230InClass05
{
    class Fire1 : Spell
    {
        Random random;

        public Fire1()
        {
            this.TheDamage = new Damage(0, "Fire");
            this.Cost = 1;
            random = new Random();
        }

        public override void CalculateDamage(int magiStrength)
        {
            this.TheDamage.Amount = random.Next(magiStrength, magiStrength * 2);
        }

        public override string DisplayName()
        {
            return "Fire1";
        }
    }
}
