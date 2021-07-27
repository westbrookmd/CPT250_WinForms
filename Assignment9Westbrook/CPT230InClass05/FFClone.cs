using System;
using System.Collections.Generic;
using System.Windows.Forms;
/*
 * Marshall Westbrook
 * CPT230
 * 2021SU
 * Assignemnt 9
 */
namespace CPT230InClass05
{
    public partial class FFClone : Form
    {
        private const int PARTY_SIZE = 4;
        private Hero[] heroes;
        private Villian villian;
        private int turnCount;
        private Queue<int> roundTracker;
        private Random random;
        private DateTime startTime;
        private DateTime endTime;
        public FFClone()
        {
            InitializeComponent();
        }
        private void FFClone_Load(object sender, EventArgs e)
        {
            startTime = DateTime.Now;

            villian = new Villian(pbrVHP, lblVName, new Label(), pbrV, "The Big Bad Wolf", 300, 300, 0, 0, 30, 0, 5);


            //setup hero array
            heroes = new Hero[PARTY_SIZE];

            //setup each hero

            heroes[0] = new Fighter(pbrH0, pbrH0MP, lblHName0, lblHHP0, pbxH0, "Fighter", 100, 100, 5, 5, 20, 10, 15);
            heroes[1] = new Thief(pbrH1, pbrH1MP, lblHName1, lblHHP1, pbxH1, "Thief", 85, 85, 7, 7, 15, 15, 10);
            heroes[2] = new BlackMage(pbrH2, pbrH2MP, lblHName2, lblHHP2, pbxH2, "Black Mage", 65, 65, 7, 7, 10, 30, 5);
            heroes[3] = new WhiteMage(pbrH3, pbrH3MP, lblHName3, lblHHP3, pbxH3, "White Mage", 75, 75, 7, 7, 15, 20, 7);

            roundTracker = new Queue<int>();
            SetupRound();
            SetupTurn();
            random = new Random();

            this.Text = String.Format("Fight with {0}!", villian.GetName());

        }
        private void SetupRound()
        {
            for (int i = 0; i < PARTY_SIZE; ++i)
            {
                if (heroes[i].IsAlive())
                {
                    roundTracker.Enqueue(i);
                }
            }
        }

        private void SetupTurn()
        {
            if (roundTracker.Count > 0)
            {
                turnCount = roundTracker.Dequeue();
                cbxSpell.Items.Clear();
                List<Spell> spells = heroes[turnCount].GetSpells();
                foreach (Spell spell in spells)
                {
                    if (spell.Cost <= heroes[turnCount].GetMP())
                    {
                        cbxSpell.Items.Add(spell.DisplayName());
                    }
                }
                if (cbxSpell.Items.Count > 0)
                {
                    cbxSpell.SelectedIndex = 0;
                }
            }
            else 
            {
                turnCount = 99;
            }
            if (cbxSpell.Items.Count == 0)
            {
                bntSpell.Enabled = false;
            }
            else 
            {
                bntSpell.Enabled = true;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (roundTracker.Count >= 0)
            {
                Damage damage = heroes[turnCount].Attack();
                damage = villian.TakeDamage(damage);
                txtOutput.Text = String.Format("{0} hit {1} for {2}!\r\n", heroes[turnCount].GetName(), villian.GetName(), damage.Amount) + txtOutput.Text;
                SetupTurn();

                //see if villian is dead
                if (!villian.IsAlive())
                {
                    WeWon();
                }

                else if (turnCount == 99)
                {
                    //villian goes
                    damage = VilliansTurn();
                }
            }

        }

        private void WeWon()
        {
            txtOutput.Text = String.Format("The heroes win!!!\r\n{0}", txtOutput.Text);
            // Diable Buttons
            btnAttack.Enabled = false;
            bntSpell.Enabled = false;
            cbxSpell.Enabled = false;
            // Show retry and timer
            btnRetry.Visible = true;
            TimeTaken();
        }

        private void WeLost()
        {
            txtOutput.Text = String.Format("The heroes lost...\r\n {0}", txtOutput.Text);
            // Disable Buttons
            btnAttack.Enabled = false;
            bntSpell.Enabled = false;
            cbxSpell.Enabled = false;
            // Show retry and timer
            btnRetry.Visible = true;
            TimeTaken();
        }
        private bool DidWeLose()
        {
            int totalHp = 0;
            foreach (Hero hero in heroes)
            {
                totalHp += hero.GetHP();
            }
            return totalHp == 0;
        }
        private void TimeTaken()
        {
            // Get end time
            endTime = DateTime.Now;
            // Create a double that holds the result of the start of the round less than the current time 
            double timeTaken = (endTime - startTime).TotalSeconds;
            // Display two decimal places
            lblTimer.Text = String.Format("Time Taken: {0:f2} seconds", timeTaken);
            // Make the time taken label visible
            lblTimer.Visible = true;

        }
#pragma warning disable IDE1006 // Naming Styles
        private void btnRetry_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            //Reset each hero
            foreach (Hero hero in heroes)
            {
                hero.Reset();
            }
            //Reset Villian
            villian.Reset();
            txtOutput.Text = "";
            lblTimer.Visible = false;
            // restart timer here
            startTime = DateTime.Now;
            // reset buttons
            btnRetry.Visible = false;
            btnAttack.Enabled = true;
            bntSpell.Enabled = true;
            cbxSpell.Enabled = true;

            // reset turns
            turnCount = 0;
            roundTracker.Clear();
            // reset game's turn system and output
            SetupRound();
            SetupTurn();
            txtOutput.Text = String.Format("Fight with {0}!", villian.GetName());
            // Game is now ready for player's click
        }

#pragma warning disable IDE1006 // Naming Styles
        private void bntSpell_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (cbxSpell.Items.Count == 0)
            { }
            else if (roundTracker.Count >= 0)
            {
                Damage damage = heroes[turnCount].MagicAttack(cbxSpell.SelectedItem.ToString());
                damage = villian.TakeDamage(damage);
                txtOutput.Text = String.Format("{0} hit {1} for {2} with {3}!\r\n", heroes[turnCount].GetName(), villian.GetName(), damage.Amount, cbxSpell.SelectedItem.ToString()) + txtOutput.Text;
                SetupTurn();

                //see if villian is dead
                if (!villian.IsAlive())
                {
                    WeWon();
                }
                // Villian's turn
                else if (turnCount == 99)
                {
                    damage = VilliansTurn();
                }
            }
        }

        private Damage VilliansTurn()
        {
            //if we're at 99 turncount, it's the villian's turn
            Damage damage = villian.Attack();
            bool pickIsDead = true;
            int target = 0;
            while (pickIsDead)
            {
                target = random.Next(0, 4);
                if (heroes[target].IsAlive())
                {
                    pickIsDead = false;
                }
            }
            damage = heroes[target].TakeDamage(damage);
            txtOutput.Text = String.Format("{0} hit {1} for {2}!\r\n", villian.GetName(), heroes[target].GetName(), damage.Amount) + txtOutput.Text;
            //Did we lose
            if (DidWeLose())
            {
                WeLost();

            }

            SetupRound();
            SetupTurn();
            return damage;
        }
    } 
}
