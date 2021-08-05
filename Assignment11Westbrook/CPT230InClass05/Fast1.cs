using System;

namespace CPT230InClass05
{
    class Fast1 : Spell
    {
        Random random;
        public Fast1()
        {
            this.TheDamage = new Damage(0, "Physical");
            this.Cost = 1;
            random = new Random();
        }

        public override void CalculateDamage(int strength)
        {
            this.TheDamage.Amount = random.Next(strength, strength * 2);
        }

        public override string DisplayName()
        {
            return "Fast 1";
        }
    }
}
