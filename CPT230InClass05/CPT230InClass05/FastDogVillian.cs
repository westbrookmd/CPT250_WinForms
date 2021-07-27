using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPT230InClass05
{
    class FastDogVillian : Villian
    {
        Random random;
        public FastDogVillian() : base()
        {

            random = new Random();
        }

        public FastDogVillian(ProgressBar pbrHP, Label lblName, Label lblHP, PictureBox pbxImage, string name, int maxHP,
            int currentHP, int maxMP, int currentMP, int strength, int magiStrength, int defense)
            : base(pbrHP, lblName, lblHP,
            pbxImage, name, maxHP, currentHP,
            maxMP, currentMP, strength, magiStrength,
            defense)
        {

        }

        public override Damage Attack()
        {
            int damage = random.Next(strength, strength * 2);
            string type = "Physical";
            if (random.Next(0, 6) == 5) //20% chance for this special attack
            {
                damage = SpecialAttack(damage);
                type = "Physical";
            }
            return new Damage(damage, type);
        }

        public override int SpecialAttack(int damage)
        {
            damage *= 3;
            return damage;
        }

        public override Damage TakeDamage(Damage attack)
        {
            int damage = attack.Amount;
            // Defense reduces physical damage
            if (attack.Type == "Physical")
            {
                // no defense but dodges everything physical under 25 damage
                if (damage < 25)
                {
                    damage = 0;
                }
                if (damage > this.currentHP)
                {
                    damage = this.currentHP;
                }
                this.currentHP -= damage;
            }
            // naturally weak against Fire
            else if (attack.Type == "Fire")
            {
                damage *= 2;
                if (damage < 1)
                {
                    damage = 1;
                }
                if (damage > this.currentHP)
                {
                    damage = this.currentHP;
                }
                this.currentHP -= damage;
            }
            // naturally strong against Ice
            else if (attack.Type == "Ice")
            {
                damage /= 2;
                if (damage < 1)
                {
                    damage = 1;
                }
                if (damage > this.currentHP)
                {
                    damage = this.currentHP;
                }
                this.currentHP -= damage;
            }
            // All other types of attacks are not reduced by defense/dodged
            else
            {
                if (damage < 1)
                {
                    damage = 1;
                }
                if (damage > this.currentHP)
                {
                    damage = this.currentHP;
                }
                this.currentHP -= damage;

            }
            // update health bar
            this.pbrHP.Value = currentHP;
            //update label value
            this.lblHP.Text = currentHP.ToString();
            //add some KO check method or something

            // return damage
            return new Damage(damage, attack.Type);
        }
    }
}
