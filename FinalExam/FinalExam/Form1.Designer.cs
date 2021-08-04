
namespace FinalExam
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.txtForDemo = new System.Windows.Forms.TextBox();
            this.txtForDemo2 = new System.Windows.Forms.TextBox();
            this.txtForDemoKid = new System.Windows.Forms.TextBox();
            this.txtForDemoKid2 = new System.Windows.Forms.TextBox();
            this.txtDemoKidCompare = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(56, 311);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(94, 29);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtForDemo
            // 
            this.txtForDemo.Location = new System.Drawing.Point(156, 37);
            this.txtForDemo.Name = "txtForDemo";
            this.txtForDemo.Size = new System.Drawing.Size(270, 27);
            this.txtForDemo.TabIndex = 1;
            // 
            // txtForDemo2
            // 
            this.txtForDemo2.Location = new System.Drawing.Point(156, 88);
            this.txtForDemo2.Name = "txtForDemo2";
            this.txtForDemo2.Size = new System.Drawing.Size(270, 27);
            this.txtForDemo2.TabIndex = 2;
            // 
            // txtForDemoKid
            // 
            this.txtForDemoKid.Location = new System.Drawing.Point(156, 140);
            this.txtForDemoKid.Name = "txtForDemoKid";
            this.txtForDemoKid.Size = new System.Drawing.Size(270, 27);
            this.txtForDemoKid.TabIndex = 3;
            // 
            // txtForDemoKid2
            // 
            this.txtForDemoKid2.Location = new System.Drawing.Point(156, 192);
            this.txtForDemoKid2.Name = "txtForDemoKid2";
            this.txtForDemoKid2.Size = new System.Drawing.Size(270, 27);
            this.txtForDemoKid2.TabIndex = 4;
            // 
            // txtDemoKidCompare
            // 
            this.txtDemoKidCompare.Location = new System.Drawing.Point(156, 241);
            this.txtDemoKidCompare.Name = "txtDemoKidCompare";
            this.txtDemoKidCompare.Size = new System.Drawing.Size(270, 27);
            this.txtDemoKidCompare.TabIndex = 5;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(279, 311);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "demo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "demo2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "demoKid:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "demoKid2:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "DemoKidCompare:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 372);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtDemoKidCompare);
            this.Controls.Add(this.txtForDemoKid2);
            this.Controls.Add(this.txtForDemoKid);
            this.Controls.Add(this.txtForDemo2);
            this.Controls.Add(this.txtForDemo);
            this.Controls.Add(this.btnRun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtForDemo;
        private System.Windows.Forms.TextBox txtForDemo2;
        private System.Windows.Forms.TextBox txtForDemoKid;
        private System.Windows.Forms.TextBox txtForDemoKid2;
        private System.Windows.Forms.TextBox txtDemoKidCompare;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

