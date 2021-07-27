using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230InClass05
{
    class Smite1 : Spell
    {
        Random random;
        public Smite1()
        {
            this.TheDamage = new Damage(0, "Holy");
            this.Cost = 1;
            random = new Random();
        }

        public override void CalculateDamage(int magiStrength)
        {
            this.TheDamage.Amount = random.Next(magiStrength, magiStrength * 2);
        }

        public override string DisplayName()
        {
            return "Smite 1";
        }
    }
}
