using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPT230InClass05
{
    public partial class GameControllerForm : Form
    {
        Form FightForm;
        // creating basic lists to store game data
        // list of strings of win/loss (that is shown on label and a ListView)
        List<String> gameResults = new List<string>(1);
        // list of strings that store the game's txtOutput and can display it via the txtSummary 
        List<String> gameHistory = new List<string>(1);
        // list of booleans that store true/false for win/loss
        List<bool> gameWinRate = new List<bool>(1);
        // list of decimals that store historical win rates after each game
        List<decimal> gameWinRateDecimal = new List<decimal>(1);
        // Simple boolean that is changed when the user clicks the advanced details button (toggle visibility of advanced controls)
        bool advancedInfoHidden = true;

        

        public GameControllerForm()
        {
            InitializeComponent();

            this.Height = 357;
            this.Width = 394;
            // Helpful resource - also used https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datavisualization.charting.chart?view=netframework-4.8
            // https://stackoverflow.com/questions/5011421/c-sharp-dashed-lines-in-chart-series
            // this makes the Y axis not go up to 120%, it stays at the maximum win rate (100% at maximum OR the maximum win rate so far)
            chrtGameResults.ChartAreas[0].AxisY.IsMarginVisible = false;
            // Adding title here since I wasn't sure how to do this within the designer
            chrtGameResults.Titles.Add("Wins").Text = "Win Rate";
            this.chrtGameResults.Titles[0].Font = new System.Drawing.Font("Times New Roman", 16, System.Drawing.FontStyle.Bold);

        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Visible = false; //turns this form's visibility off
            
            DialogResult  result = FightForm.ShowDialog(); // displays fight form. showdialog returns a dialog result
            // 2 main ways to pass info
            //dialog result (Cancel, Ok, Yes, None, No, Abort)
            //Tags
            this.Visible = true;
            if (result == DialogResult.Yes)
            {
                // Our label text
                this.lblDidWeWin.Text = "We Won";
                // Our Summary text box
                txtSummary.Text = (string)FightForm.Tag;
                // Our actual win/loss data in boolean form
                gameWinRate.Add(true);
            }
            else if (result == DialogResult.No)
            {
                // Our label text
                this.lblDidWeWin.Text = "We Lost";
                // Our Summary text box
                txtSummary.Text = (string)FightForm.Tag;
                // Our actual win/loss data in boolean form
                gameWinRate.Add(false);
            }
            else
            {
                // Our label text
                this.lblDidWeWin.Text = "We Lost";
                // Our actual win/loss data in boolean form
                gameWinRate.Add(false);
            }
            // Sets the lists to contain the data for future usage (Win rate Chart, List View Box, List of Win/Loss, and List of Historical Win Rate)
            UpdateGameResultsAndHistory();
        }
        private void UpdateGameResultsAndHistory()
        {
            // Game results
            int count = gameResults.Count + 1;
            string newResult = String.Format("Game {0}: {1}", count,  lblDidWeWin.Text);
            gameResults.Add(newResult);
            lstboxGameResults.Items.Add(newResult);
            lstboxGameResults.SelectedIndex = count - 1;

            // Game History
            gameHistory.Add(txtSummary.Text);

            // Game WinRate
            decimal wins = 0;
            decimal losses = 0;
            // count our wins and losses each time we play a game. Could optimize this if performance issues arise
            foreach (bool result in gameWinRate)
            {
                if (result == true)
                {
                    wins += 1;
                }
                else
                {
                    losses += 1;
                }
            }
            // Getting current win rate
            decimal winRate = (wins / (wins + losses)) * 100;
            // Logging win rate for historical chart
            gameWinRateDecimal.Add(winRate);
            //lblWinRate.Text = String.Format("Wins: {0} Losses: {1}", wins, losses); // old way to show Wins and Losses not in a win rate format
            lblWinRate.Text = String.Format("Win Rate: {0:N1}%", winRate);

            // Game Results Chart
            // get rid of all of our points
            chrtGameResults.Series["Game Results"].Points.Clear();
            // create all of our points each time we play a game. Could optimize this if performance issues arise
            for (int i = 0; i < gameResults.Count; i++)
            {
                //https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-5.0
                // Find the position of the ":" so that we can always display the game #, regardless of length
                int gameX = gameResults[i].IndexOf(":");
                // Add the X, Y coordinates (with X being the Game # and Y being the win rate %)
                chrtGameResults.Series["Game Results"].Points.AddXY(gameResults[i].Substring(0, gameX), gameWinRateDecimal[i]);
            }
            
        }

        private void GameControllerForm_Load(object sender, EventArgs e)
        {
            // Create a new game at load
            FightForm = new FFClone();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // Make sure we have a game, and we have a game selected
            if (gameHistory.Count > 0 && lstboxGameResults.SelectedIndex >= 0)
            {
                // Our current game selected
                int number = lstboxGameResults.SelectedIndex;
                // output the data to the summary box
                txtSummary.Text = gameHistory[number];
            }
            // If we can't validate our selection, show this in the summary box
            else
            {
                txtSummary.Text = "Select an item to show first!";
            }
            
        }

        // I wanted to try to mess with form sizing to display different controls
        // Decided to go with "Simple vs. Advanced View"
        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            // Turned this into a basic toggle. If the data is hidden when we click this button, show the data
            if (advancedInfoHidden)
            {
                btnHistory.Visible = true;
                lstboxGameResults.Visible = true;
                chrtGameResults.Visible = true;
                // hard-coded height/width
                GameControllerForm.ActiveForm.Height = 657;
                GameControllerForm.ActiveForm.Width = 846;
                advancedInfoHidden = false;
            }
            //If the data is shown when we click this button, hide the data
            else
            {
                btnHistory.Visible = false;
                lstboxGameResults.Visible = false;
                chrtGameResults.Visible = false;
                // hard-coded height/width
                GameControllerForm.ActiveForm.Height = 357;
                GameControllerForm.ActiveForm.Width = 394;
                advancedInfoHidden = true;
            }

        }
    }
}
