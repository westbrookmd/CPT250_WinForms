using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPT230InClass05
{
    class Hero
    {
        //Class Data
        private ProgressBar pbrHP;
        private Label lblName;
        private Label lblHP;
        private PictureBox pbxImage;
        private string name;

        private int maxHP;
        private int currentHP;
        private int maxMP;
        private int currentMP;
        private int strength;
        private int magiStrength;
        private int defense;
        private Random random;

        //Constructors
        public Hero()
        {
            this.pbrHP = new ProgressBar();
            this.lblName = new Label();
            this.lblHP = new Label();
            this.pbxImage = new PictureBox();
            this.name = "Hero";
            this.maxHP = 100;
            this.currentHP = maxHP;
            this.maxMP = 10;
            this.currentMP = maxMP;
            this.strength = 20;
            this.magiStrength = 20;
            this.defense = 10;
            this.random = new Random();
        }
        public Hero(ProgressBar pbrHP, Label lblName, Label lblHP, PictureBox pbxImage, string name, int maxHP, 
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
        // Methods
        private void SetupGUI()
        {
            this.lblName.Text = this.name;
            this.lblHP.Text = this.currentHP.ToString();
            this.pbrHP.Maximum = maxHP;
            this.pbrHP.Value = currentHP;
        }
        public Damage Attack()
        {
            int damage = random.Next(strength, strength * 2);
            string type = "Physical";
            return new Damage(damage, type);
        }
        public Damage MagicAttack()//take a string type
        {
            int damage = random.Next(magiStrength, magiStrength * 2);
            string type = "Magic";
            return new Damage(damage, type);
        }
        public Damage TakeDamage(Damage attack)
        {
            int damage = attack.Amount;
            if (attack.Type == "Heal")
            {
                this.currentHP +=damage;
                if (currentHP > maxHP)
                {
                    currentHP = maxHP;
                }

            }
            else
            {
                 damage -=  this.defense;
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
            
            this.pbrHP.Value = currentHP;
            //update label value
            this.lblHP.Text = currentHP.ToString();
            //add some KO check method or something

            return new Damage(damage, attack.Type);
        }
        public bool IsAlive()
        {
            return this.currentHP > 0;
            // change image to tombstone if dead
        }
        public bool ManaAvailable()
        {
            return this.currentMP > 0;
        }
        public string GetName()
        {
            return this.name;
        }
        public int GetHP()
        {
            return this.currentHP;
        }
    }
}
