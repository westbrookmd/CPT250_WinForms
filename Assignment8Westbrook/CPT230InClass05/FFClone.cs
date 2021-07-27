using System;
using System.Collections.Generic;
using System.Windows.Forms;
/*
 * Marshall Westbrook
 * CPT230
 * 2021SU
 * Assignment 08
 */

namespace CPT230InClass05
{
    public partial class FFClone : Form
    {
        // setting up class variables
        private const int PARTY_SIZE = 4;
        private Hero[] heroes;
        private Villian villian;
        private int turnCount;
        private Queue<int> roundTracker;
        private Random random;
        private Spella Fire;
        private Spella Ice;
        private Spella Thunder;
        private DateTime startTime;
        private DateTime endTime;
        public FFClone()
        {
            InitializeComponent();
        }
        private void FFClone_Load(object sender, EventArgs e)
        {


            startTime = DateTime.Now;


            cbxSpell.Items.Add("Fire 1");
            cbxSpell.Items.Add("Ice 1");
            cbxSpell.Items.Add("Thunder 1");

            // Adding Spell Types. Spell logic is stored within spell class
            Fire = new Spella("Fire");
            Ice = new Spella("Ice");
            Thunder = new Spella("Thunder");

            // call villian class here
            villian = new Villian(pbrVHP, lblVName, new Label(), pbrV, "The Big Bad Wolf", 300, 300, 0, 0, 25, 0, 5);


            // setup hero array
            heroes = new Hero[PARTY_SIZE];

            //setup each hero. Restructured fighter as a tank, thief as a melee version of the black mage
            heroes[0] = new Hero(pbrH0, pbrH0MP, lblHName0, lblHHP0, pbxH0, "Fighter",    100, 100, 15, 15, 5,  2,  25);
            heroes[1] = new Hero(pbrH1, pbrH1MP, lblHName1, lblHHP1, pbxH1, "Thief",      85,  85, 15,  15, 15, 2,  8);
            heroes[2] = new BlackMage(pbrH2, pbrH2MP, lblHName2, lblHHP2, pbxH2, "Black Mage", 65,  65, 15, 15, 3, 20, 5);
            heroes[3] = new Hero(pbrH3, pbrH3MP, lblHName3, lblHHP3, pbxH3, "White Mage", 75,  75, 15, 15, 2, 10, 7);

            // setup rounds
            turnCount = 0;
            roundTracker = new Queue<int>();
            SetupRound();
            random = new Random();
            // Starting text
            this.Text = String.Format("Fight with {0}!", villian.GetName());


            

        }
        // Setup round method
        private void SetupRound()
        {

            // for everyone in the party, add each hero to the queue that's alive
            for (int i = 0; i < PARTY_SIZE; i++)
            {
                if (heroes[i].IsAlive())
                {
                    roundTracker.Enqueue(i);
                }
            }
            // add the villian
            roundTracker.Enqueue(PARTY_SIZE); // this is the villian
        }

        private void SetupTurn()
        {
            if (roundTracker.Count > 0) // if the round isn't over
            {
                
                cbxSpell.Items.Clear();
                List<Spell> spells = heroes[turnCount].GetSpells();
                foreach (Spell spell in spells)
                {
                    if (spell.Cost <= heroes[turnCount].GetMP())
                    {
                        cbxSpell.Items.Add(spell.DisplayName());
                    }
                }
            }
            else
            {
                VillianGoes();
            }
        }

            private void btnAttack_Click(object sender, EventArgs e)
        {
            if (roundTracker.Count > 0) // if the round isn't over
            {
                turnCount = roundTracker.Dequeue();
                //turnCount = roundTracker.Dequeue();
                SetupTurn();
                Damage damage = heroes[turnCount].Attack();
                damage = villian.TakeDamage(damage);
                txtOutput.Text = String.Format("{0} hit the {1} for {2}!\r\n", heroes[turnCount].GetName(), villian.GetName(), damage.Amount) + txtOutput.Text;
                // see if villian is dead
                if (!villian.IsAlive())
                {
                    WeWon();
                }
                else if (roundTracker.Count == 1) //villian's turn since he's always the last 
                {
                    // Villian's turn
                    VillianGoes();
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
            txtOutput.Text = String.Format("The heroes lost...\r\n {0}", txtOutput.Text);            // Disable Buttons
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



        private void cbxSpell_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSpell_Click(object sender, EventArgs e)
        {
            if (roundTracker.Count > 0) // if the round isn't over
            {
                turnCount = roundTracker.Dequeue();

                Damage damage = heroes[turnCount].Attack();
                damage.Amount = 10;
                damage.Type = "Fire";
                damage = villian.TakeDamage(damage);
                txtOutput.Text = String.Format("{0} hit the {1} for {2}!\r\n", heroes[turnCount].GetName(), villian.GetName(), damage.Amount) + txtOutput.Text;
                // see if villian is dead
                SetupTurn();
                if (!villian.IsAlive())
                {
                    WeWon();
                }
                else if (roundTracker.Count == 1) //villian's turn since he's always the last 
                {
                    // Villian's turn
                    VillianGoes();
                }
            }


            /*
            if (roundTracker.Count > 0 && heroes[turnCount].ManaAvailable()) // if the round isn't over and the character has MP
            {
                Damage damage;
                turnCount = roundTracker.Dequeue();
                if (cbxSpell.SelectedIndex != -1)
                {
                    switch (cbxSpell.SelectedItem)
                    {
                        // The Villian's TakeDamage method contains its strengths and weaknesses

                        case "Fire 1":
                            damage = heroes[turnCount].MagicAttack(Fire, "Fire");
                            txtOutput.Text = String.Format("{0} is strong against {1}!\r\n", villian.GetName(), Fire.Type) + txtOutput.Text;
                            break;
                        case "Ice 1":
                            damage = heroes[turnCount].MagicAttack(Ice, "Ice");
                            txtOutput.Text = String.Format("{0} is weak to {1}!\r\n", villian.GetName(), Ice.Type) + txtOutput.Text;

                            break;
                        case "Thunder 1":
                            damage = heroes[turnCount].MagicAttack(Thunder, "Thunder");
                            break;
                        default:
                            damage = new Damage(10, "Magic");
                            break;
                    }
                }
                else
                {
                    damage = new Damage(10, "Magic");
                }
                damage = villian.TakeDamage(damage);
                txtOutput.Text = String.Format("{0} hit the {1} for {2}!\r\n", heroes[turnCount].GetName(), villian.GetName(), damage.Amount) + txtOutput.Text;
                // see if villian is dead
                if (!villian.IsAlive())
                {
                    WeWon();
                }
                else if (roundTracker.Count == 1) //villian's turn since he's always the last 
                {
                    damage = VillianGoes();
                }
            }
            else
            {
                txtOutput.Text = String.Format("{0} is out of Mana! \r\n", heroes[turnCount].GetName()) + txtOutput.Text;
            }
            */
        }

        private Damage VillianGoes()
        {
            Damage damage;
            //villian goes here
            roundTracker.Dequeue();
            damage = villian.Attack();
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
            txtOutput.Text = String.Format("{0} hit the {1} for {2}!\r\n", villian.GetName(), heroes[target].GetName(), damage.Amount) + txtOutput.Text;
            if (DidWeLose())
            {
                WeLost();
            }
            SetupRound();
            return damage;
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

            private void btnRetry_Click(object sender, EventArgs e)
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
            roundTracker.Clear();
            SetupRound();
            txtOutput.Text = String.Format("Fight with {0}!", villian.GetName());
        }
    }
}
