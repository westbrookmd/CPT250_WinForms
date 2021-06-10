
namespace CPT230Assignment03Westbrook
{
    partial class frmAssignment03
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignment03));
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtOutput2 = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.txtVillianHP = new System.Windows.Forms.TextBox();
            this.txtVillian = new System.Windows.Forms.TextBox();
            this.lblHPVillian = new System.Windows.Forms.Label();
            this.lblVillian = new System.Windows.Forms.Label();
            this.btnHeal = new System.Windows.Forms.Button();
            this.btnStun = new System.Windows.Forms.Button();
            this.pbxVillian = new System.Windows.Forms.PictureBox();
            this.pbxHero = new System.Windows.Forms.PictureBox();
            this.pbrVillian = new System.Windows.Forms.ProgressBar();
            this.pbrHero = new System.Windows.Forms.ProgressBar();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVillian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHero)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(412, 325);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(32, 32);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "5";
            this.txtOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAttack
            // 
            this.btnAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttack.Location = new System.Drawing.Point(302, 383);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(200, 32);
            this.btnAttack.TabIndex = 1;
            this.btnAttack.Text = "&Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(304, 325);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(74, 26);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "Heals:";
            // 
            // txtOutput2
            // 
            this.txtOutput2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput2.Location = new System.Drawing.Point(6, 383);
            this.txtOutput2.Multiline = true;
            this.txtOutput2.Name = "txtOutput2";
            this.txtOutput2.ReadOnly = true;
            this.txtOutput2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput2.Size = new System.Drawing.Size(269, 125);
            this.txtOutput2.TabIndex = 3;
            this.txtOutput2.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(304, 243);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 26);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name:";
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHP.Location = new System.Drawing.Point(304, 287);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(49, 26);
            this.lblHP.TabIndex = 6;
            this.lblHP.Text = "HP:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(412, 243);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(90, 32);
            this.txtName.TabIndex = 7;
            this.txtName.Text = "Hero";
            // 
            // txtHP
            // 
            this.txtHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHP.Location = new System.Drawing.Point(412, 284);
            this.txtHP.Name = "txtHP";
            this.txtHP.ReadOnly = true;
            this.txtHP.Size = new System.Drawing.Size(46, 32);
            this.txtHP.TabIndex = 8;
            this.txtHP.Text = "100";
            this.txtHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVillianHP
            // 
            this.txtVillianHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVillianHP.Location = new System.Drawing.Point(121, 287);
            this.txtVillianHP.Name = "txtVillianHP";
            this.txtVillianHP.ReadOnly = true;
            this.txtVillianHP.Size = new System.Drawing.Size(46, 32);
            this.txtVillianHP.TabIndex = 12;
            this.txtVillianHP.Text = "100";
            // 
            // txtVillian
            // 
            this.txtVillian.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVillian.Location = new System.Drawing.Point(121, 243);
            this.txtVillian.Name = "txtVillian";
            this.txtVillian.ReadOnly = true;
            this.txtVillian.Size = new System.Drawing.Size(100, 32);
            this.txtVillian.TabIndex = 11;
            this.txtVillian.Text = "Villian";
            // 
            // lblHPVillian
            // 
            this.lblHPVillian.AutoSize = true;
            this.lblHPVillian.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHPVillian.Location = new System.Drawing.Point(16, 287);
            this.lblHPVillian.Name = "lblHPVillian";
            this.lblHPVillian.Size = new System.Drawing.Size(49, 26);
            this.lblHPVillian.TabIndex = 10;
            this.lblHPVillian.Text = "HP:";
            // 
            // lblVillian
            // 
            this.lblVillian.AutoSize = true;
            this.lblVillian.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVillian.Location = new System.Drawing.Point(16, 243);
            this.lblVillian.Name = "lblVillian";
            this.lblVillian.Size = new System.Drawing.Size(77, 26);
            this.lblVillian.TabIndex = 9;
            this.lblVillian.Text = "Name:";
            // 
            // btnHeal
            // 
            this.btnHeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeal.Location = new System.Drawing.Point(302, 459);
            this.btnHeal.Name = "btnHeal";
            this.btnHeal.Size = new System.Drawing.Size(200, 32);
            this.btnHeal.TabIndex = 13;
            this.btnHeal.Text = "&Heal";
            this.btnHeal.UseVisualStyleBackColor = true;
            this.btnHeal.Click += new System.EventHandler(this.btnHeal_Click);
            // 
            // btnStun
            // 
            this.btnStun.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStun.Location = new System.Drawing.Point(302, 421);
            this.btnStun.Name = "btnStun";
            this.btnStun.Size = new System.Drawing.Size(200, 32);
            this.btnStun.TabIndex = 14;
            this.btnStun.Text = "&Stun";
            this.btnStun.UseVisualStyleBackColor = true;
            this.btnStun.Click += new System.EventHandler(this.btnStun_Click);
            // 
            // pbxVillian
            // 
            this.pbxVillian.Image = ((System.Drawing.Image)(resources.GetObject("pbxVillian.Image")));
            this.pbxVillian.Location = new System.Drawing.Point(21, 12);
            this.pbxVillian.Name = "pbxVillian";
            this.pbxVillian.Size = new System.Drawing.Size(200, 200);
            this.pbxVillian.TabIndex = 15;
            this.pbxVillian.TabStop = false;
            // 
            // pbxHero
            // 
            this.pbxHero.Image = ((System.Drawing.Image)(resources.GetObject("pbxHero.Image")));
            this.pbxHero.Location = new System.Drawing.Point(302, 12);
            this.pbxHero.Name = "pbxHero";
            this.pbxHero.Size = new System.Drawing.Size(200, 200);
            this.pbxHero.TabIndex = 16;
            this.pbxHero.TabStop = false;
            // 
            // pbrVillian
            // 
            this.pbrVillian.ForeColor = System.Drawing.Color.DarkGreen;
            this.pbrVillian.Location = new System.Drawing.Point(21, 214);
            this.pbrVillian.Name = "pbrVillian";
            this.pbrVillian.Size = new System.Drawing.Size(200, 23);
            this.pbrVillian.TabIndex = 17;
            this.pbrVillian.Value = 100;
            // 
            // pbrHero
            // 
            this.pbrHero.ForeColor = System.Drawing.Color.DarkGreen;
            this.pbrHero.Location = new System.Drawing.Point(302, 214);
            this.pbrHero.Name = "pbrHero";
            this.pbrHero.Size = new System.Drawing.Size(200, 23);
            this.pbrHero.TabIndex = 18;
            this.pbrHero.Value = 100;
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayAgain.Location = new System.Drawing.Point(6, 339);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(269, 38);
            this.btnPlayAgain.TabIndex = 19;
            this.btnPlayAgain.Text = "&Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Visible = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // frmAssignment03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 520);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.pbrHero);
            this.Controls.Add(this.pbrVillian);
            this.Controls.Add(this.pbxHero);
            this.Controls.Add(this.pbxVillian);
            this.Controls.Add(this.btnStun);
            this.Controls.Add(this.btnHeal);
            this.Controls.Add(this.txtVillianHP);
            this.Controls.Add(this.txtVillian);
            this.Controls.Add(this.lblHPVillian);
            this.Controls.Add(this.lblVillian);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtOutput2);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.txtOutput);
            this.Name = "frmAssignment03";
            this.Text = "CPT230Assignment03Westbrook";
            ((System.ComponentModel.ISupportInitialize)(this.pbxVillian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutput2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.TextBox txtVillianHP;
        private System.Windows.Forms.TextBox txtVillian;
        private System.Windows.Forms.Label lblHPVillian;
        private System.Windows.Forms.Label lblVillian;
        private System.Windows.Forms.Button btnHeal;
        private System.Windows.Forms.Button btnStun;
        private System.Windows.Forms.PictureBox pbxVillian;
        private System.Windows.Forms.PictureBox pbxHero;
        private System.Windows.Forms.ProgressBar pbrVillian;
        private System.Windows.Forms.ProgressBar pbrHero;
        private System.Windows.Forms.Button btnPlayAgain;
    }
}

