using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Marshall Westbrook
 * CPT-230-S73
 * 2021SU
 */
namespace FinalExam
{
    /*
     * Follow the instruction in the comments
     * Open the Demo class file and start there
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            /*
             * 2. Create a Demo object called demo using the default constructor
             * Use the Print method and store it in the textbox called txtForDemo
             * 5pts
             */
            Demo demo = new Demo();
            txtForDemo.Text = demo.Print();


            /*
             * 3. Create a second Demo object called demo2 using the second constructor
             * pass it "Favorite Number" and 5
             * Use the Print method and store it in the textbox called txtForDemo2
             * 5pts
             */
            Demo demo2 = new Demo("Favorite Number", 5);
            txtForDemo2.Text = demo2.Print();


            /*
             * Go to the DemoKid class for the next part
             */


            /*
             * 6. Create a DemoKid object called demoKid using the default constructor
             * Use the Print method and store it in the textbox called txtForDemoKid
             * 5pts
             */
            DemoKid demoKid = new DemoKid();
            txtForDemoKid.Text = demoKid.Print();

            /*
            * 7. Create a second DemoKid object called demoKid2 using the second constructor
            * pass it "Favorite Number", 5, and 55.55
            * Use the Print method and store it in the textbox called txtForDemoKid2
            * 5pts
            */
            DemoKid demoKid2 = new DemoKid("Favorite Number", 5, 55.55m);
            txtForDemoKid2.Text = demoKid2.Print();

            /*
             * 8. Use the Comparable method from demoKid and pass it demoKid2.
             * Display the result in the textbox txtDemoKidCompare
             * 5pts
             */
            txtDemoKidCompare.Text = demoKid.CompareTo(demoKid2).ToString();

            /* 9. Add a break point somewhere in this Event handler
             * 5pts
            /*

             * 10. Save the data from demo, demo2, demoKid, and demoKid2 to a text
             * file called FinalSave.txt
             * 10pts
             */
            // Random Folder in the C: Drive
            string path = @"C:\WestbrookAssignment11_CPT230_21SU\";
            string fileName = "FinalSave.txt";
            StreamWriter streamWriter = new StreamWriter(new FileStream(path + fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            // copying the data from textboxes since we're loading it back in the same format
            streamWriter.WriteLine(txtForDemo.Text);
            streamWriter.WriteLine(txtForDemo2.Text);
            streamWriter.WriteLine(txtForDemoKid.Text);
            streamWriter.WriteLine(txtForDemoKid2.Text);
            streamWriter.Close();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = @"C:\WestbrookAssignment11_CPT230_21SU\";
            string fileName = "FinalSave.txt";
            /*
             *  BONUS: Load the file FinalSave.txt and place the data back in 
             *  the textboxes.
             *  10pts
             */
            StreamReader streamReader = new StreamReader(new FileStream(path + fileName, FileMode.OpenOrCreate, FileAccess.Read));
            txtForDemo.Text = streamReader.ReadLine();
            txtForDemo2.Text = streamReader.ReadLine();
            txtForDemoKid.Text = streamReader.ReadLine();
            txtForDemoKid2.Text = streamReader.ReadLine();
        }
    }
}
