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
        private ProgressBar pbrMP;
        private Label lblName;
        private Label lblHP;
        private PictureBox pbxImage;
        private string name;

        private int maxHP;
        private int currentHP;
        private int maxMP;
        protected int currentMP;
        private int strength;
        protected int magiStrength;
        private int defense;
        private Random random;

        //Constructors
        public Hero()
        {
            this.pbrHP = new ProgressBar();
            this.pbrMP = new ProgressBar();
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
        public Hero(ProgressBar pbrHP, ProgressBar pbrMP, Label lblName, Label lblHP, PictureBox pbxImage, string name, int maxHP, 
            int currentHP, int maxMP, int currentMP, int strength, int magiStrength, int defense)
        {
            this.pbrHP = pbrHP;
            this.pbrMP = pbrMP;
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
            this.pbrMP.Maximum = maxMP;
            this.pbrMP.Value = currentMP;
        }
        public Damage Attack()
        {
            int damage = random.Next(strength, strength * 2);
            string type = "Physical";
            return new Damage(damage, type);
        }
        public virtual Damage MagicAttack(Spell attackName)//take a string type
        {
            int damage;
            // Remove mana
            RemoveMP();
            // Check spell types and get their power from spell class

            return new Damage(0, "Fire");
        }

        private void RemoveMP()
        {
            this.currentMP -= 1;
            this.pbrMP.Value = currentMP;
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
        // could change image or name here. Not opting to do this
        public bool IsAlive()
        {
            return this.currentHP > 0;
            // change image to tombstone if dead
        }
        // Do we have mana?
        public bool ManaAvailable()
        {
            return this.currentMP > 0;
        }
        // Gets the hero name
        public string GetName()
        {
            return this.name;
        }
        // Gets the hero hp
        public int GetHP()
        {
            return this.currentHP;
        }
        public int GetMP()
        {
            return this.currentMP;
        }
        public void Reset()
        {
            // Reset Health
            this.currentHP = this.maxHP;
            this.pbrHP.Value = currentHP;
            this.lblHP.Text = currentHP.ToString();
            // Reset Mana
            this.currentMP = this.maxMP;
            this.pbrMP.Value = currentMP;
        }
        public virtual List<Spell> GetSpells()
        {
            return new List<Spell>();
        }
    }
}
