using System;
using System.Windows.Forms;
/*
 * Marshall Westbrook
 * CPT230
 * 2021SU
 * Assignment0607
 */
namespace CPT230InClass05
{
    public partial class frmAssignment0607 : Form
    {
        private const int PARTY_SIZE = 4;
        private PictureBox[] heroPics;
        private Label[] heroNames;
        private Label[] heroHPs;
        private ProgressBar[] heroBars;
        private int[] hHPs;
        private int vHP;
        private int turnCount;
        private Random random;
        private DateTime startTime;
        private DateTime endTime;

        public frmAssignment0607()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Setting up the Timer
            startTime = DateTime.Now;

            // Setting up the Spells
            cbxSpell.Items.Add("Fire 1");
            cbxSpell.Items.Add("Ice 1");
            cbxSpell.Items.Add("Thunder 1");
            cbxSpell.Items.Add("Heal 1");

            // Setting hero hps
            hHPs = new int[PARTY_SIZE];
            hHPs[0] = 100;
            hHPs[1] = 100;
            hHPs[2] = 100;
            hHPs[3] = 100;

            vHP = 300;

            //Setting up Picture Box array
            heroPics = new PictureBox[PARTY_SIZE];
            heroPics[0] = pbxH0;
            heroPics[1] = pbxH1;
            heroPics[2] = pbxH2;
            heroPics[3] = pbxH3;

            //Setting up the Hero names labels
            heroNames = new Label[PARTY_SIZE];
            heroNames[0] = lblHName0;
            heroNames[1] = lblHName1;
            heroNames[2] = lblHName2;
            heroNames[3] = lblHName3;
            heroNames[0].Text = "Fighter";
            heroNames[1].Text = "Theif";
            heroNames[2].Text = "Black Mage";
            heroNames[3].Text = "White Mage";

            //Setting up the Hero HP labels
            heroHPs = new Label[PARTY_SIZE];
            heroHPs[0] = lblHHP0;
            heroHPs[1] = lblHHP1;
            heroHPs[2] = lblHHP2;
            heroHPs[3] = lblHHP3;
            for (int i = 0; i < heroHPs.Length; ++i)
            {
                heroHPs[i].Text = hHPs[i].ToString();
            }

            //Setting up the Hero pBars
            heroBars = new ProgressBar[PARTY_SIZE];
            heroBars[0] = pbrH0;
            heroBars[1] = pbrH1;
            heroBars[2] = pbrH2;
            heroBars[3] = pbrH3;

            turnCount = 0;

            random = new Random();
        }
        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAttack_Click(object sender, EventArgs e)
        {

            // Set label with attack text
            txtOutput.Text =  String.Format("{0}\r\n{1}", DamageVillian(HeroAttack(), heroNames[turnCount].Text), txtOutput.Text);
            if (IsVDead())
            {
                HerosWin();
            }
            else
            {
                if (NextCharactersTurn())
                {
                    VillianTurn();
                }
            }
        }

        // Potentially change this - currently spells are more effective in every way
        private int HeroAttack()
        {
            return random.Next(5, 21);
        }


        private string DamageVillian(int damage, string attacker)
        {
            string summary;
            // Make sure we aren't overkilling
            if (damage > vHP)
            {
                // set to max dps and defeat the wolf
                damage = vHP;
                summary = String.Format("{0} defeated the wolf!!!\r\n", attacker);
            }
            // unique text for damage
            else 
            {
                summary = String.Format("{0} hit the wolf for {1}!", attacker, damage.ToString());
            }
            // Doing damage
            vHP -= damage;
            pbrVHP.Value = vHP;
            return summary;
        }

        private string HealSelf(int heal, string healer)
        {
            string summary;
            // Check that we won't overheal
            if ((heal + hHPs[turnCount]) >= heroBars[turnCount].Maximum)
            {
                // if we overheal, use this text
                heal = heroBars[turnCount].Maximum - hHPs[turnCount];
                summary =  String.Format("{0} healed themself to full HP! \r\n", healer);
            }
            else
            {
                // if we aren't overhealing return this
                summary =  String.Format("{0} healed themself for {1}! \r\n", healer, heal.ToString());
            }
            // Do the healing and update GUI
            hHPs[turnCount] += heal;
            heroHPs[turnCount].Text = hHPs[turnCount].ToString();
            heroBars[turnCount].Value = hHPs[turnCount];
            return summary;
        }


