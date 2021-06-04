using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPT230InClass02
{
    public partial class Form1 : Form
    {
        bool key; //global key bool to share between buttons
        int keyAnswer = 12 / 5; //Answer is 2
        bool firstLock = false;//Answer is 4
        bool secondLock = false;
        float keyAnswer2 = 24 / 5;

        public Form1()
        {
            InitializeComponent();
        }



        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblOutput_Click(object sender, EventArgs e)
        {

        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            int currentRoom = Convert.ToInt32(txtInput2.Text);
            if (currentRoom == 0)
            {
                txtInput2.Text = "1";
                txtOutput.Text = "You are in a room with exits to the North and South.";
                btnNorth.Visible = true;
                btnEast.Visible = false;
                btnWest.Visible = false;
                btnSouth.Visible = true;
                chk0.Checked = false;
                chk1.Checked = true;
            }

            else if (currentRoom == 1)
            {
                txtInput2.Text = "8";
                txtOutput.Text = "You are in a room with an exit to the South.";
                btnNorth.Visible = false;
                btnEast.Visible = false;
                btnWest.Visible = false;
                btnSouth.Visible = true;
                chk1.Checked = false;
                chk8.Checked = true;
            }
            else if (currentRoom == 7)
            {
                txtInput2.Text = "3";
                txtOutput.Text = "You are in a room with exits to the North and South.";
                btnNorth.Visible = true;
                btnEast.Visible = false;
                btnWest.Visible = false;
                btnSouth.Visible = true;
                chk7.Checked = false;
                chk3.Checked = true;
                if (btnSouth.Text == "Exit") //if someone with a key decides not to exit
                {
                    btnSouth.Text = "South"; //change text back to default
                }
            }
            else //If there is a bug, send to beginning
            {
                txtInput2.Text = "0";
                txtOutput.Text = "You are in a room with exits to the North, East, South, and West.";
                btnNorth.Visible = true;
                btnEast.Visible = true;
                btnWest.Visible = true;
                btnSouth.Visible = true;
                chk3.Checked = false;
                chk0.Checked = true;
            }
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            int currentRoom = Convert.ToInt32(txtInput2.Text);
            if (currentRoom == 0)
            {
                txtInput2.Text = "2";
                txtOutput.Text = "You are in a room with exits to the West and East.";
                btnNorth.Visible = false;
                btnEast.Visible = true;
                btnWest.Visible = true;
                btnSouth.Visible = false;
                chk0.Checked = false;
                chk2.Checked = true;
            }
            else if (currentRoom == 2)
            {
                txtInput2.Text = "6";
                txtOutput.Text = "You are in a room with an exit to the West.";
                btnNorth.Visible = false;
                btnEast.Visible = false;
                btnWest.Visible = true;
                btnSouth.Visible = false;
                chk2.Checked = false;
                chk6.Checked = true;
            }
            else if (currentRoom == 5)
            {
                txtInput2.Text = "4";
                txtOutput.Text = "You are in a room with exits to the West or East.";
                btnNorth.Visible = false;
                btnEast.Visible = true;
                btnWest.Visible = true;
                btnSouth.Visible = false;
                //Key Lock Combination Controls
                lblInputKey.Visible = false;
                lblOutputKey.Visible = false;
                txtInputKey.Visible = false;
                txtOutputKey.Visible = false;
                btnKey.Visible = false;

                chk5.Checked = false;
                chk4.Checked = true;
            }
            else //If there is a bug, send to beginning
            {
                txtInput2.Text = "0";
                txtOutput.Text = "You are in a room with exits to the North, East, South, and West.";
                btnNorth.Visible = true;
                btnEast.Visible = true;
                btnWest.Visible = true;
                btnSouth.Visible = true;
                chk4.Checked = false;
                chk0.Checked = true;
            }
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            int currentRoom = Convert.ToInt32(txtInput2.Text);
            if (currentRoom == 0)
            {
                txtInput2.Text = "3";
                txtOutput.Text = "You are in a room with exits to the North and South.";
                btnNorth.Visible = true;
                btnEast.Visible = false;
                btnWest.Visible = false;
                btnSouth.Visible = true;
                chk0.Checked = false;
                chk3.Checked = true;
                
            }

            else if (currentRoom == 3)
            {
                txtInput2.Text = "7";
                txtOutput.Text = "You are in a room with an exit to the North.";
                btnNorth.Visible = true;
                btnEast.Visible = false;
                btnWest.Visible = false;
                chk3.Checked = false;
                chk7.Checked = true;
                if (key == true) //check if key is acquired
                {
                    btnSouth.Visible = true;
                    txtOutput.Text = "You are in a room with exits to the North and South. The South looks like a way out of here!";
                    btnSouth.Text = "Exit"; //changing button text
                }
                else if (key == false) //normal behavior without key
                {
                    btnSouth.Visible = false;
                }
            }
            else if (currentRoom == 7) //Winning condition. All buttons are invisible
            {
                txtInput2.Text = "Outside";
                txtOutput.Text = "You find yourself outside of the maze. This is the end of the program!";
                btnNorth.Visible = false;
                btnEast.Visible = false;
                btnWest.Visible = false;
                btnSouth.Visible = false;
                chk7.Checked = false;
            }
            else if (currentRoom == 8)
            {
                txtInput2.Text = "1";
                txtOutput.Text = "You are in a room with exits to the North and South.";
                btnNorth.Visible = true;
                btnEast.Visible = false;
                btnWest.Visible = false;
                btnSouth.Visible = true;
                chk8.Checked = false;
                chk1.Checked = true;

            }
            else //If there is a bug, send to beginning
            {
                txtInput2.Text = "0";
                txtOutput.Text = "You are in a room with exits to the North, East, South, and West.";
                btnNorth.Visible = true;
                btnEast.Visible = true;
                btnWest.Visible = true;
                btnSouth.Visible = true;
                chk1.Checked = false;
                chk0.Checked = true;
            }
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            int currentRoom = Convert.ToInt32(txtInput2.Text);
            if (currentRoom == 0)
            {
                txtInput2.Text = "4";
                txtOutput.Text = "You are in a room with exits to the West or East.";
                btnNorth.Visible = false;
                btnEast.Visible = true;
                btnWest.Visible = true;
                btnSouth.Visible = false;
                chk0.Checked = false;
                chk4.Checked = true;
            }

            else if (currentRoom == 4)
            {
                txtInput2.Text = "5";
                txtOutput.Text = "You are in a room with an exit to the East.";

                if (key == false) //If we haven't picked up the key
                {


                    btnNorth.Visible = false;
                    btnEast.Visible = true;
                    btnWest.Visible = false;
                    btnSouth.Visible = false;
                    btnKey.Visible = true; //Key button

                    //Key Lock Combination Controls
                    lblInputKey.Visible = true;
                    lblOutputKey.Visible = true;
                    txtInputKey.Visible = true;
                    txtOutputKey.Visible = true;
                    txtOutput.Text = "You stand in front of a large lock with numbers. Enter what an integer with a value of 12/5 will result in below. You are in a room with an exit to the East.";

                }
                else //Revisting room
                {
                    txtOutput.Text += "You remember this is where you found the key."; //Can repeatedly add this text
                    btnNorth.Visible = false;
                    btnEast.Visible = true;
                    btnWest.Visible = false;
                    btnSouth.Visible = false;

                    //Key Lock Combination Controls
                    lblInputKey.Visible = false;
                    lblOutputKey.Visible = false;
                    txtInputKey.Visible = false ;
                    txtOutputKey.Visible = false;
                    btnKey.Visible = false;

                }
                chk4.Checked = false;
                chk5.Checked = true;
            }
            else if (currentRoom == 6)
            {
                txtInput2.Text = "2";
                txtOutput.Text = "You are in a room with exits to the West and East.";
                btnNorth.Visible = false;
                btnEast.Visible = true;
                btnWest.Visible = true;
                btnSouth.Visible = false;
                chk6.Checked = false;
                chk2.Checked = true;
            }
            else //If there is a bug, send to beginning
            {
                txtInput2.Text = "0";
                txtOutput.Text = "You are in a room with exits to the North, East, South, and West.";
                btnNorth.Visible = true;
                btnEast.Visible = true;
                btnWest.Visible = true;
                btnSouth.Visible = true;
                chk2.Checked = false;
                chk0.Checked = true;

            }

        }

        private void lblInput_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chk0_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            while (secondLock == false)
            {
                if (txtInputKey.Text == keyAnswer.ToString() && firstLock == false)
                {
                    txtOutputKey.Text = "Nice job!";
                    txtOutput.Text = "The first lock clicks. Enter what a float with a value of 24/5 will result in below. You are in a room with an exit to the East.";
                    firstLock = true;
                    break;
                }
                else if ((txtInputKey.Text == keyAnswer2.ToString() && secondLock == false) && firstLock == true)
                {
                    txtOutput.Text = "You find a key in this room and stash it away. You are in a room with an exit to the East."; //Give one-time pickup text
                    txtInput.Text = "Key from Room 5"; //Permanently add to inventory
                    txtOutputKey.Text = "You got it!";
                    secondLock = true;
                    key = true; //Change global bool
                    lblInputKey.Visible = false;
                    txtInputKey.Visible = false;
                    btnKey.Visible = false;
                    break;

                }

                else
                {
                    if (txtOutputKey.Text.StartsWith("Try again!") == true)
                    {
                        txtOutputKey.Text += "!";
                        break;
                    }
                    else
                    {
                        txtOutputKey.Text = "Try again!";
                        break;
                    }

                }


            }

        }
    }
}
