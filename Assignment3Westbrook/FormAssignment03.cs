using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CPT230Assignment03Westbrook
{
    public partial class frmAssignment03 : Form
    {
        /* A Basic Text-Based Game using WinForms.
         * The Hero has a limited number of heals and a single-use stun.
         * Replayable with random damage and healing to give different situtations each time. */

        // Initializing variables needed before the game starts
        private int heroHP, villianHP, heroHeal, villianStunned;
        private bool heroTurn, villianIsAlive;
        private Random random;

        // Loading Images from resources
        private Bitmap villainImp = Properties.Resources.villainImp;
        private Bitmap villainWolf = Properties.Resources.villainWolf;
        private Bitmap heroBl_belt = Properties.Resources.heroBl_belt;
        private Bitmap heroBl_mage = Properties.Resources.heroBl_mage;
        private Bitmap heroFighter = Properties.Resources.heroFighter;
        private Bitmap heroRedmage = Properties.Resources.heroRedmage;
        private Bitmap heroThief = Properties.Resources.heroThief;
        private Bitmap heroWh_mage = Properties.Resources.heroWh_mage;





        public frmAssignment03()
        {
            InitializeComponent();
            // All default values at the beginning of the game
            heroHP = 100;
            villianHP = 100;
            heroHeal = 5;
            random = new Random();
            heroTurn = true;
            villianIsAlive = true;
            villianStunned = 0;
            // Randomize Hero and Villain on Start
            PictureRandomizer();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            ToggleControls(true);
            // Damage villian and change their hp
            villianHP = Damage(random.Next(5, 11), villianHP, txtName.Text, txtVillian.Text);
            // Update Hero
            txtVillianHP.Text = villianHP.ToString();
            pbrVillian.Value = villianHP;

            // Check if hero has won
            if (villianHP == 0)
            {
                txtOutput2.Text =  WinText("Hero") + txtOutput2.Text;
                villianIsAlive = false;
                ToggleVillian(villianIsAlive);
                ToggleControls();
                // These can be manually deactivated if you use them so they don't play well with the toggle method
                btnHeal.Visible = false;
                btnStun.Visible = false;
                // Play button is the only button visible
                btnPlayAgain.Visible = true;
            }
            // Villian's turn
            heroTurn = false;
            heroTurn = VillianTurn(heroTurn);
        }

        private void btnStun_Click(object sender, EventArgs e)
        {
            ToggleControls(true);
            // Change Stun class variable
            villianStunned += 3;
            // Notify Hero
            txtOutput2.Text = $"{txtVillian.Text} is stunned for 3 turns! \r\n" + txtOutput2.Text;
            // End turn
            heroTurn = false;
            // Villian's turn (will be stunned)
            heroTurn = VillianTurn(heroTurn);
            // Single-Use Stun
            btnStun.Visible = false;
        }

        private void btnHeal_Click(object sender, EventArgs e)
        {
            ToggleControls(true);
            int heal = random.Next(15, 26); // Get random heal value
            if (heroHeal > 0)
            {
                if (heroHP + heal >= 100) // only able to heal up to 100
                {
                    heroHP = 100;
                }
                else // add health to Hero
                {
                    heroHP += heal;
                }
                // Show the hero that they've healed
                txtHP.Text = heroHP.ToString();
                pbrHero.Value = heroHP;
                txtOutput2.Text = $"{txtName.Text} heals for {heal}! \r\n" + txtOutput2.Text;
                // Subtract a heal usage
                heroHeal--;
                txtOutput.Text = heroHeal.ToString();
                
            }
            // Disable heal button after the hero is out of heals
            if (heroHeal == 0)
            {
                btnHeal.Visible = false;
            }

            
            heroTurn = false;
            heroTurn = VillianTurn(heroTurn);
        }



        private void Reset()
        {
            // Reset the Hero
            heroHP = 100;
            txtHP.Text = heroHP.ToString();
            heroHeal = 5;
            txtOutput.Text = heroHeal.ToString();
            pbrHero.Value = heroHP;
            btnStun.Enabled = true;
            btnHeal.Enabled = true;
            btnStun.Visible = true;
            btnHeal.Visible = true;

            // Reset the Villian
            villianHP = 100;
            txtVillianHP.Text = villianHP.ToString();
            pbrVillian.Value = villianHP;
            villianStunned = 0;
            ToggleVillian(villianIsAlive);

            // Reset the Output
            txtOutput2.Text = "";

            // Reset Turn
            heroTurn = true;

            // Randomize Hero and Villain
            PictureRandomizer();
        }



        private void ToggleVillian(bool villianIsAlive)
        {
            if (villianIsAlive == false) // Hide all villian controls
            {
                txtVillianHP.Visible = !txtVillianHP.Visible;
                lblHPVillian.Visible = !lblHPVillian.Visible;
                txtVillian.Visible = !txtVillian.Visible;
                lblVillian.Visible = !lblVillian.Visible;
                pbxVillian.Visible = !pbxVillian.Visible;
                pbrVillian.Visible = !pbrVillian.Visible;
            }
            
            
        }

        private void ToggleControls(bool hide = false) // Hide all Hero controls
        {
            if (hide == true)
            {
                btnAttack.Enabled = !btnAttack.Enabled;
                btnStun.Enabled = !btnStun.Enabled;
                btnHeal.Enabled = !btnHeal.Enabled;
            }
            else
            {
                btnAttack.Visible = !btnAttack.Visible;
                btnStun.Visible = !btnStun.Visible;
                btnHeal.Visible = !btnHeal.Visible;
            }

        }

        private int Damage(int damage, int hp, string attacker, string attacked) // Generalized this code to make this easier for future enemies to damage the hero or the hero to damage other enemies
        {
            if (damage >= hp) // Not able to overkill
            {
                hp = 0;
                txtOutput2.Text = $"The {attacker} hit the {attacked} for " + hp + "!\r\n" + $"The {attacked} falls over in agony!" + txtOutput2.Text;
            }
            else
            {
                hp -= damage;
                txtOutput2.Text = $"The {attacker} hit the {attacked} for " + damage + "!\r\n" + txtOutput2.Text;

            }
            return hp; // Only returning HP. This method just calculates the damage and outputs the text
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            // Hide the Play Again button
            btnPlayAgain.Visible = false;
            // Make the controls visible
            ToggleControls();

            // Reset the game
            Reset();
        }

        public bool VillianTurn(bool heroTurn)
        {
            
            Application.DoEvents();
            // One Second Sleep Before Villian's Turn
            Thread.Sleep(1000);
            // Re-enable Hero Buttons
            ToggleControls(true);

            // Check if the villian is alive before taking their turn
            if (villianIsAlive == true)
            {
                // Check if it is the villian's turn, and make sure the villian isn't stunned
                if (heroTurn == false && villianStunned == 0)
                {
                    // Get the villian's decision
                    int villianChoice = random.Next(1, 3);

                    // Villian's action (trying out a switch)
                    switch (villianChoice)
                    {
                        case 1: // Attack
                            heroHP = Damage(random.Next(12, 20), heroHP, txtVillian.Text, txtName.Text);
                            txtHP.Text = heroHP.ToString();
                            pbrHero.Value = heroHP;

                            // Check if the hero is dead
                            if (heroHP == 0)
                            {
                                // Losing text
                                txtOutput2.Text = WinText("Villian") + txtOutput2.Text;
                                // Disable Controls for Hero and Show Play Again button
                                btnPlayAgain.Visible = true;
                                ToggleControls();
                                // These can be manually deactivated if you use them so they don't play well with the toggle method
                                btnHeal.Visible = false;
                                btnStun.Visible = false;

                            }
                            break;

                        case 2: // Heal
                        
                            if (villianHP <= 98)
                            {
                                villianHP += 2;
                                txtVillianHP.Text = villianHP.ToString();
                                pbrVillian.Value = villianHP;
                                txtOutput2.Text = $"{txtVillian.Text} heals for 2! \r\n" + txtOutput2.Text;
                            }
                            else // Only able to heal up to 100 HP
                            {
                                villianHP = 100;
                                txtVillianHP.Text = villianHP.ToString();
                                pbrVillian.Value = 100;
                                txtOutput2.Text = $"{txtVillian.Text} heals to full! \r\n" + txtOutput2.Text;
                            }
                            break;

                        default: // No action. Catch-all for bugs
                            txtOutput2.Text = $"{txtVillian.Text} prepares an attack! \r\n" + txtOutput2.Text;
                            break;
                    }
                }
            
                if (villianStunned > 0) // Check if stunned
                {
                    txtOutput2.Text = $"{txtVillian.Text} is stunned! \r\n" + txtOutput2.Text;
                    --villianStunned;
                    if (villianStunned == 0) // Notify hero when the villian won't be stunned next turn
                    {
                        txtOutput2.Text = $"{txtVillian.Text} isn't stunned anymore! \r\n" + txtOutput2.Text;
                    }
                }
            }
            return heroTurn = true;
        }

        private string WinText(string winner = "Villian")
        {
            // Villian Wins
            if (winner == "Villian")
            {
                return $"The {winner} defeated the Hero. \r\n";
            }
            // Hero Wins
            else
            {
                return $"The {winner} defeated the Villian. \r\n";
            }
        }

        public void PictureRandomizer()
        {
            // Randomize the hero and villain pictures. These images are added to the resources for this solution
            //

            int heroPicture = random.Next(1, 7);
            int villainPicture = random.Next(1, 3);

            // More practice with switches. I tried an enumerator here but struggled to understand using attributes with enums
            switch (heroPicture)
            {
                case 1:
                    pbxHero.Image = heroBl_belt;
                    break;
                case 2:
                    pbxHero.Image = heroBl_mage;
                    break;
                case 3:
                    pbxHero.Image = heroFighter;
                    break;
                case 4:
                    pbxHero.Image = heroRedmage;
                    break;
                case 5:
                    pbxHero.Image = heroWh_mage;
                    break;
                case 6:
                    pbxHero.Image = heroThief;
                    break;
                default:
                    break;
            }

            switch (villainPicture)
            {
                case 1:
                    pbxVillian.Image = villainImp;
                    break;
                case 2:
                    pbxVillian.Image = villainWolf;
                    break;
                default:
                    break;
            }
            txtOutput2.Text += "Pictures Randomized";
        }
    }
}
