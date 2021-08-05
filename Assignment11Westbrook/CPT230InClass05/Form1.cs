using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPT230Assignment05
{
    public partial class frmMaze : Form
    {

        /* Marshall Westbrook
         * CPT-230-S73
         * Assignment05
         * Summer 2021
         * Rectangular Arrays + Maze
         * I didn't read the requirements before creating the second game. After reading
         * the requirements, I made game one
         */

        // Create 10 x 10 array for maze
        Label[,] firstMaze = new Label[10, 10]; // maze array
        // Create empty whitelist for the path
        Boolean[,] firstWhitelist = new bool[10, 10]; // whitelist array

        // Create 10 x 10 array for maze
        Label[,] secondMaze = new Label[10, 10]; // maze array
        // Create empty whitelist for the path
        Boolean[,] secondWhitelist = new bool[10, 10]; // whitelist array
        // Set bool for ending first game
        bool wonFirstGame = false;
        // Set up the game to use randomness upon second game completion
        Random random = new Random();
        int encounterChance = 5; // 1/5 per tile
        //public static int mazePositionOne = 9;
        //public static int mazePositionTwo = 4;



        public frmMaze(int mazePositionOne, int mazePositionTwo)
        {
            InitializeComponent();
            int One = mazePositionOne;
            int Two = mazePositionTwo;
            bool IsFirstPath = true;
            CreatePath(firstWhitelist, IsFirstPath);
            // Create Labels with event handlers on mouse over that send the cursor back to the starting position
            BuildMaze(ref firstMaze, ref firstWhitelist);
            // Set the start and end positions
            PlayFirstGame(firstMaze, firstWhitelist, One, Two);
            // Set the button visibilities to prevent going out of bounds at the start of the game
            SetButtons();

        }


        public void frmAssignment05_Load(object sender, EventArgs e)

        {
            // Show message box with instructions before the maze is visible
            ShowInstructions();



        }

        // This method finds a label with the given text parameter and returns an array of ints with Position 0 and Position 1 as X,Y respectively
        private int[] FindWallWithText(string textToFind)
        {
            for (int i = 0; i < firstMaze.GetLength(0); i++)
            {
                for (int j = 0; j < firstMaze.GetLength(1); j++)
                {
                    // if label isn't blank
                    if (firstWhitelist[i, j] == false)
                    {
                        // if label contains text
                        if (firstMaze[i, j].Text == textToFind)
                        {
                            // create array of ints with the X and Y answer
                            int[] wallWithTextIndex = { i, j };
                            // return it to the caller
                            return wallWithTextIndex;
                        }
                    }
                }
            }
            // if there isn't a wall with our current position, return null. This shouldn't happen, but if it does the program will crash
            return null;
        }

        // Instructions in Messageboxes
        private static void ShowInstructions(string gameNumber = "first")
        {
            // Second game instructions
            if (gameNumber == "second")
            {
                MessageBox.Show("Instructions: \r\n Move your mouse through the maze without touching the black area. " +
                    "If you'd like to see these instructions again, click the start label!", "Assignment 5 Instructions");
            }
            // Show on program launch. Can also be displayed when start label is clicked
            else
            {
                MessageBox.Show("Instructions: \r\n Click the buttons to navigate around the maze. If you get to the \"Win\" tile, you win!", "Assignment 5 Instructions");
            }
        }




        // Creating each wall and giving them properties. inPanel is an optional parameter
        public Label BuildWallLabels(Label l, Color wallBackColor, Color wallForeColor, Size wallSize, Point wallLocation, bool hasMouseHandler = true)
        {
            // Create label
            l = new Label();

            // Change background color
            l.BackColor = wallBackColor;
            // Change Foreground Color (text, if used)
            l.ForeColor = wallForeColor;
            // Change minimum size
            l.Size = wallSize;
            // Add event handler that sends mouse back to starting position
            if (hasMouseHandler == false)
            {
                //do nothing here
            }
            else
            {
                // Create event handler to prevent user from moving mouse through walls
                l.MouseEnter += wall_Collision;

            }
            // Set wall location
            l.Location = wallLocation;
            // Make sure wall is visible
            l.Visible = true;
            // Add text
            l.TextAlign = ContentAlignment.MiddleLeft;
            //l.Text = "wall"; // Option to add text here. Used this for testing
            // AutoSize is not actie. Autosize will create variance. In testing this made the walls invisible or halfway off the screen
            l.AutoSize = false;
            // Add Control to panel (this is done by default)
            return l;


        }


        // Creating the maze
        public void BuildMaze(ref Label[,] maze, ref Boolean[,] whitelist)
        {
            // Wall properties
            // Get the top left corner of the panel
            Point wallStart = pnlMain.Location;
            // Selected these colors from the default colors on a label. Reversed them for easier visibility
            Color wallBackColor = Color.FromName("ActiveCaptionText");
            Color wallForeColor = Color.FromName("Control");
            // Setting wall size based on the panel width divided by the column size and the panel height divided by row length.
            Size wallSize = new Size(pnlMain.Width / maze.GetLength(1), pnlMain.Height / maze.GetLength(0)); // Get the panel width and divide by the array column size. Do the same for height and rows.

            // Looping through each row
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                // Looping through each column
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    // Build a wall if value is not true in whitelist
                    if (whitelist[i, j] == false)
                    {
                        // Get top left of panel
                        Point wallLocation = wallStart;
                        // Add the width of the wall size multiplied by the iteration in the column loop
                        wallLocation.X = (j * wallSize.Width);
                        // Add the height of the wall size multiplied by the iteration in the row loop
                        wallLocation.Y = (i * wallSize.Height);

                        // Create labels and give them properties
                        maze[i, j] = BuildWallLabels(maze[i, j], wallBackColor, wallForeColor, wallSize, wallLocation);
                        pnlMain.Controls.Add(maze[i, j]);
                    }
                }
            }
        }

        public void CreateStartandWin()
        {
            // Start and Win Colors
            Color winBackColor = Color.FromName("Teal");
            Color startBackColor = Color.FromName("Yellow");
            Color winAndStartForeColor = Color.FromName("ActiveCaptionText");

            // Set Start and Win Label Properties
            Size winAndStartSize = new Size(pnlMain.Width / firstMaze.GetLength(1), pnlMain.Height / firstMaze.GetLength(0)); // Get the panel width and divide by the array column size. Do the same for height and rows.
            Point winLocation = pnlMain.Location;
            Point startLocation = new Point();
            startLocation.X = 160;
            startLocation.Y = 356;
            winLocation.X = 321;
            winLocation.Y = 0;

            // Create start and win labels
            Label lblStart = null;
            Label lblWin = null;
            bool hasMouseHandler = false;
            lblStart = BuildWallLabels(lblStart, startBackColor, winAndStartForeColor, winAndStartSize, startLocation, hasMouseHandler);
            lblWin = BuildWallLabels(lblWin, winBackColor, winAndStartForeColor, winAndStartSize, winLocation, hasMouseHandler);
            lblWin.Name = "lblWin";
            lblWin.Text = "Win";
            lblStart.Name = "lblStart";
            lblStart.Text = "Start";

            //Add Instructions and Win Events
            lblStart.MouseClick += (sender, e) => ShowInstructions();
            lblWin.MouseClick += (sender, e) => WinSecondGame();
            // Add to panel
            pnlMain.Controls.Add(lblStart);
            pnlMain.Controls.Add(lblWin);
        }

        private void PreventCheating()
        {
            // Extra Wall Properties
            Color extraWallBackColor = Color.FromName("ActiveCaptionText");
            Color extraWallForeColor = Color.FromName("Control");
            Size extraWallSize = new Size(40, 40);
            Point winButtonLocation = new Point(332, 30);

            // Individual Locations for Left, Right, and Above the Win Label
            Point extraWallLocationLeft = winButtonLocation;
            extraWallLocationLeft.X -= (extraWallSize.Width);

            Point extraWallLocationRight = winButtonLocation;
            extraWallLocationRight.X += extraWallSize.Width;

            Point extraWallLocationAbove = winButtonLocation;
            extraWallLocationAbove.Y -= 14;

            // BuildWallLabels takes a Label type, but arrays of a type are created with null placeholders. These three null labels are
            // to pass into the same method. If this needed to be done more often, we should make the method more general to reduce the need for this.
            Label extraWallLeft = null;
            Label extraWallRight = null;
            Label extraWallAbove = null;

            // Call our buildwalls method with the custom locations outside of the panel.
            extraWallLeft = BuildWallLabels(extraWallLeft, extraWallBackColor, extraWallForeColor, extraWallSize, extraWallLocationLeft);
            extraWallRight = BuildWallLabels(extraWallRight, extraWallBackColor, extraWallForeColor, extraWallSize, extraWallLocationRight);
            extraWallAbove = BuildWallLabels(extraWallAbove, extraWallBackColor, extraWallForeColor, extraWallSize, extraWallLocationAbove);
            // Adding Each Element to panel
            Controls.Add(extraWallLeft);
            Controls.Add(extraWallRight);
            Controls.Add(extraWallAbove);
        }

        // Method for label event handlers. This was to make it clearer for me to understand which part to add to each label
        private void wall_Collision(object sender, EventArgs e)
        {
            // Call method that sends mouse back to starting point
            MouseToStart();
        }

        private void MouseToStart()

        {
            // Find panel top left corner
            Point startingpoint = pnlMain.Location;
            // Offset the starting point to make it in the center of the bottom of the panel (+ 10 pixels Y and -10 pixels X)
            startingpoint.Offset(pnlMain.Width / 2 - 10, pnlMain.Height + 10);
            // set cursor location
            Cursor.Position = PointToScreen(startingpoint);
        }

        // Win condition is clicking the label
        private void lblWin_Click(object sender, EventArgs e)
        {
            WinSecondGame();
        }

        private void WinSecondGame()
        {
            // Show Message box. Mouse cursor shouldn't interact with mouse over events when this is open
            MessageBox.Show("You WON! Thanks for playing! This is the end of the program. If you " +
                "would like to keep playing, the tiles will continue to change colors each round.", "You're a Winner!");
            // Add some color to the game. It's kinda boring without it!
            WallColors();



            // Optional: Exit program instead of it being never ending
            //Application.Exit();
        }

        public void WallColors()
        {
            // Loop through every label within the panel
            foreach (Label label in pnlMain.Controls)
            {
                // Create a new color
                Color myRgbColor = new Color();
                // Use random values that aren't too close to white
                myRgbColor = Color.FromArgb(random.Next(20, 256), random.Next(20, 256), random.Next(20, 256));
                // Set the backcolor values for the labels
                label.BackColor = myRgbColor;
            }

        }

        // Whitelist array for the path to winning.
        public static void CreatePath(bool[,] whitelist, bool IsFirstPath = false)
        {
            // Manually set this path. In the future this could be generated by an algorithim based on maze array size.
            if (IsFirstPath == true)
            {
                // 2nd row from bottom
                whitelist[8, 6] = true;
                whitelist[8, 7] = true;
                whitelist[8, 8] = true;
                whitelist[8, 4] = true;
                whitelist[8, 2] = true;
                whitelist[8, 1] = true;

                // 3rd row from bottom
                whitelist[7, 4] = true;


                // 4th row from bottom
                whitelist[6, 0] = true;
                whitelist[6, 9] = true;
                whitelist[6, 6] = true;
                whitelist[6, 7] = true;
                whitelist[6, 5] = true;
                whitelist[6, 3] = true;
                whitelist[6, 2] = true;
                whitelist[6, 4] = true;
                whitelist[5, 4] = true;


                // 5th row from top
                whitelist[4, 1] = true;
                whitelist[4, 2] = true;
                whitelist[4, 3] = true;
                whitelist[4, 4] = true;
                whitelist[4, 6] = true;
                whitelist[4, 7] = true;
                whitelist[4, 8] = true;
                whitelist[4, 9] = true;

                // 3rd row from top
                whitelist[2, 0] = true;
                whitelist[2, 1] = true;
                whitelist[2, 2] = true;
                whitelist[2, 3] = true;
                whitelist[2, 5] = true;
                whitelist[2, 6] = true;
                whitelist[2, 7] = true;
                whitelist[2, 8] = true;

                // top two rows
                whitelist[0, 9] = true;
                whitelist[0, 8] = true;
                whitelist[0, 7] = true;
                whitelist[0, 4] = true;
                whitelist[0, 0] = true;
                whitelist[1, 1] = true;
                whitelist[1, 0] = true;
                whitelist[1, 2] = true;
                whitelist[1, 5] = true;
            }
            // Second game's path
            else if (IsFirstPath == false)
            {
                whitelist[9, 4] = true;
                whitelist[8, 4] = true;
                whitelist[8, 3] = true;
                whitelist[8, 2] = true;
                whitelist[8, 1] = true;
                whitelist[7, 1] = true;
                whitelist[6, 1] = true;
                whitelist[6, 2] = true;
                whitelist[6, 3] = true;
                whitelist[6, 4] = true;
                whitelist[6, 5] = true;
                whitelist[6, 6] = true;
                whitelist[7, 6] = true;
                whitelist[7, 8] = true;
                whitelist[8, 6] = true;
                whitelist[8, 7] = true;
                whitelist[8, 8] = true;
                whitelist[6, 8] = true;
                whitelist[5, 8] = true;
                whitelist[4, 8] = true;
                whitelist[4, 7] = true;
                whitelist[4, 6] = true;
                whitelist[4, 5] = true;
                whitelist[4, 4] = true;
                whitelist[3, 4] = true;
                whitelist[3, 3] = true;
                whitelist[3, 2] = true;
                whitelist[3, 1] = true;
                whitelist[2, 1] = true;
                whitelist[1, 1] = true;
                whitelist[1, 2] = true;
                whitelist[1, 3] = true;
                whitelist[1, 4] = true;
                whitelist[1, 5] = true;
                whitelist[1, 6] = true;
                whitelist[1, 7] = true;
                whitelist[1, 8] = true;
                whitelist[0, 8] = true;
            }

        }

        // Set start and win locations
        public void PlayFirstGame(Label[,] maze, Boolean[,] whitelist, int One, int Two)
        {
            try
            {
                maze[0, 1].Text = "Win";
                maze[One, Two].Text = "You";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace, ex.Message);
            }

        }

        // Remove all controls from the Panel
        public void ClearPanel()
        {
            pnlMain.Controls.Clear();
        }

        // If you click the start label show the instructions
        private void lblStart_Click(object sender, EventArgs e)
        {
            string gameNumber = "second";
            ShowInstructions(gameNumber);
        }

        // We are checking when buttons should be visible rather than finding when they shouldn't be visible
        public void SetButtons()
        {
            // If we haven't won
            if (wonFirstGame == false)
            {

                // Get current position
                int[] currentPosition = FindWallWithText("You");
                try
                {
                    // Check max length to not go down out of bounds
                    // Check down
                    if ((int)firstMaze.GetLength(0) - 1 != currentPosition[0])
                    {
                        if (firstMaze[currentPosition[0] + 1, currentPosition[1]] != null)
                        {
                            btnDown.Visible = true;
                        }
                        else
                        {
                            btnDown.Visible = false;

                        }
                    }
                    else
                    {
                        btnDown.Visible = false;

                    }
                    // Check Up

                    if (currentPosition[0] > 0)
                    {
                        if (firstMaze[currentPosition[0] - 1, currentPosition[1]] != null)
                        {
                            btnUp.Visible = true;
                        }
                        else
                        {
                            btnUp.Visible = false;
                        }
                    }
                    else
                    {
                        btnUp.Visible = false;
                    }


                    // Check Right
                    if ((int)firstMaze.GetLength(1) - 1 != currentPosition[1])
                    {
                        if (firstMaze[currentPosition[0], currentPosition[1] + 1] != null)
                        {
                            btnRight.Visible = true;
                        }
                        else
                        {
                            btnRight.Visible = false;
                        }
                    }
                    else
                    {
                        btnRight.Visible = false;
                    }

                    // Check Left
                    if (currentPosition[1] > 0)
                    {
                        if (firstMaze[currentPosition[0], currentPosition[1] - 1] != null)
                        {
                            btnLeft.Visible = true;
                        }
                        else
                        {
                            btnLeft.Visible = false;

                        }
                    }
                    else
                    {
                        btnLeft.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, ex.Message);
                }
            }
        }

        private void CheckForEncounter()
        {
            // make sure we haven't won yet
            if (wonFirstGame == false)
            {
                int randomEncounter = random.Next(0, encounterChance);
                if (randomEncounter == 0)
                {
                    // Return fight
                    int[] currentPosition = FindWallWithText("You");
                    //MessageBox.Show(currentPosition[0].ToString() + currentPosition[1].ToString(), "Current Position"); //testing location communication
                    this.Tag = currentPosition[0] + "|" + currentPosition[1];
                    this.DialogResult = DialogResult.OK;
                }
            }

        }

        private bool CheckIfWon(Label target)
        {
            // If we've won
            if (target.Text == "Win")
            {
                MessageBox.Show("You Win");
                btnUp.Visible = false;
                btnDown.Visible = false;
                btnLeft.Visible = false;
                btnRight.Visible = false;
                /*
                ClearPanel();
                // Manually create path. This could be generated by an algorithim in the future
                CreatePath(secondWhitelist);
                // Create Labels with event handlers on mouse over that send the cursor back to the starting position
                BuildMaze(ref secondMaze, ref secondWhitelist);

                // Creating Walls around Win button so the user can't cheat as easily
                CreateStartandWin();
                PreventCheating();
                string gameNumber = "second";
                ShowInstructions(gameNumber);
                return true;
                */
                this.DialogResult = DialogResult.Yes;
                return true;
            }
            // If we haven't won
            else
            {
                // Set current position
                target.Text = "You";
                // Return that we didn't win
                return false;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            // Create an array of ints. Position 0 is X, Position 1 is Y.
            // Call the method that gets the current label in the Panel with the text "You".
            int[] currentPosition = FindWallWithText("You");
            // Set old position as a blank string.
            firstMaze[currentPosition[0], currentPosition[1]].Text = "";
            // This may not be necessary to loop through maze array, but this works reliably
            for (int i = 0; i < firstMaze.GetLength(0); i++)
            {
                for (int j = 0; j < firstMaze.GetLength(1); j++)
                {
                    // If the item in the loop isn't an empty spot
                    if (firstWhitelist[i, j] == false)
                    {
                        // If the label is directly above the current position
                        if (i == currentPosition[0] - 1 && j == currentPosition[1])
                        {
                            // Check if we've won. If not, set the text to "You"
                            wonFirstGame = CheckIfWon(firstMaze[i, j]);
                            // check if this is an encounter

                        }
                    }
                }
            }
            SetButtons();
            CheckForEncounter();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            // Create an array of ints. Position 0 is X, Position 1 is Y.
            // Call the method that gets the current label in the Panel with the text "You".
            int[] currentPosition = FindWallWithText("You");
            // Set old position as a blank string.
            firstMaze[currentPosition[0], currentPosition[1]].Text = "";
            // This may not be necessary to loop through maze array, but this works reliably
            for (int i = 0; i < firstMaze.GetLength(0); i++)
            {
                for (int j = 0; j < firstMaze.GetLength(1); j++)
                {
                    // If the item in the loop isn't an empty spot
                    if (firstWhitelist[i, j] == false)
                    {
                        // If the label is directly right of the current position
                        if (i == currentPosition[0] && j == currentPosition[1] + 1)
                        {
                            // Check if we've won. If not, set the text to "You"
                            wonFirstGame = CheckIfWon(firstMaze[i, j]);
                            // check if this is an encounter
                            CheckForEncounter();
                        }
                    }
                }
            }
            SetButtons();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            // Create an array of ints. Position 0 is X, Position 1 is Y.
            // Call the method that gets the current label in the Panel with the text "You".
            int[] currentPosition = FindWallWithText("You");
            // Set old position as a blank string.
            firstMaze[currentPosition[0], currentPosition[1]].Text = "";
            // This may not be necessary to loop through maze array, but this works reliably
            for (int i = 0; i < firstMaze.GetLength(0); i++)
            {
                for (int j = 0; j < firstMaze.GetLength(1); j++)
                {
                    // If the item in the loop isn't an empty spot
                    if (firstWhitelist[i, j] == false)
                    {
                        // If the label is directly below the current position
                        if (i == currentPosition[0] + 1 && j == currentPosition[1])
                        {
                            // Check if we've won. If not, set the text to "You"
                            wonFirstGame = CheckIfWon(firstMaze[i, j]);
                            // check if this is an encounter
                            CheckForEncounter();
                        }
                    }
                }
            }
            SetButtons();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            // Create an array of ints. Position 0 is X, Position 1 is Y.
            // Call the method that gets the current label in the Panel with the text "You".
            int[] currentPosition = FindWallWithText("You");
            // Set old position as a blank string.
            firstMaze[currentPosition[0], currentPosition[1]].Text = "";
            // This may not be necessary to loop through maze array, but this works reliably
            for (int i = 0; i < firstMaze.GetLength(0); i++)
            {
                for (int j = 0; j < firstMaze.GetLength(1); j++)
                {
                    // If the item in the loop isn't an empty spot
                    if (firstWhitelist[i, j] == false)
                    {
                        // If the label is directly left of the current position
                        if (i == currentPosition[0] && j == currentPosition[1] - 1)
                        {
                            // Check if we've won. If not, set the text to "You"
                            wonFirstGame = CheckIfWon(firstMaze[i, j]);
                            // check if this is an encounter
                            CheckForEncounter();
                        }
                    }
                }
            }
            SetButtons();
        }
    }
}
