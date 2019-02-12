using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Game_2048
{
    public partial class Form1 : Form
    {
        private Label[,] tileGird, tileBackgr;
        private int[,] tileValue;
        private Boolean Allow, Playing, Win, Continue, Play, Moved, Move, Over;
        private Bitmap bmpNew, bmpCancel, bmpPlay, bmpPause, bmpSound, bmpNoSound;
        public int PlaySound, Row = 4, Col = 4, BackgSize = 73, Distance = 2, Size = 61, OneTab = 0, MaxTile = 2048;
        private int Time, Minute, Second, Late, MaxSize, MaxRow, MaxCol, FontSize, rows, cols, DefaultTile, In, Before, Source, Bonus, Score, Option;
        private string path = System.IO.Directory.GetCurrentDirectory() + "\\data\\";
        private Random ran = new Random();

        public Form1()
        {
            InitializeComponent();
        }
        private void loadColor(int rows, int cols)
        {
            switch (tileValue[rows, cols])
            {
                case 2:
                    tileGird[rows, cols].BackColor = Color.FromArgb(255, 255, 128);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(180, 180, 128);
                    break;
                case 4:
                    tileGird[rows, cols].BackColor = Color.FromArgb(255, 255, 0);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(255, 140, 0);
                    break;
                case 8:
                    tileGird[rows, cols].BackColor = Color.FromArgb(255, 165, 0);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(255, 240, 0);
                    break;
                case 16:
                    tileGird[rows, cols].BackColor = Color.FromArgb(255, 99, 71);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(255, 0, 0);
                    break;
                case 32:
                    tileGird[rows, cols].BackColor = Color.FromArgb(255, 0, 0);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(255, 100, 100);
                    break;
                case 64:
                    tileGird[rows, cols].BackColor = Color.FromArgb(154, 205, 50);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(0, 170, 0);
                    break;
                case 128:
                    tileGird[rows, cols].BackColor = Color.FromArgb(0, 255, 0);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(0, 170, 0);
                    break;
                case 256:
                    tileGird[rows, cols].BackColor = Color.FromArgb(34, 139, 34);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(154, 205, 50);
                    break;
                case 512:
                    tileGird[rows, cols].BackColor = Color.FromArgb(0, 146, 123);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(0, 200, 200);
                    break;
                case 1024:
                    tileGird[rows, cols].BackColor = Color.FromArgb(0, 0, 255);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(150, 150, 255);
                    break;
                case 2048:
                    tileGird[rows, cols].BackColor = Color.FromArgb(255, 0, 255);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(128, 0, 128);
                    break;
                default:
                    tileGird[rows, cols].BackColor = Color.FromArgb(128, 0, 128);
                    tileGird[rows, cols].ForeColor = Color.FromArgb(255, 0, 255);
                    break;
            }
        }
        private void loadText(int rows, int cols)
        {
            tileGird[rows, cols].Font = new Font(fontDialog.Font.FontFamily, fontSize(tileValue[rows, cols]), fontDialog.Font.Style);
            tileGird[rows, cols].Text = tileValue[rows, cols].ToString();
        }
        private void showTile(int value, int rows, int cols)
        {
            tileValue[rows, cols] = value;
            loadColor(rows, cols);
            loadText(rows, cols);
            tileGird[rows, cols].Visible = true;
        }
        private void showTile(int rows, int cols)
        {
            loadColor(rows, cols);
            loadText(rows, cols);
            tileGird[rows, cols].Visible = true;
        }
        private void hideTile(int rows, int cols)
        {
            tileValue[rows, cols] = 0;
            tileGird[rows, cols].Visible = false;
        }
        private void playingSounding(string file)
        {
            SoundPlayer Sound = new SoundPlayer(path + "sound\\" + file + ".wav");
            Sound.LoadAsync();
            Sound.Play();
        }
        public void playSound(string file)
        {
            if (PlaySound == 1)
            {
                playingSounding(file);
            }
        }
        private void loadTile(int n)
        {
            int EmptyTile = empty();
            if (EmptyTile >= n)
            {
                while (n > 0)
                {
                    rows = ran.Next(0, Row);
                    cols = ran.Next(0, Col);
                    if (tileValue[rows, cols] == 0)
                    {
                        DefaultTile = ran.Next(0, 2);
                        if (DefaultTile == 0)
                        {
                            showTile(2, rows, cols);
                        }
                        else
                        {
                            showTile(4, rows, cols);
                        }
                        n--; EmptyTile--;
                    }
                }
                if (EmptyTile == 0)
                {
                    if (keepPlaying() == 0)
                    {
                        Allow = false; picPause.Enabled = false; mainMenu.Enabled = false;
                        if (Win == false)
                        {
                            playSound("lose");
                        }
                        else
                        {
                            playSound("win");
                        }
                        Over = true;
                    }
                    else
                    {
                        if (Moved)
                        {
                            Continue = true;
                        }
                    }
                }
                else
                {
                    if (Moved)
                    {
                        Continue = true;
                    }
                }
            }
        }
        private void picPause_Click(object sender, EventArgs e)
        {
            playSound("Menu");
            if (Time == 1)
            {
                Time = 0; pauseGame();
            }
            else
            {
                Time = 1; continueGame();
            }
            setPicPause();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmpNew = new Bitmap(path + "new.png");
            bmpCancel = new Bitmap(path + "cancel.png");
            bmpPlay = new Bitmap(path + "play.png");
            bmpPause = new Bitmap(path + "pause.png");
            bmpSound = new Bitmap(path + "sound.png");
            bmpNoSound = new Bitmap(path + "nosound.png");

            mnuNewGame.Image = bmpNew;
            mnuExit.Image = new Bitmap(path + "exit.png");
            mnuBackground.Image = new Bitmap(path + "backgound.png");
            mnuFont.Image = new Bitmap(path + "font.png");
            mnuGird.Image = new Bitmap(path + "net.png");
            mnuBorder.Image = new Bitmap(path + "border.png");
            mnuOption.Image = new Bitmap(path + "option.png");
            mnuMenu.Image = new Bitmap(path + "menu.png");
            mnuMenu.Text = ""; mnuOption.Text = ""; mnuHelp.Text = "?";
            mnuAbout.Image = new Bitmap(path + "author.png");
            mnuHowtoplay.Image = new Bitmap(path + "howtoplay.png");
            mnuHighScore.Image = new Bitmap(path + "highscore.png");
            readOption(); Option = 0;

            panel1.BackColor = colorDialog_Border.Color;
            this.BackColor = colorDialog_Backg.Color;
            lblTime.BackColor = Color.Transparent;
            lblScore.BackColor = Color.Transparent;
            picPause.BackColor = Color.Transparent;


            setSound();

            OneTab = (BackgSize - Size) / 2;

            #region Khoi tao tileGird

            tileGird = new Label[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    tileGird[i, j] = new Label();
                    tileGird[i, j].AutoSize = false;
                    tileGird[i, j].Size = new Size(Size, Size);
                    tileGird[i, j].BorderStyle = BorderStyle.None;
                    tileGird[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    tileGird[i, j].Visible = false;
                    panel1.Controls.Add(tileGird[i, j]);
                }
            }

            #endregion

            #region Khoi tao tileBackgr

            tileBackgr = new Label[Row, Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    tileBackgr[i, j] = new Label();
                    tileBackgr[i, j].AutoSize = false;
                    tileBackgr[i, j].Text = "";
                    tileBackgr[i, j].Size = new Size(BackgSize, BackgSize);
                    tileBackgr[i, j].BorderStyle = BorderStyle.None;
                    tileBackgr[i, j].Location = new Point((j + 1) * Distance + j * BackgSize, (i + 1) * Distance + i * BackgSize);
                    tileGird[i, j].Location = new Point(tileBackgr[i, j].Location.X + OneTab, tileBackgr[i, j].Location.Y + OneTab);
                    tileBackgr[i, j].BackColor = colorDialog_Gird.Color;
                    tileBackgr[i, j].Visible = true;
                    panel1.Controls.Add(tileBackgr[i, j]);
                }
            }

            #endregion

            tileValue = new int[Row, Col];

            fontDialog.ShowEffects = false; fontDialog.MinSize = 20; fontDialog.MaxSize = 28;
            lblTime.Font = new Font(fontDialog.Font.FontFamily, fontSize(10), fontDialog.Font.Style);
            lblScore.Font = new Font(fontDialog.Font.FontFamily, fontSize(10), fontDialog.Font.Style);

            colorDialog_Backg.AllowFullOpen = false; colorDialog_Border.AllowFullOpen = false; colorDialog_Gird.AllowFullOpen = false;

            cancelGame(); Continue = readFromFile();
        }
        private void mnuHighScore_Click(object sender, EventArgs e)
        {
            frmHighScore frm_TT = new frmHighScore();
            frm_TT.ShowDialog();
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            pauseGame();
            playSound("menu");

            #region cancelGame() - Thoat

            if (!Playing)
            {
                if (Continue == false) { writeToFile(0); }
                saveOption(); this.Close();
            }

            #endregion

            else
            {
                #region New_Game() - Khong Play - Thoat

                if (Continue == false)
                {
                    if (MessageBox.Show("Click Yes to Close\nClick No to Continue game", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        writeToFile(0); saveOption(); this.Close();
                    }
                    else
                    {
                        continueGame();
                    }
                }

                #endregion

                else
                {
                    #region New_Game() - Play - Thoat

                    DialogResult Dre = MessageBox.Show("Do you want to save your session ?\nClick Yes to Save and Close\nClick No to NOT Save và Close\nClick Cancel to Continue game", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    switch (Dre)
                    {
                        case DialogResult.Cancel:
                            continueGame();
                            break;
                        case DialogResult.Yes:
                            writeToFile(1); saveOption();
                            this.Close();
                            break;
                        case DialogResult.No:
                            writeToFile(0); saveOption();
                            this.Close();
                            break;
                    }

                    #endregion
                }
            }
        }
        private void mnuMenu_Click(object sender, EventArgs e)
        {

        }
        private void mnuOption_Click(object sender, EventArgs e)
        {

        }
        private void mnuSound_Click(object sender, EventArgs e)
        {
            Option = 1;
            if (PlaySound == 1)
            {
                PlaySound = 0;
            }
            else
            {
                PlaySound = 1; playSound("Menu");
            }
            setSound();
        }
        private void mnuHelp_Click(object sender, EventArgs e)
        {

        }
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            playSound("menu");
            frmAbout frm = new frmAbout();
            frm.Show();
        }
        private void mnuHowtoplay_Click(object sender, EventArgs e)
        {
            playSound("menu");
            MessageBox.Show("How to play: \nUse your arrow keys to move the tiles. \nWhen two tiles with the same number touch, \nthey merge into one! \nTry to get 2048 tile :) ");

        }
        private void mnuFont_Click(object sender, EventArgs e)
        {
            playSound("Menu");
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Option = 1; FontSize = (int)fontDialog.Font.Size; Bonus = FontSize / 7;
                lblTime.Font = new Font(fontDialog.Font.FontFamily, fontSize(10), fontDialog.Font.Style);
                lblScore.Font = new Font(fontDialog.Font.FontFamily, fontSize(10), fontDialog.Font.Style);
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        if (tileGird[i, j].Visible == true)
                        {
                            tileGird[i, j].Font = new Font(fontDialog.Font.FontFamily, fontSize(tileValue[i, j]), fontDialog.Font.Style);
                        }
                    }
                }
            }
        }
        private void mnuGird_Click(object sender, EventArgs e)
        {
            playSound("Menu");
            if (colorDialog_Gird.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        tileBackgr[i, j].BackColor = colorDialog_Gird.Color;
                    }
                }
                Option = 1;
            }
        }
        private void mnuBorder_Click(object sender, EventArgs e)
        {
            playSound("Menu");
            if (colorDialog_Border.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog_Border.Color; Option = 1;
            }
        }
        private void mnuBackground_Click(object sender, EventArgs e)
        {
            playSound("menu");
            if (colorDialog_Backg.ShowDialog() == DialogResult.OK)
            {
                if (colorDialog_Backg.Color != Color.Black)
                {
                    this.BackColor = colorDialog_Backg.Color; Option = 1;
                }
                else
                {
                    MessageBox.Show("The background color is NOT black\nChange Color can not proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    colorDialog_Backg.Color = this.BackColor;
                }
            }
        }
        private void mnuNewGame_Click(object sender, EventArgs e)
        {
            if (Play == true)
            {
                #region Play

                if (Continue == false)
                {
                    Moved = false;
                }
                else
                {
                    if (MessageBox.Show("Do you want to Continue your session ?", "Remind", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Moved = true;
                    }
                    else
                    {
                        Continue = false; Moved = false;
                    }
                }
                New_Game();

                #endregion
            }
            else
            {
                #region Huy

                pauseGame();
                playSound("Menu");
                if (Continue)
                {
                    if (MessageBox.Show("Your session will NOT save!\nClick Yes to Cancel\nClick No to Continue", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cancelGame();
                    }
                    else
                    {
                        continueGame();
                    }
                }
                else
                {
                    cancelGame();
                }

                #endregion
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Over)
            {
                Second++;
                if (Second == 60)
                {
                    Second = 0;
                    Minute++;
                }
                loadTime(Minute, Second);
            }
            else
            {
                Late--;
                if (Late == 0)
                {
                    pauseGame(); findMax();
                    frmOverGame frm_KT = new frmOverGame(new Font(fontDialog.Font.FontFamily, fontSize(MaxSize), fontDialog.Font.Style), tileGird[MaxRow, MaxCol].BackColor, MaxSize, Score, lblTime.Text.Trim());
                    frm_KT.ShowDialog();
                    cancelGame();
                }
            }
        }
        private void moveToRight()
        {
            Move = false; int temp = 0;
            for (int i = 0; i < Row; i++)
            {
                Source = -1; In = 0; Before = 0;
                for (int j = Col - 1; j > -1; j--)
                {
                    if (tileValue[i, j] == 0)
                    {
                        In++;
                    }
                    else
                    {
                        if (Source == -1)
                        {
                            Source = j; Before = In;
                        }
                        else
                        {
                            if (tileValue[i, j] == tileValue[i, Source])
                            {
                                temp = temp + tileValue[i, Source];
                                showTile(tileValue[i, Source] * 2, i, Source + Before);
                                if (Before != 0)
                                {
                                    hideTile(i, Source);
                                }
                                hideTile(i, j);
                                Source = -1; Move = true; In++;
                            }
                            else
                            {
                                if (Before != 0)
                                {
                                    showTile(tileValue[i, Source], i, Source + Before);
                                    hideTile(i, Source);
                                    Move = true;
                                }
                                Source = j; Before = In;
                            }
                        }
                    }
                }
                if (Source != -1)
                {
                    if (Before != 0)
                    {
                        showTile(tileValue[i, Source], i, Source + Before);
                        hideTile(i, Source);
                        Move = true;
                    }
                }
            }
            if (Move)
            {
                if (temp > 0) { loadScore(temp); }
                playSound("Click");
                Moved = true; loadTile(1);
            }
        }
        private void moveToLeft()
        {
            Move = false; int temp = 0;
            for (int i = 0; i < Row; i++)
            {
                Source = -1; In = 0; Before = 0;
                for (int j = 0; j < Col; j++)
                {
                    if (tileValue[i, j] == 0)
                    {
                        In++;
                    }
                    else
                    {
                        if (Source == -1)
                        {
                            Source = j; Before = In;
                        }
                        else
                        {
                            if (tileValue[i, Source] == tileValue[i, j])
                            {
                                temp = temp + tileValue[i, Source];
                                showTile(tileValue[i, Source] * 2, i, Source - Before);
                                if (Before != 0)
                                {
                                    hideTile(i, Source);
                                }
                                hideTile(i, j);
                                Source = -1; Move = true; In++;
                            }
                            else
                            {
                                if (Before != 0)
                                {
                                    showTile(tileValue[i, Source], i, Source - Before);
                                    hideTile(i, Source);
                                    Move = true;
                                }
                                Source = j; Before = In;
                            }
                        }
                    }
                }
                if (Source != -1)
                {
                    if (Before != 0)
                    {
                        showTile(tileValue[i, Source], i, Source - Before);
                        hideTile(i, Source);
                        Move = true;
                    }
                }
            }
            if (Move)
            {
                if (temp > 0) { loadScore(temp); }
                playSound("Click");
                Moved = true; loadTile(1);
            }
        }
        private void moveToBottom()
        {
            Move = false; int temp = 0;
            for (int j = 0; j < Col; j++)
            {
                Source = -1; In = 0; Before = 0;
                for (int i = Row - 1; i > -1; i--)
                {
                    if (tileValue[i, j] == 0)
                    {
                        In++;
                    }
                    else
                    {
                        if (Source == -1)
                        {
                            Source = i; Before = In;
                        }
                        else
                        {
                            if (tileValue[i, j] == tileValue[Source, j])
                            {
                                temp = temp + tileValue[Source, j];
                                showTile(tileValue[Source, j] * 2, Source + Before, j);
                                if (Before != 0)
                                {
                                    hideTile(Source, j);
                                }
                                hideTile(i, j);
                                Source = -1; Move = true; In++;
                            }
                            else
                            {
                                if (Before != 0)
                                {
                                    showTile(tileValue[Source, j], Source + Before, j);
                                    hideTile(Source, j);
                                    Move = true;
                                }
                                Source = i; Before = In;
                            }
                        }
                    }
                }
                if (Source != -1)
                {
                    if (Before != 0)
                    {
                        showTile(tileValue[Source, j], Source + Before, j);
                        hideTile(Source, j);
                        Move = true;
                    }
                }
            }
            if (Move)
            {
                if (temp > 0) { loadScore(temp); }
                playSound("Click");
                Moved = true; loadTile(1);
            }
        }
        private void moveToTop()
        {
            Move = false; int temp = 0;
            for (int j = 0; j < Col; j++)
            {
                Source = -1; In = 0; Before = 0;
                for (int i = 0; i < Row; i++)
                {
                    if (tileValue[i, j] == 0)
                    {
                        In++;
                    }
                    else
                    {
                        if (Source == -1)
                        {
                            Source = i; Before = In;
                        }
                        else
                        {
                            if (tileValue[i, j] == tileValue[Source, j])
                            {
                                temp = temp + tileValue[Source, j];
                                showTile(tileValue[Source, j] * 2, Source - Before, j);
                                if (Before != 0)
                                {
                                    hideTile(Source, j);
                                }
                                hideTile(i, j);
                                Source = -1; Move = true; In++;
                            }
                            else
                            {
                                if (Before != 0)
                                {
                                    showTile(tileValue[Source, j], Source - Before, j);
                                    hideTile(Source, j);
                                    Move = true;
                                }
                                Source = i; Before = In;
                            }
                        }
                    }
                }
                if (Source != -1)
                {
                    if (Before != 0)
                    {
                        showTile(tileValue[Source, j], Source - Before, j);
                        hideTile(Source, j);
                        Move = true;
                    }
                }
            }
            if (Move)
            {
                if (temp > 0) { loadScore(temp); }
                playSound("Click");
                Moved = true; loadTile(1);
            }
        }
        private int empty()
        {
            int result = 0;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (tileValue[i, j] == 0)
                    {
                        result++;
                    }
                    else
                    {
                        if (tileValue[i, j] >= MaxTile)
                        {
                            Win = true;
                        }
                        else
                        {
                            Win = false;
                        }
                    }
                }
            }
            return result;
        }

        private int keepPlaying()
        {
            int keep = 0;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    #region Kiem tra Laten

                    if (i > 0)
                    {
                        if (tileValue[i, j] == tileValue[i - 1, j])
                        {
                            keep = 1;
                            break;
                        }
                    }

                    #endregion

                    #region Kiem tra Duoi

                    if (i < Row - 1)
                    {
                        if (tileValue[i, j] == tileValue[i + 1, j])
                        {
                            keep = 1;
                            break;
                        }
                    }

                    #endregion

                    #region Kiem tra Trai

                    if (j > 0)
                    {
                        if (tileValue[i, j] == tileValue[i, j - 1])
                        {
                            keep = 1;
                            break;
                        }
                    }

                    #endregion

                    #region Kiem tra Phai

                    if (j < Col - 1)
                    {
                        if (tileValue[i, j] == tileValue[i, j + 1])
                        {
                            keep = 1;
                            break;
                        }
                    }

                    #endregion
                }
                if (keep == 1)
                {
                    break;
                }
            }
            return keep;
        }

        private void loadScore(int score)
        {
            Score = Score + score; string TextScore = "";
            if (Score < 10)
            {
                TextScore = "0000";
            }
            else
            {
                if (Score < 100)
                {
                    TextScore = "000";
                }
                else
                {
                    if (Score < 1000)
                    {
                        TextScore = "00";
                    }
                    else
                    {
                        TextScore = "0";
                    }
                }
            }
            lblScore.Text = TextScore + Score.ToString();
        }

        private void cancelGame()
        {
            pauseGame();
            hideControl();
            showMenu();
            mainMenu.Enabled = true;
            mnuNewGame.Text = "New Game";
            mnuNewGame.Image = bmpNew;
            Continue = false; Play = true; Time = 0; Playing = false;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    hideTile(i, j);
                }
            }
            defaultType();
        }

        private void New_Game()
        {
            playSound("NewGame");
            showControl();
            hideMenu();
            picPause.Enabled = true;
            mnuNewGame.Text = "Cancel";
            mnuNewGame.Image = bmpCancel;
            Win = false; Play = false; Over = false; Late = 4; Playing = true;
            int TileNumber = 1;
            if (!Continue)
            {
                Minute = 0; Second = 0; Score = 0; Time = 1; TileNumber = 2;
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        hideTile(i, j);
                    }
                }
            }
            else
            {
                loadSave();
            }
            loadTime(Minute, Second); loadScore(0);
            setPicPause(); loadTile(TileNumber);
            if (Time == 1)
            {
                continueGame();
            }
            else
            {
                pauseGame();
            }
        }

        private void showMenu()
        {
            mnuOption.Visible = true;
            mnuHelp.Visible = true;
            mnuHighScore.Visible = true;
        }

        private void hideMenu()
        {
            mnuOption.Visible = false;
            mnuHelp.Visible = false;
            mnuHighScore.Visible = false;
        }

        private void showControl()
        {
            this.Height = 419;
            panel1.Location = new Point(3, 83);
            lblTime.Visible = true;
            lblScore.Visible = true;
            picPause.Visible = true;
        }

        private void hideControl()
        {
            this.Height = 365;
            panel1.Location = new Point(3, 30);
            lblTime.Visible = false;
            lblScore.Visible = false;
            picPause.Visible = false;
        }

        private void findMax()
        {
            MaxSize = 0;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (tileValue[i, j] > MaxSize)
                    {
                        MaxSize = tileValue[i, j]; MaxRow = i; MaxCol = j;
                    }
                }
            }
        }

        private void defaultType()
        {
            int GD = ran.Next(0, 4);
            switch (GD)
            {
                case 0:
                    showTile(2, 2, 0);
                    showTile(0, 2, 1);
                    showTile(4, 2, 2);
                    showTile(8, 2, 3);
                    showTile(2, 0, 2);
                    showTile(0, 1, 2);
                    showTile(8, 3, 2);
                    break;
                case 1:
                    showTile(2, 0, 0);
                    showTile(0, 1, 1);
                    showTile(4, 2, 2);
                    showTile(8, 3, 3);
                    showTile(2, 0, 3);
                    showTile(0, 1, 2);
                    showTile(4, 2, 1);
                    showTile(8, 3, 0);
                    break;
                case 2:
                    showTile(2, 0, 0);
                    showTile(0, 0, 1);
                    showTile(4, 0, 2);
                    showTile(8, 0, 3);
                    showTile(4, 1, 3);
                    showTile(0, 2, 3);
                    showTile(2, 3, 3);
                    showTile(0, 3, 2);
                    showTile(4, 3, 1);
                    showTile(8, 3, 0);
                    showTile(4, 2, 0);
                    showTile(0, 1, 0);
                    break;
                case 3:
                    showTile(2, 0, 0);
                    showTile(0, 0, 1);
                    showTile(4, 0, 2);
                    showTile(8, 0, 3);
                    showTile(2, 3, 0);
                    showTile(0, 3, 1);
                    showTile(4, 3, 2);
                    showTile(8, 3, 3);
                    showTile(4, 1, 2);
                    showTile(0, 2, 1);
                    break;
            }
        }

        private Boolean readFromFile()
        {
            Boolean t = false;
            FileStream f = new FileStream(path + "save.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader r = new StreamReader(f);
            string str = r.ReadLine();
            if (str.Trim() != "a")
            {
                t = true;
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        tileValue[i, j] = Convert.ToInt16(str.Trim());
                        str = r.ReadLine();
                    }
                }
                Minute = Convert.ToInt16(str.Trim());
                str = r.ReadLine(); Second = Convert.ToInt16(str.Trim());
                str = r.ReadLine(); Score = Convert.ToInt16(str.Trim());
            }
            else
            {
                t = false;
            }
            str = r.ReadLine(); Time = Convert.ToInt16(str.Trim());
            r.Close(); f.Close();
            return t;
        }

        private void writeToFile(int T)
        {
            FileStream f = new FileStream(path + "save.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter w = new StreamWriter(f);
            if (T == 1)
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Col; j++)
                    {
                        w.WriteLine(tileValue[i, j]);
                    }
                }
                w.WriteLine(Minute); w.WriteLine(Second); w.WriteLine(Score);
            }
            else
            {
                w.WriteLine("a");
            }
            w.WriteLine(Time);
            w.Flush(); w.Close(); f.Close();
        }

        private void loadSave()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (tileValue[i, j] != 0)
                    {
                        showTile(i, j);
                    }
                    else
                    {
                        tileGird[i, j].Visible = false;
                    }
                }
            }
        }

        private void loadTime(int _Minute, int _Second)
        {
            string strTime = "";
            if (_Minute < 10)
            {
                strTime = "0" + _Minute.ToString();
            }
            else
            {
                strTime = _Minute.ToString();
            }
            strTime = strTime + ":";
            if (_Second < 10)
            {
                lblTime.Text = strTime + "0" + _Second.ToString();
            }
            else
            {
                lblTime.Text = strTime + _Second.ToString();
            }
        }

        private void writeOption()
        {
            FileStream f = new FileStream(path + "option.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(PlaySound);
            w.WriteLine(colorDialog_Backg.Color.R); w.WriteLine(colorDialog_Backg.Color.G); w.WriteLine(colorDialog_Backg.Color.B);
            w.WriteLine(colorDialog_Border.Color.R); w.WriteLine(colorDialog_Border.Color.G); w.WriteLine(colorDialog_Border.Color.B);
            w.WriteLine(colorDialog_Gird.Color.R); w.WriteLine(colorDialog_Gird.Color.G); w.WriteLine(colorDialog_Gird.Color.B);
            w.WriteLine(fontDialog.Font.Name); w.WriteLine(Convert.ToInt16(fontDialog.Font.Size)); w.WriteLine(fontDialog.Font.Style);
            w.Flush(); w.Close(); f.Close();
        }

        private void readOption()
        {
            FileStream f = new FileStream(path + "option.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader r = new StreamReader(f);
            string str = r.ReadLine(); PlaySound = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int R_Nen = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int G_Nen = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int B_Nen = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int R_Khung = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int G_Khung = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int B_Khung = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int R_Luoi = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int G_Luoi = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); int B_Luoi = Convert.ToInt16(str.Trim());
            str = r.ReadLine(); string F_Family = str.Trim();
            str = r.ReadLine(); FontSize = Convert.ToInt16(str.Trim());
            Bonus = FontSize / 7;
            str = r.ReadLine();
            if (str.Contains(",") == false)
            {
                switch (str.Trim())
                {
                    case "Regular":
                        fontDialog.Font = new Font(F_Family, FontSize, FontStyle.Regular);
                        break;
                    case "Bold":
                        fontDialog.Font = new Font(F_Family, FontSize, FontStyle.Bold);
                        break;
                    case "Italic":
                        fontDialog.Font = new Font(F_Family, FontSize, FontStyle.Italic);
                        break;
                }
            }
            else
            {
                fontDialog.Font = new Font(F_Family, FontSize, FontStyle.Bold | FontStyle.Italic);
            }
            colorDialog_Backg.Color = Color.FromArgb(R_Nen, G_Nen, B_Nen);
            colorDialog_Border.Color = Color.FromArgb(R_Khung, G_Khung, B_Khung);
            colorDialog_Gird.Color = Color.FromArgb(R_Luoi, G_Luoi, B_Luoi);
            r.Close(); f.Close();
        }

        private int fontSize(int value)
        {
            int result = FontSize, temp = noOfTile(value);
            if (temp > 1)
            {
                if (temp < 5)
                {
                    result = FontSize - temp * Bonus;
                }
                else
                {
                    result = FontSize - (temp - 1) * Bonus;
                }
            }
            return result;
        }

        private int noOfTile(int _value)
        {
            int TV = 1, Value = _value / 10;
            while (Value != 0)
            {
                Value = Value / 10; TV++;
            }
            return TV;
        }

        private void PressKey(object sender, KeyEventArgs e)
        {
            if (Allow)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        moveKey('T');
                        break;
                    case Keys.Right:
                        moveKey('P');
                        break;
                    case Keys.Up:
                        moveKey('L');
                        break;
                    case Keys.Down:
                        moveKey('X');
                        break;
                }
            }
        }

        private void moveKey(char x)
        {
            Allow = false;
            switch (x)
            {
                case 'T':
                    moveToLeft();
                    break;
                case 'P':
                    moveToRight();
                    break;
                case 'L':
                    moveToTop();
                    break;
                case 'X':
                    moveToBottom();
                    break;
            }
            if (Time == 1) { Allow = true; }
        }

        private void setSound()
        {
            if (PlaySound == 1)
            {
                mnuSound.Image = bmpNoSound;
                mnuSound.Text = "No Sound";
            }
            else
            {
                mnuSound.Image = bmpSound;
                mnuSound.Text = "Sound";
            }
        }

        private void saveOption()
        {
            if (Option == 1)
            {
                writeOption();
            }
        }

        private void setPicPause()
        {
            if (Time == 0)
            {
                picPause.Image = bmpPlay;
            }
            else
            {
                picPause.Image = bmpPause;
            }
        }

        private void pauseGame()
        {
            timer.Stop(); Allow = false;
        }

        private void continueGame()
        {
            if ((Time == 1) && (Playing == true))
            {
                timer.Start(); Allow = true;
            }
        }

    }
}