        // Check if the villian is dead
            private bool IsVDead()
        {
            return vHP == 0;
        }

        private bool IsDead(int hp)
        {
            return hp == 0;
        }

        private bool DidWeLose(int[] hps)
        {
            // Could potentially change this if we add unusual classes that go under 0 hp.
            // Check that we have at least 1 hp
            int totalHp = 0;
            foreach (int hp in hps)
            {
                totalHp += hp;
            }
            return totalHp == 0;
        }

        private bool NextCharactersTurn()
        {
            // DidWeLose should be called before using this method
            bool villianTurn = false;
            // Make sure it's a hero turn
            if (turnCount == PARTY_SIZE - 1)
            {
                villianTurn = true;
            }
            // Set counter
            turnCount = (turnCount + 1) % PARTY_SIZE;
            int count = PARTY_SIZE;
            // Go through each character in the party until we reach party_size - 1
            while (hHPs[turnCount] == 0 && count > 0)
            {
                if (turnCount == PARTY_SIZE - 1)
                {
                    villianTurn = true;
                }
                turnCount = (turnCount + 1) % PARTY_SIZE;
                count--;
            }
            return villianTurn;
        }

        private void VillianTurn()
        {
            // Pick a valid target
            bool pickIsDead = true;
            int target = 0;
            while(pickIsDead)
            {
                target = random.Next(0, 4);
                if (hHPs[target] > 0)
                {
                    pickIsDead = false;
                }
            }
            // Get Damage
            int damage = random.Next(15, 31);
            // Make sure we aren't overkilling
            if (hHPs[target] <= damage)
            {
                damage = hHPs[target];
            }
            // Do damage
            hHPs[target] -= damage;
            heroHPs[target].Text = hHPs[target].ToString();
            heroBars[target].Value = hHPs[target];
            // Check if a hero was KO'ed and check win conditions
            if (hHPs[target] == 0)
            {
                txtOutput.Text = String.Format("{0} was KO'ed!!!\r\n{1}", heroNames[target].Text, txtOutput.Text);
                if (DidWeLose(hHPs))
                {
                    VillianWin();
                }
                // hero turn 
                else if (target == turnCount)
                {
                    NextCharactersTurn();
                }
            }
            // Update label with damage text
            else
            {
                txtOutput.Text = String.Format("{0} was bit for {1}!!!\r\n{2}", heroNames[target].Text, damage, txtOutput.Text);
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSpell_Click(object sender, EventArgs e)
        {
            // If we selected a valid spell
            if (cbxSpell.SelectedIndex != -1)
            {
                // Check these cases
                switch (cbxSpell.SelectedItem)
                {
                    case "Fire 1":
                        Fire1();
                        break;
                    case "Ice 1":
                        Ice1();
                        break;
                    case "Thunder 1":
                        Thunder1();
                        break;
                    case "Heal 1":
                        Heal1();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Fire1()
        {
            // A fairly reliable spell. In between ice1 and Thunder1 in damage
            int damage = random.Next(16, 28);
            // Default output
            string output = String.Format("{0} cast Fire 1 doing {1} damage to {2}! \r\n", heroNames[turnCount].Text, damage, lblVName.Text);
            // Update Label
            txtOutput.Text = output + txtOutput.Text;
            // Do damage
             output = DamageVillian(damage, heroNames[turnCount].Text);
            // Check if we defeated wolf
            if (output.Contains("defeated the wolf!!!" ))
            {
                // Output unique text
                txtOutput.Text = output + txtOutput.Text;
            }
            // Check to make sure we defeated the villian
            if (IsVDead())
            {
                // Output hero win text
                HerosWin();

            }
            else
            {
                if (NextCharactersTurn())
                {
                    VillianTurn();
                }
            }
        }

        public void Ice1()
        {
            // Consistent but lower damage than fire
            int damage = random.Next(20, 22);
            // Default output
            string output = String.Format("{0} cast Ice 1 doing {1} damage to {2}! \r\n", heroNames[turnCount].Text, damage, lblVName.Text);
            // update label
            txtOutput.Text = output + txtOutput.Text;
            // Do Damage
            output = DamageVillian(damage, heroNames[turnCount].Text);
            // Check if we defeated the wolf
            if (output.Contains("defeated the wolf!!!"))
            {
                txtOutput.Text = output + txtOutput.Text;
            }
            if (IsVDead())
            {
                HerosWin();

            }
            else
            {
                if (NextCharactersTurn())
                {
                    VillianTurn();
                }
            }
        }

        public void Thunder1()
        {
            // Inconsistent but much higher potential damage
            int damage = random.Next(5, 50);
            // Default output
            string output = String.Format("{0} cast Thunder 1 doing {1} damage to {2}! \r\n", heroNames[turnCount].Text, damage, lblVName.Text);
            // Update label
            txtOutput.Text = output + txtOutput.Text;
            // Do damage
            output = DamageVillian(damage, heroNames[turnCount].Text);
            // If we defeated the wolf
            if (output.Contains("defeated the wolf!!!"))
            {
                // Show unique output text
                txtOutput.Text = output + txtOutput.Text;
            }
            if (IsVDead())
            {
                HerosWin();

            }
            else
            {
                if (NextCharactersTurn())
                {
                    VillianTurn();
                }
            }
        }

        public void Heal1()
        {
            //  Consistent self-heal
            int heal = random.Next(20, 24);
            // Default output
            string output = String.Format("{0} cast Heal 1 doing {1} healing to themself! \r\n", heroNames[turnCount].Text, heal);
            // Healself and get potential output for if hero will overheal
            string outputHealSelf = HealSelf(heal, heroNames[turnCount].Text);
            // Check if we are overhealing
            if (outputHealSelf.Contains("full"))
            {
                // use this text instead if we heal to full
                output = outputHealSelf;
            }
            // Output to label
            txtOutput.Text = String.Format("{0}{1}", output, txtOutput.Text);
            // Check conditions
            if (IsVDead())
            {
                HerosWin();

            }
            else
            {
                if (NextCharactersTurn())
                {
                    VillianTurn();
                }
            }
        }

        private void HerosWin()
        {
            // Output hero win
            txtOutput.Text = String.Format("The heroes win!!!\r\n{0}", txtOutput.Text);
            // Show timer
            TimeTaken();
            // Diable Buttons
            btnAttack.Enabled = false;
            btnSpell.Enabled = false;
            cbxSpell.Enabled = false;
            // Show retry
            btnRetry.Visible = true;
        }



        private void VillianWin()
        {
            // output villian win
            txtOutput.Text = String.Format("The heroes lost...\r\n {0}", txtOutput.Text);
            // Show timer
            TimeTaken();
            // Disable Buttons
            btnAttack.Enabled = false;
            btnSpell.Enabled = false;
            cbxSpell.Enabled = false;
            // Show retry
            btnRetry.Visible = true;
            // Reset hero hp so we can play again
            ResetHeroes();
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
            // reset villian hp. Can randomize villian name and picture here potentially
            pbrVHP.Value = pbrVHP.Maximum;
            vHP = pbrVHP.Maximum;
            // Make "Time Taken" timer appear and reset start time for next round
            lblTimer.Visible = false;
            startTime = DateTime.Now;
            // Enable playtime buttons
            btnAttack.Enabled = true;
            btnSpell.Enabled = true;
            cbxSpell.Enabled = true;
            // Hide Retry button
            btnRetry.Visible = false;
            // Reset turn so heroes start first
            turnCount = 0;
            bool pickIsDead = true;
            int target = 0;
            while (pickIsDead)
            {
                if (hHPs[target] > 0)
                {
                    pickIsDead = false;
                }
                target++;
            }

        }
        // Use this to reset the game after heroes lose
        private void ResetHeroes()
        {
            // Reset each characters hp, hp label, and hp bar
            for (int i = 0; i < heroHPs.Length; ++i)
            {
                hHPs[i] = 100;
                heroHPs[i].Text = hHPs[i].ToString();
                heroBars[i].Value = hHPs[i];
            }
            // Reset any once per game effects here
        }
    }
}
