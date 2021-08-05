using System.Collections.Generic;
using System.Windows.Forms;

namespace CPT230InClass05
{
    class Thief : Hero
    {
        private List<Spell> spellList;

        public Thief() : base()
        {
            spellList = new List<Spell>();
            spellList.Add(new Fire1());
        }

        public Thief(ProgressBar pbrHP, ProgressBar pbrMP, Label lblName, Label lblHP,
            PictureBox pbxImage, string name, int maxHP, int currentHP,
            int maxMP, int currentMP, int strength, int magiStrength,
            int defense) : base(pbrHP, pbrMP, lblName, lblHP,
            pbxImage, name, maxHP, currentHP,
            maxMP, currentMP, strength, magiStrength,
            defense)
        {
            spellList = new List<Spell>();
            spellList.Add(new Fast1());
        }

        public override Damage MagicAttack(string attackName)//take a string type????
        {
            Spell spell;
            switch (attackName)
            {
                case "Fast 1":
                    spell = new Fast1();
                    spell.CalculateDamage(this.strength);
                    this.currentMP -= spell.Cost;
                    this.pbrMP.Value = currentMP;
                    break;
                default:
                    spell = new Fast1();
                    spell.CalculateDamage(this.strength);
                    this.currentMP -= spell.Cost;
                    this.pbrMP.Value = currentMP;
                    break;
            }
            return spell.TheDamage;
        }
        public override List<Spell> GetSpells()
        {
            return spellList;
        }
    }
}
