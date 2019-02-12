namespace Game_2048
{
    partial class frmOverGame
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
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.picSao = new System.Windows.Forms.PictureBox();
            this.lblDiem = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblO_Vuong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.AutoSize = true;
            this.btnLuu.BackColor = System.Drawing.Color.Green;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLuu.Location = new System.Drawing.Point(221, 106);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(39, 24);
            this.btnLuu.TabIndex = 12;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.SystemColors.Control;
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTen.Location = new System.Drawing.Point(103, 106);
            this.txtTen.Name = "txtTen";
            this.txtTen.ShortcutsEnabled = false;
            this.txtTen.Size = new System.Drawing.Size(112, 24);
            this.txtTen.TabIndex = 11;
            // 
            // picSao
            // 
            this.picSao.Location = new System.Drawing.Point(12, 139);
            this.picSao.Name = "picSao";
            this.picSao.Size = new System.Drawing.Size(260, 65);
            this.picSao.TabIndex = 10;
            this.picSao.TabStop = false;
            // 
            // lblDiem
            // 
            this.lblDiem.BackColor = System.Drawing.SystemColors.Control;
            this.lblDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDiem.Location = new System.Drawing.Point(103, 81);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(157, 24);
            this.lblDiem.TabIndex = 9;
            this.lblDiem.Text = "      Điểm : 00000";
            this.lblDiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.SystemColors.Control;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTime.Location = new System.Drawing.Point(103, 56);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(157, 24);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Thời gian : 00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblO_Vuong
            // 
            this.lblO_Vuong.BackColor = System.Drawing.Color.Lime;
            this.lblO_Vuong.Location = new System.Drawing.Point(24, 56);
            this.lblO_Vuong.Name = "lblO_Vuong";
            this.lblO_Vuong.Size = new System.Drawing.Size(73, 73);
            this.lblO_Vuong.TabIndex = 7;
            this.lblO_Vuong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOverGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.picSao);
            this.Controls.Add(this.lblDiem);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblO_Vuong);
            this.Name = "frmOverGame";
            this.Text = "frmOverGame";
            ((System.ComponentModel.ISupportInitialize)(this.picSao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.PictureBox picSao;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblO_Vuong;
    }
}