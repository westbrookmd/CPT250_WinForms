
namespace Assignment1Westbrook
{
    partial class frmAssignment1
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
            this.txtInitials = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInitials
            // 
            this.txtInitials.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInitials.Location = new System.Drawing.Point(13, 13);
            this.txtInitials.Multiline = true;
            this.txtInitials.Name = "txtInitials";
            this.txtInitials.Size = new System.Drawing.Size(776, 212);
            this.txtInitials.TabIndex = 0;
            this.txtInitials.TabStop = false;
            this.txtInitials.WordWrap = false;
            this.txtInitials.TextChanged += new System.EventHandler(this.txtInitials_TextChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 231);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(89, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "&Random Color";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // frmAssignment1
            // 
            this.AcceptButton = this.btnRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 270);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtInitials);
            this.Name = "frmAssignment1";
            this.Text = "Assignment 1 Westbrook";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInitials;
        private System.Windows.Forms.Button btnRun;
    }
}

