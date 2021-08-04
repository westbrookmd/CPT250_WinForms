
namespace CPT230InClass05
{
    partial class GameControllerForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblDidWeWin = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.lstboxGameResults = new System.Windows.Forms.ListBox();
            this.btnHistory = new System.Windows.Forms.Button();
            this.lblWinRate = new System.Windows.Forms.Label();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.chrtGameResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnMaze = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chrtGameResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(12, 124);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(311, 58);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Fight";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Visible = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblDidWeWin
            // 
            this.lblDidWeWin.AutoSize = true;
            this.lblDidWeWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDidWeWin.Location = new System.Drawing.Point(13, 9);
            this.lblDidWeWin.Name = "lblDidWeWin";
            this.lblDidWeWin.Size = new System.Drawing.Size(165, 26);
            this.lblDidWeWin.TabIndex = 2;
            this.lblDidWeWin.Text = "Enter the Maze!";
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(18, 436);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(787, 170);
            this.txtSummary.TabIndex = 3;
            this.txtSummary.Text = "For Details to be shown here, the History list  view, or the Win Rate Chart, you " +
    "must play 2 or more games.";
            // 
            // lstboxGameResults
            // 
            this.lstboxGameResults.FormattingEnabled = true;
            this.lstboxGameResults.Location = new System.Drawing.Point(120, 335);
            this.lstboxGameResults.Name = "lstboxGameResults";
            this.lstboxGameResults.Size = new System.Drawing.Size(120, 95);
            this.lstboxGameResults.TabIndex = 4;
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(18, 335);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(87, 23);
            this.btnHistory.TabIndex = 5;
            this.btnHistory.Text = "Check History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // lblWinRate
            // 
            this.lblWinRate.AutoSize = true;
            this.lblWinRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinRate.Location = new System.Drawing.Point(13, 185);
            this.lblWinRate.Name = "lblWinRate";
            this.lblWinRate.Size = new System.Drawing.Size(114, 26);
            this.lblWinRate.TabIndex = 6;
            this.lblWinRate.Text = "Win Rate: ";
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvanced.Location = new System.Drawing.Point(12, 227);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(157, 31);
            this.btnAdvanced.TabIndex = 7;
            this.btnAdvanced.Text = "Advanced Details";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // chrtGameResults
            // 
            chartArea2.Name = "ChartArea1";
            this.chrtGameResults.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chrtGameResults.Legends.Add(legend2);
            this.chrtGameResults.Location = new System.Drawing.Point(372, 51);
            this.chrtGameResults.Name = "chrtGameResults";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.LabelBorderWidth = 0;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.White;
            series2.Name = "Game Results";
            this.chrtGameResults.Series.Add(series2);
            this.chrtGameResults.Size = new System.Drawing.Size(433, 349);
            this.chrtGameResults.TabIndex = 8;
            this.chrtGameResults.Text = "Win Rate";
            // 
            // btnMaze
            // 
            this.btnMaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaze.Location = new System.Drawing.Point(12, 60);
            this.btnMaze.Name = "btnMaze";
            this.btnMaze.Size = new System.Drawing.Size(311, 58);
            this.btnMaze.TabIndex = 9;
            this.btnMaze.Text = "Maze";
            this.btnMaze.UseVisualStyleBackColor = true;
            this.btnMaze.Click += new System.EventHandler(this.btnMaze_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 264);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 31);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(175, 264);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(157, 31);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // GameControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 618);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMaze);
            this.Controls.Add(this.chrtGameResults);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.lblWinRate);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.lstboxGameResults);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.lblDidWeWin);
            this.Controls.Add(this.btnPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameControllerForm";
            this.Text = "Game Controller";
            this.Load += new System.EventHandler(this.GameControllerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chrtGameResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblDidWeWin;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.ListBox lstboxGameResults;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label lblWinRate;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtGameResults;
        private System.Windows.Forms.Button btnMaze;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}