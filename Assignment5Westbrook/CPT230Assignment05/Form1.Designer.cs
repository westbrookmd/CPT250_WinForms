
namespace CPT230Assignment05
{
    partial class frmAssignment05
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblWin = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Location = new System.Drawing.Point(12, 54);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 400);
            this.pnlMain.TabIndex = 5;
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblWin.ForeColor = System.Drawing.SystemColors.Control;
            this.lblWin.Location = new System.Drawing.Point(335, 14);
            this.lblWin.MinimumSize = new System.Drawing.Size(40, 40);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(40, 40);
            this.lblWin.TabIndex = 6;
            this.lblWin.Text = "Win!";
            this.lblWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWin.Click += new System.EventHandler(this.lblWin_Click);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.SystemColors.Info;
            this.lblStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStart.Location = new System.Drawing.Point(174, 455);
            this.lblStart.MinimumSize = new System.Drawing.Size(40, 40);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(40, 40);
            this.lblStart.TabIndex = 7;
            this.lblStart.Text = "Start";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            // 
            // frmAssignment05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 504);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblWin);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAssignment05";
            this.Text = "Assignment05";
            this.Load += new System.EventHandler(this.frmAssignment05_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.Label lblStart;
    }
}

