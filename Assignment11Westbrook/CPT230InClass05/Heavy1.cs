using System;

namespace CPT230InClass05
{
    class Heavy1 : Spell
    {
        Random random;
        public Heavy1()
        {
            this.TheDamage = new Damage(0, "Physical");
            this.Cost = 1;
            random = new Random();
        }

        public override void CalculateDamage(int strength)
        {
            this.TheDamage.Amount = random.Next(strength * 2, strength * 3);
        }

        public override string DisplayName()
        {
            return "Heavy 1";
        }
    }
}
