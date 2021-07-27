using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPT230InClass05
{
    class BlackMage : Hero
    {
        private List<Spell> spellList;

        public BlackMage() : base()
        {
            spellList = new List<Spell>();
            spellList.Add(new Fire1());
        }

        public BlackMage(ProgressBar pbrHP, ProgressBar pbrMP, Label lblName, Label lblHP, PictureBox pbxImage, string name, int maxHP,
            int currentHP, int maxMP, int currentMP, int strength, int magiStrength, int defense) : base( pbrHP,  pbrMP,  lblName,  lblHP,  pbxImage,  name,  maxHP,
             currentHP,  maxMP,  currentMP,  strength,  magiStrength,  defense)
        {
            spellList = new List<Spell>();
            spellList.Add(new Fire1());
        }


        public override Damage MagicAttack(Spell attackName)
        {
            switch (attackName.DisplayName())
            {
                case "Fire1":
                    attackName = new Fire1();
                    attackName.CalculateDamage(magiStrength);
                    this.currentMP -= attackName.Cost;
                    break;

                default:
                    attackName = new Fire1();
                    attackName.CalculateDamage(magiStrength);
                    this.currentMP -= attackName.Cost;
                    break;
            }
            return attackName.TheDamage;
        }

        public override List<Spell> GetSpells()
        {
            return spellList;
        }
    }
}
