using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1Westbrook
{
    public partial class frmAssignment1 : Form
    {
        public frmAssignment1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string initials = "M   M DDD  W     W\r\nMM MM D D  W     W\r\nM M M D  D  W W W\r\nM M M D D   W W W\r\nM   M DDD    W W ";
            txtInitials.Text = initials;
        }

        private void txtInitials_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Random randomColor = new Random();

            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(randomColor.Next(0, 256), randomColor.Next(0, 256), randomColor.Next(0, 256));
            txtInitials.ForeColor = myRgbColor;
        }
    }
}
