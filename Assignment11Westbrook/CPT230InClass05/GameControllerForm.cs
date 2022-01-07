using CPT230Assignment05;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CPT230InClass05
{
    public partial class GameControllerForm : Form
    {

        /* Marshall Westbrook
     * CPT-230-S73
     * Assignment11 (Final)
     * Summer 2021
     * Three Projects in One
     * Saving and Loading to "C:\WestbrookAssignment11_CPT230_21SU\"
     */

        Form FightForm;
        Form MazeForm;
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
        bool firstTimePlaying = true;
        string mazeposition;
        public int mazePositionOne = 9;
        public int mazePositionTwo = 4;
        public static string baseFileName = "CPT230_WestbrookAssignment11_21SU";
        private string gameResultsFileName = (baseFileName + "_GameResults.txt");
        private string gameHistoryFileName = (baseFileName + "_GameHistory.txt");
        private string gameWinRateFileName = (baseFileName + "_GameWinRate.txt");
        private string gameWinRateDecimalFileName = (baseFileName + "_GameWinRateDecimal.txt");
        private string advancedInfoHiddenFileName = (baseFileName + "_AdvancedInfoHidden.txt");
        private string mazePositionFileName = (baseFileName + "_MazePosition.txt.txt");

        private string path = @"C:\WestbrookAssignment11_CPT230_21SU\";



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

            DialogResult result = FightForm.ShowDialog(); // displays fight form. showdialog returns a dialog result
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
                btnMaze.Visible = true;
                btnPlay.Visible = false;
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
                // Our Summary text box
                txtSummary.Text = (string)FightForm.Tag;
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
            string newResult = String.Format("Game {0}: {1}", count, lblDidWeWin.Text);
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
                else if (result == false)
                {
                    losses += 1;
                }
                else
                {
                    //do nothing
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

            UpdateChart();

        }

        private void UpdateChart()
        {
            chrtGameResults.Series["Game Results"].Points.Clear();
            for (int i = 0; i < gameResults.Count; i++)
            {
                //https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-5.0
                // Find the position of the ":" so that we can always display the game #, regardless of length
                int gameX = gameResults[i].IndexOf(":");
                // Add the X, Y coordinates (with X being the Game # and Y being the win rate %)
                chrtGameResults.Series["Game Results"].Points.AddXY(gameResults[i].Substring(0, gameX), gameWinRateDecimal[i]);
            }
        }

        public void LoadData()
        {
            //update listbox
            lstboxGameResults.Items.Clear();
            foreach (string gameResult in gameResults)
            {
                lstboxGameResults.Items.Add(gameResult);
            }

            decimal wins = 0;
            decimal losses = 0;

            foreach (bool result in gameWinRate)
            {
                if (result == true)
                {
                    wins += 1;
                }
                else if (result == false)
                {
                    losses += 1;
                }
                else
                {
                    //nothing
                }
            }
            if (wins == 0 || losses == 0)
            {
                lblWinRate.Text = String.Format("Wins: {0}", wins);
            }
            else
            {
                decimal winRate = (wins / (wins + losses)) * 100;
                lblWinRate.Text = String.Format("Win Rate: {0:N1}%", winRate);
            }

            //update chart
            UpdateChart();
            //Update GUI
            AdvancedInfoToggle();
            //update maze
            //frmMaze.mazePositionOne = mazePositionOne;
            //frmMaze.mazePositionTwo = mazePositionTwo;
            MazeForm = new frmMaze(mazePositionOne, mazePositionTwo, false);

        }

        private void GameControllerForm_Load(object sender, EventArgs e)
        {
            // Create a new game at load
            FightForm = new FFClone();
            MazeForm = new frmMaze(mazePositionOne, mazePositionTwo, firstTimePlaying);
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
                txtSummary.Text = String.Format("Select an item to show first!\r\ngameHistory:{0}\r\ngameHistory Count:{1}\r\nlstboxGameResults.SelectedIndex:{2}", gameHistory, gameHistory.Count, lstboxGameResults.SelectedIndex);
            }

        }

        // I wanted to try to mess with form sizing to display different controls
        // Decided to go with "Simple vs. Advanced View"
        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            // Turned this into a basic toggle. If the data is hidden when we click this button, show the data
            AdvancedInfoToggle();

        }

        public void AdvancedInfoToggle()
        {
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

        public void btnMaze_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            //MazeForm = new frmMaze(mazePositionOne, mazePositionTwo);
            DialogResult result = MazeForm.ShowDialog(); // displays maze form.

            this.Visible = true;

            if (result == DialogResult.Yes)
            {
                // Our label text
                this.lblDidWeWin.Text = "We Escaped";
                // Our Summary text box
                txtSummary.Text = "We exited the maze and won!";
                MessageBox.Show("You exited the maze!", "You Won!");
                Application.Exit();

            }
            else if (result == DialogResult.OK)
            {
                // Our label text
                this.lblDidWeWin.Text = "Enemy Encountered";
                // Our Summary text box
                txtSummary.Text = "We just encountered an enemy in the maze! Click Fight to battle the foe!";
                mazeposition = (string)MazeForm.Tag;
                string mazePositionresult = "";
                bool firstdone = false;
                foreach (char cb in mazeposition)
                {
                    if (!(cb == Convert.ToChar("|")))
                    {
                        mazePositionresult += cb;
                    }
                    else if (cb == Convert.ToChar("|"))
                    {
                        if (!firstdone)
                        {
                            firstdone = true;
                            mazePositionOne = Convert.ToInt32(mazePositionresult);
                            mazePositionresult = "";
                        }
                        else if (firstdone)
                        {
                            mazePositionTwo = Convert.ToInt32(mazePositionresult);
                            mazePositionresult = "";
                        }
                    }
                    else
                    {
                        //do nothing
                    }
                }

                btnMaze.Visible = false;
                btnPlay.Visible = true;
            }

            else
            {
                // Our label text
                this.lblDidWeWin.Text = "What happened?";

            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(path)) //if directory isn't created
            {
                Directory.CreateDirectory(path);
            }
            //FileStream fileStream = new FileStream(path+fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamWriterGameResults = new StreamWriter(new FileStream(path + gameResultsFileName, FileMode.Create, FileAccess.Write));
            //pipe delineation
            foreach (string result in gameResults)
            {
                streamWriterGameResults.Write(result + "|");
            }
            streamWriterGameResults.WriteLine();
            streamWriterGameResults.Close();

            StreamWriter streamWriterGameHistory = new StreamWriter(new FileStream(path + gameHistoryFileName, FileMode.Create, FileAccess.Write));

            foreach (string result in gameHistory)
            {
                streamWriterGameHistory.Write(result + "|");
            }
            streamWriterGameHistory.WriteLine();
            streamWriterGameHistory.Close();

            StreamWriter streamWriterGameWinRate = new StreamWriter(new FileStream(path + gameWinRateFileName, FileMode.Create, FileAccess.Write));

            foreach (bool result in gameWinRate)
            {
                streamWriterGameWinRate.Write(result + "|");
            }
            streamWriterGameWinRate.WriteLine();
            streamWriterGameWinRate.Close();

            StreamWriter streamWriterGameWinRateDecimal = new StreamWriter(new FileStream(path + gameWinRateDecimalFileName, FileMode.Create, FileAccess.Write));


            foreach (decimal result in gameWinRateDecimal)
            {
                streamWriterGameWinRateDecimal.Write(result + "|");
            }
            streamWriterGameWinRateDecimal.WriteLine();
            streamWriterGameWinRateDecimal.Close();

            StreamWriter streamWriterAdvancedInfoHidden = new StreamWriter(new FileStream(path + advancedInfoHiddenFileName, FileMode.Create, FileAccess.Write));
            streamWriterAdvancedInfoHidden.WriteLine(!advancedInfoHidden);
            streamWriterAdvancedInfoHidden.Close();

            StreamWriter streamWriterMazePosition = new StreamWriter(new FileStream(path + mazePositionFileName, FileMode.Create, FileAccess.Write));

            streamWriterMazePosition.WriteLine(mazeposition);
            streamWriterMazePosition.Close();





        }

        public void btnLoad_Click(object sender, EventArgs e)
        {
            StreamReader streamReaderGameResults = new StreamReader(new FileStream(path + gameResultsFileName, FileMode.OpenOrCreate, FileAccess.Read));


            string firstLine = streamReaderGameResults.ReadLine();
            string result = "";

            foreach (char c in firstLine)
            {
                if (!(c == Convert.ToChar("|")))
                {
                    result += c;
                }
                else if (c == Convert.ToChar("|"))
                {
                    gameResults.Add(result);
                    result = "";
                }
                else
                {
                    //do nothing
                }
            }
            streamReaderGameResults.Close();

            StreamReader streamReaderGameHistory = new StreamReader(new FileStream(path + gameHistoryFileName, FileMode.OpenOrCreate, FileAccess.Read));

            while (streamReaderGameHistory.Peek() != -1)
            {
                string gameHistoryLine = streamReaderGameHistory.ReadToEnd(); //needed because the summary box includes new lines
                string gameHistoryresult = "";
                foreach (char c in gameHistoryLine)
                {
                    if (!(c == Convert.ToChar("|")))
                    {
                        gameHistoryresult += c;
                    }
                    else if (c == Convert.ToChar("|"))
                    {
                        gameHistory.Add(gameHistoryresult);
                        gameHistoryresult = "";
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
            streamReaderGameHistory.Close();


            StreamReader streamReaderGameWinRate = new StreamReader(new FileStream(path + gameWinRateFileName, FileMode.OpenOrCreate, FileAccess.Read));


            string gameWinRateLine = streamReaderGameWinRate.ReadLine();
            string gameWinRateresult = "";
            foreach (char ca in gameWinRateLine)
            {
                if (!(ca == Convert.ToChar("|")))
                {
                    gameWinRateresult += ca;
                }
                else if (ca == Convert.ToChar("|"))
                {
                    gameWinRate.Add(Convert.ToBoolean(gameWinRateresult));
                    gameWinRateresult = "";
                }
                else
                {
                    //do nothing
                }
            }
            streamReaderGameWinRate.Close();

            StreamReader streamReaderGameWinRateDecimal = new StreamReader(new FileStream(path + gameWinRateDecimalFileName, FileMode.OpenOrCreate, FileAccess.Read));

            string gameWinRateDecimalLine = streamReaderGameWinRateDecimal.ReadLine();
            string gameWinRateDecimalresult = "";

            foreach (char cb in gameWinRateDecimalLine)
            {
                if (!(cb == Convert.ToChar("|")))
                {
                    gameWinRateDecimalresult += cb;
                }
                else if (cb == Convert.ToChar("|"))
                {
                    gameWinRateDecimal.Add(Convert.ToDecimal(gameWinRateDecimalresult));
                    gameWinRateDecimalresult = "";
                }
                else
                {
                    //do nothing
                }
            }

            streamReaderGameWinRateDecimal.Close();

            StreamReader streamReaderAdvancedInfoHidden = new StreamReader(new FileStream(path + advancedInfoHiddenFileName, FileMode.OpenOrCreate, FileAccess.Read));

            advancedInfoHidden = Convert.ToBoolean(streamReaderAdvancedInfoHidden.ReadLine());
            streamReaderAdvancedInfoHidden.Close();

            StreamReader streamReaderMazePosition = new StreamReader(new FileStream(path + mazePositionFileName, FileMode.OpenOrCreate, FileAccess.Read));
            //separate two integers 
            string mazePositionLine = streamReaderMazePosition.ReadLine();
            bool firstdone = false;
            bool seconddone = false;
            // find  the 
            int pos = mazePositionLine.IndexOf('|');
            mazePositionOne = Convert.ToInt32(mazePositionLine.Substring(0, pos));
            mazePositionTwo = Convert.ToInt32(mazePositionLine.Substring(pos + 1));
            streamReaderMazePosition.Close();
            //MazeForm = new frmMaze(mazePositionOne, mazePositionTwo);
            LoadData();
        }

    }
}

