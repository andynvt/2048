namespace Game_2048
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog_Backg = new System.Windows.Forms.ColorDialog();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHighScore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGird = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLine = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFont = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLine2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSound = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHowtoplay = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.colorDialog_Border = new System.Windows.Forms.ColorDialog();
            this.colorDialog_Gird = new System.Windows.Forms.ColorDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.picPause = new System.Windows.Forms.PictureBox();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPause)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 304);
            this.panel1.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMenu,
            this.mnuOption,
            this.mnuHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(307, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // mnuMenu
            // 
            this.mnuMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewGame,
            this.mnuHighScore,
            this.mnuExit});
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(50, 20);
            this.mnuMenu.Text = "Menu";
            this.mnuMenu.Click += new System.EventHandler(this.mnuMenu_Click);
            // 
            // mnuNewGame
            // 
            this.mnuNewGame.Name = "mnuNewGame";
            this.mnuNewGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNewGame.Size = new System.Drawing.Size(175, 22);
            this.mnuNewGame.Text = "New Game";
            this.mnuNewGame.Click += new System.EventHandler(this.mnuNewGame_Click);
            // 
            // mnuHighScore
            // 
            this.mnuHighScore.Name = "mnuHighScore";
            this.mnuHighScore.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuHighScore.Size = new System.Drawing.Size(175, 22);
            this.mnuHighScore.Text = "High Score";
            this.mnuHighScore.Click += new System.EventHandler(this.mnuHighScore_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuExit.Size = new System.Drawing.Size(175, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuOption
            // 
            this.mnuOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBackground,
            this.mnuBorder,
            this.mnuGird,
            this.mnuLine,
            this.mnuFont,
            this.mnuLine2,
            this.mnuSound});
            this.mnuOption.Name = "mnuOption";
            this.mnuOption.Size = new System.Drawing.Size(56, 20);
            this.mnuOption.Text = "Option";
            this.mnuOption.Click += new System.EventHandler(this.mnuOption_Click);
            // 
            // mnuBackground
            // 
            this.mnuBackground.Name = "mnuBackground";
            this.mnuBackground.Size = new System.Drawing.Size(170, 22);
            this.mnuBackground.Text = "Background Color";
            this.mnuBackground.Click += new System.EventHandler(this.mnuBackground_Click);
            // 
            // mnuBorder
            // 
            this.mnuBorder.Name = "mnuBorder";
            this.mnuBorder.Size = new System.Drawing.Size(170, 22);
            this.mnuBorder.Text = "Border Color";
            this.mnuBorder.Click += new System.EventHandler(this.mnuBorder_Click);
            // 
            // mnuGird
            // 
            this.mnuGird.Name = "mnuGird";
            this.mnuGird.Size = new System.Drawing.Size(170, 22);
            this.mnuGird.Text = "Gird Color";
            this.mnuGird.Click += new System.EventHandler(this.mnuGird_Click);
            // 
            // mnuLine
            // 
            this.mnuLine.Name = "mnuLine";
            this.mnuLine.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuFont
            // 
            this.mnuFont.Name = "mnuFont";
            this.mnuFont.Size = new System.Drawing.Size(170, 22);
            this.mnuFont.Text = "Font";
            this.mnuFont.Click += new System.EventHandler(this.mnuFont_Click);
            // 
            // mnuLine2
            // 
            this.mnuLine2.BackColor = System.Drawing.Color.Black;
            this.mnuLine2.ForeColor = System.Drawing.Color.Black;
            this.mnuLine2.Name = "mnuLine2";
            this.mnuLine2.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuSound
            // 
            this.mnuSound.Name = "mnuSound";
            this.mnuSound.Size = new System.Drawing.Size(170, 22);
            this.mnuSound.Text = "Sound";
            this.mnuSound.Click += new System.EventHandler(this.mnuSound_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout,
            this.mnuHowtoplay});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(152, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuHowtoplay
            // 
            this.mnuHowtoplay.Name = "mnuHowtoplay";
            this.mnuHowtoplay.Size = new System.Drawing.Size(152, 22);
            this.mnuHowtoplay.Text = "How To Play";
            this.mnuHowtoplay.Click += new System.EventHandler(this.mnuHowtoplay_Click);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTime.Location = new System.Drawing.Point(3, 35);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(123, 45);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.SystemColors.Control;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblScore.Location = new System.Drawing.Point(183, 35);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(124, 45);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "00000";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picPause
            // 
            this.picPause.BackColor = System.Drawing.SystemColors.Control;
            this.picPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPause.Location = new System.Drawing.Point(132, 35);
            this.picPause.Name = "picPause";
            this.picPause.Size = new System.Drawing.Size(45, 45);
            this.picPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPause.TabIndex = 5;
            this.picPause.TabStop = false;
            this.picPause.Click += new System.EventHandler(this.picPause_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(307, 390);
            this.ControlBox = false;
            this.Controls.Add(this.picPause);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048 by Andy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PressKey);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPause)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog_Backg;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuOption;
        private System.Windows.Forms.ToolStripMenuItem mnuBackground;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuHowtoplay;
        private System.Windows.Forms.ToolStripMenuItem mnuNewGame;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.ToolStripMenuItem mnuBorder;
        private System.Windows.Forms.ToolStripMenuItem mnuGird;
        private System.Windows.Forms.ColorDialog colorDialog_Border;
        private System.Windows.Forms.ColorDialog colorDialog_Gird;
        private System.Windows.Forms.ToolStripMenuItem mnuFont;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuSound;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripSeparator mnuLine2;
        private System.Windows.Forms.ToolStripSeparator mnuLine;
        private System.Windows.Forms.PictureBox picPause;
        private System.Windows.Forms.ToolStripMenuItem mnuHighScore;
    }
}

