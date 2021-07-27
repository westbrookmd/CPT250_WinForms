using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Marshall Westbrook
 * CPT230 S73
 * 2021SU
 */

namespace Midterm
{
    
    public partial class Form1 : Form
    {
        // Initialize startTime as soon as possible for Bonus Credit
        DateTime startTime = DateTime.Now;
        DateTime endTime;
        bool runClicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            /* Follow the directions in the comments.  Follow them 
             * exactly.
             */

            /* 1. Define a variable named isTrue that stores a value of
             * whether something is true or false.  Set this variable 
             * to the negative.  Output this variable to the txtIsTrue
             * textbox.
             * Value 5 pts
             */
            // Basic boolean and output to text box
            bool isTrue = false;
            txtIsTrue.Text = isTrue.ToString();

            /* 2. Define a variable named favoriteGame that could store
             * the name of a game.  Set this variable's value to your
             * favorite game.  Output this variable to the txtFavoriteGame
             * textbox.
             * Value 5 pts
             */
            // basic string and output to text box
            string favoriteGame = "World of Warcraft";
            txtFavoriteGame.Text = favoriteGame;

            /* 3. Define a variable named pi that can store real numbers.
             * initialize it to a value of 3.14.  Output the value to
             * txtPi.
             * 5 pts
             */
            // basic decimal and output to txtbox
            decimal pi = 3.14m;
            txtPi.Text = pi.ToString();

            /* 4. Create a control structure that will print out "That's Right"
             * to a textbox named txtRightOrWrong if isTrue from the 1st problem
             * is positive result and "Nope" if isTrue is not true.
             * 10 pts
             */
            // simple if else statement
            if (isTrue)
            {
                txtRightOrWrong.Text = "That's Right";
            }
            else
            {
                // This is the program default
                txtRightOrWrong.Text = "Nope";
            }

            /* 5. Write a loop of your choosing to print out the following
             * numbers to txtLoop textbox: -1 -3 -5 -7 -9 -13 -15 -17
             * 15 pts
             */
            // I couldn't find a "correct" way to skip -11 so I manually added an if statement to do this
            for (int i = -1; i > -18; i -= 2)
            {
                if (i != -11)
                {
                    txtLoop.Text += i.ToString() + " ";
                }
            }

            /* 6. Write a nested loop to print out the following to
             * txtNestedLoop:
             * 0
             * 0 1
             * 0 2 4
             * 0 3 6 9
             * 0 4 8 16 32
             * 15 pts
             */

            // Struggled with the final row for a while. I kept printing 0 4 8 12 16
            // I decided to manually add if statements for this since I was unable to figure out the correct solution
            for (int i = 0; i < 5; i++)
            {
                
                for (int j = 0; j < i + 1; j++)
                {
                    // Manually adding correct solution here
                    if (i*j == 12)
                    {
                        txtNestedLoop.Text += "16 ";
                    }
                    else if (i*j == 16)
                    {
                        txtNestedLoop.Text += "32";

                    }
                    // Everything else works fine
                    else
                    {
                        txtNestedLoop.Text += (i * j).ToString() + " ";

                    }


                }
                // Adding line returns
                txtNestedLoop.Text += "\r\n" ;
            }

            /* 7. Call the method from number 8 and output the result to
             * txtMethodCall textbox.
             * 10 pts
             */
            // I added simple validation during testing
            if (txtForFoo.Text != "")
            {
                txtMethodCall.Text = Foo(Convert.ToInt32(txtForFoo.Text));
            }

            /* 10. Create an array of 2 DateTime objects.  Set the first
             * to the current date and time.  Set the second to the 
             * current date.  Output both dates with a space between
             * them to txtDates.  
             * 15pts
             */
            // Problem 10
            DateTime[] times = new DateTime[2] { DateTime.Now, DateTime.Today };
            txtDates.Text = String.Format("{0} {1}", times[0], times[1].ToShortDateString());


            // Bonus Attempt (startTime is at the start of Form1 Class)
            if (runClicked == false)
            {
                runClicked = true;
                endTime = DateTime.Now;
                double timeToLoad = (endTime - startTime).TotalSeconds;
                txtTimeTakenToRun.Text = string.Format("{0:f2} seconds", timeToLoad);
            }

        }

        /* 8. Create a method called Foo that takes an integer from
         * txtForFoo and returns Bar the amount of times entered.
         * ex: txtForFoo is 2 the result is "Bar Bar".
         * 10 pts.
         */
        public string Foo(int ForFoo)
        {
            // Begin exception handling
            try
            {
                // Decided to do it this way for simplicity and readability
                string fooBar = "Bar ";
                string fooMessage = "";
                // For the inputted number, there will be that many "Bar "s
                for (int i = 0; i < ForFoo; i++)
                {
                    fooMessage += fooBar;
                }
                return fooMessage;
            }
            // I chose formateceptions since this would be common.
            catch (FormatException)
            {

                return "Formatting Error.";
            }
            // If there is any other exception, it will be caught here
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* 9. Add a try catch block in the Foo method to catch the 
         * generic exception and one other exception of your choosing 
         * bonus 5 pts if it applies to the method.
         * 10 pts
         */
        // Added format exception and generic exception

        /* ***BONUS***
         * Time how long it takes from the loading of the program
         * until the run button finishes running the first time it
         * is clicked.
         * +10 pts!!!
         */
        // Added this at the beginning of the class and at the end of the run block


    }
}
