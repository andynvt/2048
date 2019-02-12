using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Game_2048
{
    public partial class frmHighScore : Form
    {
        private string path = System.IO.Directory.GetCurrentDirectory() + "\\data\\";
        private string[] arrItem;
        public int Row = 5, Col = 4;

        public frmHighScore()
        {
            InitializeComponent();
        }
        private void frmHighScore_Load(object sender, EventArgs e)
        {

            arrItem = new string[Col];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    arrItem[j] = "";
                }
                ListViewItem items = new ListViewItem(arrItem);
                itemHighScore.Items.Add(items);
            }
            FileStream f = new FileStream(path + "highscore.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader r = new StreamReader(f);
            for (int i = 0; i < Row; i++)
            {
                itemHighScore.Items[i].SubItems[0].Text = (i + 1).ToString();
                itemHighScore.Items[i].SubItems[1].Text = r.ReadLine().Trim();
                itemHighScore.Items[i].SubItems[2].Text = r.ReadLine().Trim();
                itemHighScore.Items[i].SubItems[3].Text = r.ReadLine().Trim();
            }
            r.Close();
            f.Close();
        }
    }
}
