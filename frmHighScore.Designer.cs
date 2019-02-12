namespace Game_2048
{
    partial class frmHighScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHighScore));
            this.picThanh_Tich = new System.Windows.Forms.PictureBox();
            this.itemHighScore = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Player = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picThanh_Tich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picThanh_Tich
            // 
            this.picThanh_Tich.BackColor = System.Drawing.SystemColors.Control;
            this.picThanh_Tich.Dock = System.Windows.Forms.DockStyle.Top;
            this.picThanh_Tich.Location = new System.Drawing.Point(0, 0);
            this.picThanh_Tich.Name = "picThanh_Tich";
            this.picThanh_Tich.Size = new System.Drawing.Size(244, 244);
            this.picThanh_Tich.TabIndex = 0;
            this.picThanh_Tich.TabStop = false;
            // 
            // itemHighScore
            // 
            this.itemHighScore.BackColor = System.Drawing.Color.LightSeaGreen;
            this.itemHighScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemHighScore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Player,
            this.Tile,
            this.Score});
            this.itemHighScore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itemHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.itemHighScore.FullRowSelect = true;
            this.itemHighScore.GridLines = true;
            this.itemHighScore.Location = new System.Drawing.Point(0, 245);
            this.itemHighScore.MultiSelect = false;
            this.itemHighScore.Name = "itemHighScore";
            this.itemHighScore.Size = new System.Drawing.Size(244, 121);
            this.itemHighScore.TabIndex = 1;
            this.itemHighScore.UseCompatibleStateImageBehavior = false;
            this.itemHighScore.View = System.Windows.Forms.View.Details;
            // 
            // No
            // 
            this.No.Text = "#";
            this.No.Width = 20;
            // 
            // Player
            // 
            this.Player.Text = "Player";
            this.Player.Width = 121;
            // 
            // Tile
            // 
            this.Tile.Text = "Tile";
            this.Tile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tile.Width = 50;
            // 
            // Score
            // 
            this.Score.Text = "Score";
            this.Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Score.Width = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Game_2048.Properties.Resources.cupicon;
            this.pictureBox1.Location = new System.Drawing.Point(7, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 216);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmHighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 366);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.itemHighScore);
            this.Controls.Add(this.picThanh_Tich);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHighScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "High Score";
            this.Load += new System.EventHandler(this.frmHighScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picThanh_Tich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picThanh_Tich;
        private System.Windows.Forms.ListView itemHighScore;
        private System.Windows.Forms.ColumnHeader Score;
        private System.Windows.Forms.ColumnHeader Player;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Tile;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}