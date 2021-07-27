using System;
using System.Collections.Generic;
using System.Windows.Forms;
/*
 * Your Name
 * CPT230
 * 2021SU
 * InClass05
 */

// villian special attack
// update hero health labels
// finish spells
// 

namespace CPT230InClass05
{
    public partial class FFClone : Form
    {
        private const int PARTY_SIZE = 4;
        private Hero[] heroes;
        private Hero villian;
        private int turnCount;
        private Queue<int> roundTracker;
        private Random random;
        private DateTime startTime;
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
            cbxSpell.Items.Add("Heal 1");

            villian = new Hero(pbrVHP, lblVName, new Label(), pbrV, "The Big Bad Wolf", 300, 300, 0, 0, 50, 0, 5);


            // setup hero array
            heroes = new Hero[PARTY_SIZE];

            //setup each hero
            heroes[0] = new Hero(pbrH0, lblHName0, lblHHP0, pbxH0, "Fighter", 100, 100, 5, 5, 20, 10, 15);
            heroes[1] = new Hero(pbrH1, lblHName1, lblHHP1, pbxH1, "Theif", 85, 85, 7, 7, 15, 15, 10);
            heroes[2] = new Hero(pbrH2, lblHName2, lblHHP2, pbxH2, "Black Mage", 65, 65, 15, 15, 10, 30, 5);
            heroes[3] = new Hero(pbrH3, lblHName3, lblHHP3, pbxH3, "White Mage", 75, 75, 10, 10, 15, 20, 7);

            turnCount = 0;
            roundTracker = new Queue<int>();
            SetupRound();
            random = new Random();

            this.Text = String.Format("Fight with {0}!", villian.GetName());
        }
        private void SetupRound()
        {
            for (int i = 0; i < PARTY_SIZE; i++)
            {
                if (heroes[i].IsAlive())
                {
                    roundTracker.Enqueue(i);
                }
            }
            roundTracker.Enqueue(PARTY_SIZE); // this is the villian
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (roundTracker.Count > 0) // if the round isn't over
            {
                turnCount = roundTracker.Dequeue();

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
                    txtOutput.Text = String.Format("{0} hit the {1} for {2}!\r\n", villian.GetName(), heroes[target].GetName(),  damage.Amount) + txtOutput.Text;
                    if (DidWeLoose())
                    {
                        //disable buttons and the like if we lost display as well
                    }
                    SetupRound();
                }
            }

        }

        private void WeWon()
        {
            txtOutput.Text = "The heroes defeated the villian!\r\n" + txtOutput.Text;
            //make bad guy not visible
        }

        private bool DidWeLoose()
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

        private void bntSpell_Click(object sender, EventArgs e)
        {
            if (cbxSpell.SelectedIndex != -1)
            {
                switch (cbxSpell.SelectedItem)
                {
                    case "Fire 1":
                        break;
                    default:
                        break;
                }
                    
            }
        }


        private void btnRetry_Click(object sender, EventArgs e)
        {
            //method to reset hero object
            btnAttack.Enabled = true;
            bntSpell.Enabled = true;
        }
    }
}
