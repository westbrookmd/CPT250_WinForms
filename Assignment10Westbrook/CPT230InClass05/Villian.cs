using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPT230InClass05
{
    class Villian : ICharacterizable
    {
        //Class Data
        protected ProgressBar pbrHP;
        private Label lblName;
        protected Label lblHP;
        private PictureBox pbxImage;
        private string name;

        private int maxHP;
        protected int currentHP;
        private int maxMP;
        private int currentMP;
        protected int strength;
        private int magiStrength;
        protected int defense;
        private Random random;

        //Constructors
        public Villian()
        {
            this.pbrHP = new ProgressBar();
            this.lblName = new Label();
            this.lblHP = new Label();
            this.pbxImage = new PictureBox();
            this.name = "Villian";
            this.maxHP = 300;
            this.currentHP = maxHP;
            this.maxMP = 1;
            this.currentMP = maxMP;
            this.strength = 40;
            this.magiStrength = 1;
            this.defense = 15;
            this.random = new Random();
        }
        public Villian(ProgressBar pbrHP, Label lblName, Label lblHP, PictureBox pbxImage, string name, int maxHP,
            int currentHP, int maxMP, int currentMP, int strength, int magiStrength, int defense)
        {
            this.pbrHP = pbrHP;
            this.lblName = lblName;
            this.lblHP = lblHP;
            this.pbxImage = pbxImage;
            this.name = name;
            this.maxHP = maxHP;
            this.currentHP = currentHP;
            this.maxMP = maxMP;
            this.currentMP = currentMP;
            this.strength = strength;
            this.magiStrength = magiStrength;
            this.defense = defense;
            //method to setup our GUI data
            SetupGUI();
            this.random = new Random();
        }
        //Methods
        public void SetupGUI()
        {
            this.lblName.Text = this.name;
            this.lblHP.Text = this.currentHP.ToString();
            this.pbrHP.Maximum = maxHP;
            this.pbrHP.Value = currentHP;
        }
        public virtual Damage Attack()
        {
            int damage = random.Next(strength, strength * 2);
            string type = "Physical";
            if (random.Next(0, 6) == 5) //20% chance for this special attack
            {
                damage = SpecialAttack(damage);
                type = "Fire";
            }
            return new Damage(damage, type);
        }

        public virtual int SpecialAttack(int damage)
        {
            damage *= 2;
            return damage;
        }

        public virtual Damage TakeDamage(Damage attack)
        {
            int damage = attack.Amount;
            // Defense reduces physical damage
            if (attack.Type == "Physical")
            {
                damage -= this.defense;
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
            // naturally weak against ice
            else if (attack.Type == "Ice")
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
            // naturally strong against fire
            else if (attack.Type == "Fire")
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
            // All other types of attacks are not reduced by defense
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
        public bool IsAlive()
        {
            return this.currentHP > 0;
            // could change image or name here. Not opting to do this
        }
        // Do we have mana?
        public bool ManaAvailable()
        {
            return this.currentMP > 0;
        }
        // Gets the villian name
        public string GetName()
        {
            return this.name;
        }
        // Gets the villian hp
        public int GetHP()
        {
            return this.currentHP;
        }
        // Resets the villian
        public void Reset()
        {
            // Reset Health
            this.currentHP = this.maxHP;
            this.pbrHP.Value = currentHP;
            this.lblHP.Text = currentHP.ToString();
            // Reset Mana (Not currently using any)
            this.currentMP = this.maxMP;


        }
    }
}
