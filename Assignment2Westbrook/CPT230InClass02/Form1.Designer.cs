
namespace CPT230InClass02
{
    partial class Form1
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
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.lblInput2 = new System.Windows.Forms.Label();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.chk0 = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk8 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk6 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk7 = new System.Windows.Forms.CheckBox();
            this.txtInputKey = new System.Windows.Forms.TextBox();
            this.txtOutputKey = new System.Windows.Forms.TextBox();
            this.lblInputKey = new System.Windows.Forms.Label();
            this.lblOutputKey = new System.Windows.Forms.Label();
            this.btnKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(98, 100);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(350, 120);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "You are in a room with exits to the North, East, South, and West.";
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(98, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(350, 32);
            this.txtInput.TabIndex = 2;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(3, 19);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(78, 20);
            this.lblInput.TabIndex = 3;
            this.lblInput.Text = "Inventory:";
            this.lblInput.Click += new System.EventHandler(this.lblInput_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(19, 107);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(56, 20);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.Text = "Guide:";
            this.lblOutput.Click += new System.EventHandler(this.lblOutput_Click);
            // 
            // txtInput2
            // 
            this.txtInput2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput2.Location = new System.Drawing.Point(98, 56);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.ReadOnly = true;
            this.txtInput2.Size = new System.Drawing.Size(350, 32);
            this.txtInput2.TabIndex = 1;
            this.txtInput2.Text = "0";
            this.txtInput2.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // lblInput2
            // 
            this.lblInput2.AutoSize = true;
            this.lblInput2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput2.Location = new System.Drawing.Point(3, 63);
            this.lblInput2.Name = "lblInput2";
            this.lblInput2.Size = new System.Drawing.Size(74, 20);
            this.lblInput2.TabIndex = 3;
            this.lblInput2.Text = "Location:";
            this.lblInput2.Click += new System.EventHandler(this.lblOutput_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNorth.Location = new System.Drawing.Point(244, 226);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(79, 35);
            this.btnNorth.TabIndex = 4;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnEast
            // 
            this.btnEast.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEast.Location = new System.Drawing.Point(320, 262);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(79, 35);
            this.btnEast.TabIndex = 5;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSouth.Location = new System.Drawing.Point(244, 299);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(79, 35);
            this.btnSouth.TabIndex = 6;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnWest
            // 
            this.btnWest.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWest.Location = new System.Drawing.Point(168, 262);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(79, 35);
            this.btnWest.TabIndex = 7;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // chk0
            // 
            this.chk0.AutoCheck = false;
            this.chk0.AutoSize = true;
            this.chk0.Checked = true;
            this.chk0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk0.Location = new System.Drawing.Point(60, 280);
            this.chk0.Name = "chk0";
            this.chk0.Size = new System.Drawing.Size(15, 14);
            this.chk0.TabIndex = 8;
            this.chk0.UseVisualStyleBackColor = true;
            this.chk0.CheckedChanged += new System.EventHandler(this.chk0_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.AutoCheck = false;
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(39, 280);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(15, 14);
            this.chk4.TabIndex = 9;
            this.chk4.UseVisualStyleBackColor = true;
            this.chk4.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chk5
            // 
            this.chk5.AutoCheck = false;
            this.chk5.AutoSize = true;
            this.chk5.Location = new System.Drawing.Point(18, 280);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(15, 14);
            this.chk5.TabIndex = 10;
            this.chk5.UseVisualStyleBackColor = true;
            this.chk5.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chk1
            // 
            this.chk1.AutoCheck = false;
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(60, 260);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(15, 14);
            this.chk1.TabIndex = 11;
            this.chk1.UseVisualStyleBackColor = true;
            this.chk1.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // chk8
            // 
            this.chk8.AutoCheck = false;
            this.chk8.AutoSize = true;
            this.chk8.Location = new System.Drawing.Point(60, 240);
            this.chk8.Name = "chk8";
            this.chk8.Size = new System.Drawing.Size(15, 14);
            this.chk8.TabIndex = 12;
            this.chk8.UseVisualStyleBackColor = true;
            this.chk8.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.AutoCheck = false;
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(81, 280);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(15, 14);
            this.chk2.TabIndex = 13;
            this.chk2.UseVisualStyleBackColor = true;
            this.chk2.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // chk6
            // 
            this.chk6.AutoCheck = false;
            this.chk6.AutoSize = true;
            this.chk6.Location = new System.Drawing.Point(102, 280);
            this.chk6.Name = "chk6";
            this.chk6.Size = new System.Drawing.Size(15, 14);
            this.chk6.TabIndex = 14;
            this.chk6.UseVisualStyleBackColor = true;
            this.chk6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // chk3
            // 
            this.chk3.AutoCheck = false;
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(60, 300);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(15, 14);
            this.chk3.TabIndex = 15;
            this.chk3.UseVisualStyleBackColor = true;
            this.chk3.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // chk7
            // 
            this.chk7.AutoCheck = false;
            this.chk7.AutoSize = true;
            this.chk7.Location = new System.Drawing.Point(60, 320);
            this.chk7.Name = "chk7";
            this.chk7.Size = new System.Drawing.Size(15, 14);
            this.chk7.TabIndex = 16;
            this.chk7.UseVisualStyleBackColor = true;
            this.chk7.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // txtInputKey
            // 
            this.txtInputKey.Location = new System.Drawing.Point(212, 226);
            this.txtInputKey.Name = "txtInputKey";
            this.txtInputKey.Size = new System.Drawing.Size(87, 20);
            this.txtInputKey.TabIndex = 17;
            this.txtInputKey.Visible = false;
            // 
            // txtOutputKey
            // 
            this.txtOutputKey.Location = new System.Drawing.Point(212, 260);
            this.txtOutputKey.Name = "txtOutputKey";
            this.txtOutputKey.ReadOnly = true;
            this.txtOutputKey.Size = new System.Drawing.Size(87, 20);
            this.txtOutputKey.TabIndex = 18;
            this.txtOutputKey.Visible = false;
            // 
            // lblInputKey
            // 
            this.lblInputKey.AutoSize = true;
            this.lblInputKey.Location = new System.Drawing.Point(127, 226);
            this.lblInputKey.Name = "lblInputKey";
            this.lblInputKey.Size = new System.Drawing.Size(55, 13);
            this.lblInputKey.TabIndex = 19;
            this.lblInputKey.Text = "Key Input:";
            this.lblInputKey.Visible = false;
            // 
            // lblOutputKey
            // 
            this.lblOutputKey.AutoSize = true;
            this.lblOutputKey.Location = new System.Drawing.Point(127, 262);
            this.lblOutputKey.Name = "lblOutputKey";
            this.lblOutputKey.Size = new System.Drawing.Size(63, 13);
            this.lblOutputKey.TabIndex = 20;
            this.lblOutputKey.Text = "Key Output:";
            this.lblOutputKey.Visible = false;
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(130, 300);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(129, 23);
            this.btnKey.TabIndex = 21;
            this.btnKey.Text = "Check Combination";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Visible = false;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 359);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.lblOutputKey);
            this.Controls.Add(this.lblInputKey);
            this.Controls.Add(this.txtOutputKey);
            this.Controls.Add(this.txtInputKey);
            this.Controls.Add(this.chk7);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk6);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk8);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.chk5);
            this.Controls.Add(this.chk4);
            this.Controls.Add(this.chk0);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.lblInput2);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtInput2);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.Label lblInput2;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.CheckBox chk0;
        private System.Windows.Forms.CheckBox chk4;
        private System.Windows.Forms.CheckBox chk5;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.CheckBox chk8;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk6;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk7;
        private System.Windows.Forms.TextBox txtInputKey;
        private System.Windows.Forms.TextBox txtOutputKey;
        private System.Windows.Forms.Label lblInputKey;
        private System.Windows.Forms.Label lblOutputKey;
        private System.Windows.Forms.Button btnKey;
    }
}

