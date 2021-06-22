using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WestbrookAssignment4
{
    public partial class frmWestbrookAssignment4 : Form
    {
        /* Marshall Westbrook
         * CPT230 S73
         * Professor Richards
         * Coding Assignment 4
         * A Basic Calculator with Exception Handling and Validation
         * Summer 2021
         */


        // Known bug: You can click any operation multiple times without typing more digits.
        // This doesn't mess with any functionality (in testing), but it does display in the history and doesn't look good to the user
        //
        // Random Feature: Clicking equals multiple times doesn't do anything. This limits you from repeating operations quickly, but
        //                 it also reduces the aggravation of accidential misclicks.



        // Empty decimal array. This will be used for keeping track of all values entered and outputted.
        // This doesn't necessarily need to be an array. This is less performant, but the values are stored in order if the data needs to be used differently.
        decimal[] history = new decimal[0];
        // Started with this as a string. An array allows for me to keep an accurate history of what was clicked. If the history doesn't need to be exported and only needs to be displayed, this could just be a string instead.
        string[] operation = new string[0];

        public frmWestbrookAssignment4()
        {
            InitializeComponent();
            // Display instructions
            txtOutput.Text = "Instructions: \r\nEscape = CLR, \r\nALT + C = CLR,\r\n ALT + + = +, \r\nALT + - = -, \r\nALT + * = *, \r\nALT + / = /, \r\nEnter = =";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input. If not valid, display text in the output so that the user corrects their error.
            if (Validate(txtInput))
            {
                txtOutput.Text = "";
                // Convert text to decimal
                decimal a = Convert.ToDecimal(txtInput.Text);
                // Add decimal to output box and history array. Input is reset to an empty string and input textbox is focused
                // Set operation for when user clicks equals
                UpdateArraysAndOutput(a, "+");
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            // Validate input. If not valid, display text in the output so that the user corrects their error.
            if (Validate(txtInput))
            {
                txtOutput.Text = "";
                // Convert text to decimal
                decimal a = Convert.ToDecimal(txtInput.Text);
                // Add decimal to output box and history array. Input is reset to an empty string and input textbox is focused
                // Set operation for when user clicks equals
                UpdateArraysAndOutput(a, "-");
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            // Validate input. If not valid, display text in the output so that the user corrects their error.
            if (Validate(txtInput))
            {
                txtOutput.Text = "";
                // Convert text to decimal
                decimal a = Convert.ToDecimal(txtInput.Text);
                // Add decimal to output box and history array. Input is reset to an empty string and input textbox is focused
                // Set operation for when user clicks equals
                UpdateArraysAndOutput(a, "*");
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            // Validate input. If not valid, display text in the output so that the user corrects their error.
            if (Validate(txtInput))
            {
                txtOutput.Text = "";
                // Convert text to decimal
                decimal a = Convert.ToDecimal(txtInput.Text);
                // Add decimal to output box and history array. Input is reset to an empty string and input textbox is focused
                // Set operation for when user clicks equals
                UpdateArraysAndOutput(a, "/");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Set array back to zero length. Input, output, and operation reset to empty strings.
            Reset();
        }

        public void DisplayOverFlow()
        {
            // Set array back to zero length. Input, output, and operation reset to empty strings.
            Reset();
            // Special output text for overflow errors.
            txtOutput.Text = "Answer is too large.";
        }

        public void Reset()
        {
            // Reset array to default
            Array.Resize(ref history, 0);
            // Reset input to default
            txtInput.Text = "";
            // Reset output to default. Could replace this with the instructions. Didn't like it during testing
            txtOutput.Text = "";
            // Reset operation to default
            Array.Resize(ref operation, 0);
            txtInput.Focus();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            // Validate input. If not valid, display text in the output so that the user corrects their error.
            // If operation isn't set, show else text.
            try
            {
                if (Validate(txtInput) && (operation[operation.Length - 1] != ""))
                {
                    // Make sure that the user isn't clicking equals multiple times in a row
                    if (operation[operation.Length - 1] != "=")
                    {
                        // Convert text to decimal
                        decimal a = Convert.ToDecimal(txtInput.Text);
                        // Get last decimal put into history
                        decimal b = history[history.Length - 1];
                        // Add decimal to history array. Input is reset to an empty string and input textbox is focused
                        AddToHistory(a);
                        // Output textbox is updated
                        UpdateOutput();
                        // Begin preparing for exceptions
                        try
                        {
                            // A switch seemed worth it here. This should make it easy to add more operations.
                            switch (operation[operation.Length - 1])
                            {
                                case "+":
                                    // Answer is displayed. Answer is added to history on next button click
                                    txtInput.Text = AddNumbers(a, b).ToString();
                                    break;
                                case "-":
                                    // Answer is displayed. Answer is added to history on next button click
                                    txtInput.Text = SubtractNumbers(a, b).ToString();
                                    break;
                                case "*":
                                    // Answer is displayed. Answer is added to history on next button click
                                    txtInput.Text = MultiplyNumbers(a, b).ToString();
                                    break;
                                case "/":
                                    // Answer is displayed. Answer is added to history on next button click
                                    txtInput.Text = DivideNumbers(a, b).ToString();
                                    break;
                                default:
                                    break;
                            }
                            // Here's where we add the equals operation to the operation array. The textbox is already displaying the equals sign from updateoutput.
                            if (operation[operation.Length - 1] != "=")
                            {
                                AddToOperation("=");
                            }
                            txtInput.Focus();
                        }


                        // Overflow is most likely to happen with operations
                        catch (OverflowException)
                        {
                            // Aggressively handle overflow by resetting input, output, operation, and history. Display overflow text for user.
                            DisplayOverFlow();
                        }
                        // Prepare for potential exceptions with operations
                        catch (Exception ex)
                        {
                            // Reset input, output, operation, and history.
                            Reset();
                            // Display exception in a pop-up message box.
                            MessageBox.Show(ex.Message, ex.GetType().ToString());
                        }
                    }

                }
                // If user does not click an operation before clicking equals
                else
                {
                    // Give unique text
                    txtOutput.Text = "Click an operation after typing in a valid decimal. Then enter in another decimal and click the equals button.";
                }
            }
            catch (Exception ex)
            {
                // This throws when a user enters a number, clicks an operation but then click equals.
                if (Validate(txtInput) && history.Length == (operation.Length))
                {
                    // Reset program to default, without instructions.
                    Reset();
                    // Display unique text for error
                    txtOutput.Text = "Click an operation after typing in a valid decimal. Then enter in another decimal and click the equals button.";
                }
                else
                {
                    // Input either wasn't able to be validated and/or the user didn't have an operation clicked before clicking equals
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
                
            }
        }

        // Main source of validating input. Two points of exit for now
        public bool Validate(TextBox textbox)
        {
            // Make sure input isn't an empty string
            if (IsPresent(textbox))
            {
                // Make sure input is a valid decimal
                if (IsValidDecimal(textbox))
                {
                    // Ready to convert to decimal for tryparse
                    decimal x = Convert.ToDecimal(textbox.Text); // This line and IsInRange may not be needed. Not sure so leaving it in for now.
                    // If decimal is within range 
                    if (IsInRange(x))
                    {
                        // Exit if number is valid and within range
                        return true;
                    }
                    else
                    {
                        // Not in range. Display valid range
                        txtOutput.Text = "Enter a decimal that is not above " + decimal.MaxValue + " or below " + decimal.MinValue + "\r\n" + txtOutput.Text;
                    }
                }
                else
                {
                    // Not a valid decimal. Display valid decimal text
                    txtOutput.Text = "Enter a valid decimal." + "\r\n" + txtOutput.Text;
                }
            }
            else
            {
                // User didn't enter any information into input
                txtOutput.Text = "Make sure to enter a number before clicking a button!" + "\r\n" + txtOutput.Text;
            }
            // Not valid
            return false;
        }

        // Checks that the input is a decimal
        public bool IsValidDecimal(TextBox textbox)
        {
            return decimal.TryParse(textbox.Text, out _); // We don't need the decimal result in our implementation
        }

        // Checks that the decimal will not overflow
        public bool IsInRange(decimal a)
        {
            return a > decimal.MinValue && a < decimal.MaxValue; // As long as we're within decimal min and max
        }

        // Returns true if there is any input
        public bool IsPresent(TextBox textbox)
        {
            return !(textbox.Text == ""); // true as long as it isn't an empty string. Consider changing if nullable objects need to be implemented
        }

        // How to keep track of user input
        public void AddToHistory(decimal a)
        {
            // https://asp-net-example.blogspot.com/2013/09/c-array-append-add-new-item-in-end-of.html
            // Found out how to do that from this link
            // Add one size to history array
            Array.Resize(ref history, history.Length + 1); // How I understand this works: create array with X length -> copy elements from first array to new array -> delete old array -> rename new array to old array name
            // Add value to end of new history array
            history[history.Length - 1] = a;
        }

        // Keeping track of user operation clicks
        public void AddToOperation(string operationtoadd)
        {
            // https://asp-net-example.blogspot.com/2013/09/c-array-append-add-new-item-in-end-of.html
            // // Found out how to do that from this link
            // Add one size to history array
            Array.Resize(ref operation, operation.Length + 1); // How I understand this works: create array with X length -> copy elements from first array to new array -> delete old array -> rename new array to old array name
            // Add value to end of new history array
            operation[operation.Length - 1] = operationtoadd;
        }

        // Update the Output Textbox
        public void UpdateOutput()
        {
            // Start with a blank textbox
            txtOutput.Text = "";
            // For how many times we've entered a number
            for (int i = 0; i < history.Length; i++)
            {
                // Output the number we input (we've already validated)
                txtOutput.Text = history[i] + "\r\n" + txtOutput.Text;
                // Begin looking out for exceptions
                try
                {
                    // If we still have operations left to cycle through
                    if (i < operation.Length)
                    {
                        // Output them in between user input
                        txtOutput.Text = operation[i] + "\r\n" + txtOutput.Text;
                    }
                    // If we don't have any more operations
                    else if (i >= operation.Length)
                    {
                        // and the output doesn't already start with an equals sign
                        if (!(txtOutput.Text.StartsWith("=")))
                        {
                            // Add an equals sign
                            txtOutput.Text = "=" + "\r\n" + txtOutput.Text; // This will only run when the user clicks equals.
                                                                            // After this text is displayed, the statement after the equals switch statement will add the equals operation to the operation array
                            
                        }
                        
                    }
                }
                // Just in case we have an exception here
                catch (Exception ex)
                {
                    txtOutput.Text = ex.Message + "" + ex.GetType().ToString() + " \r\n" + txtOutput.Text;
                }
                
            }
        }

        // All-in-one updater
        public void UpdateArraysAndOutput(decimal a, string operation)
        {
            // Add to history array
            AddToHistory(a);
            // Add to operation array
            AddToOperation(operation);
            // Update the Output textbox
            UpdateOutput();
            txtInput.Text = "";
            txtInput.Focus();
        }


        // Could have used error handling within each operation, but I decided to opt for error handling when the equals button is clicked instead.
        // Basic addition
        public decimal AddNumbers(decimal a, decimal b)
        {
            return a + b;
        }
        // Basic subtraction
        public decimal SubtractNumbers(decimal a, decimal b)
        {
            return b - a;
        }
        // Basic multiplication
        public decimal MultiplyNumbers(decimal a, decimal b)
        {
            return a * b;
        }
        // Basic Division
        public decimal DivideNumbers(decimal a, decimal b)
        {
            return b / a;
        }


    }
}
