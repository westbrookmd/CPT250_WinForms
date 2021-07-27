using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT230InClass05
{
    // Basic Storage of Spell Types and Spell Logic
    class Spella
    {
        private Random random;

        public string Type
        { set; get; }
        // Store Spell Type
        public Spella(string Type)
        {
            this.Type = Type;
            this.random = new Random();
        }
        // Spell Damage Logic
        public int GetPower(int magiStrength)
        {
            int damage;
            // medium variance, less consistent, medium maximum damage
            if (this.Type == "Fire")
            {
                damage = random.Next((magiStrength / 4), (magiStrength * 2));
            }
            // low variance, very consistent, lower maximum damage
            else if (this.Type == "Ice")
            {
                damage = random.Next(magiStrength / 2, (magiStrength));
            }
            // extreme variance, not consistent, high maximum damage
            else if (this.Type == "Thunder")
            {
                damage = random.Next(magiStrength / 8, (magiStrength * 3));
            }
            else
            {
                damage = random.Next(magiStrength / 3, magiStrength);
            }
            return damage;
        }
    }
}
