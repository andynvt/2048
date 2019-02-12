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
    public partial class frmOverGame : Form
    {
        private int TT_Moi = 0, Dem = 0;
        private frmHighScore objThanh_Tich;
        private int[] arrGia_Tri, arrDiem_Max;
        private string[] arrNguoi_Choi;
        private string Duong_Dan = System.IO.Directory.GetCurrentDirectory() + "\\Tai_Nguyen\\HD_Choi\\";

        public frmOverGame(Font Font_Chu, Color Mau_Nen, int O_Max, int Diem, string Time)
        {
            InitializeComponent();
            objThanh_Tich = new frmHighScore();
            lblTime.Text = "Thời gian : " + Time;
            lblDiem.Text = "      Điểm : " + Diem.ToString();
            lblO_Vuong.BackColor = Mau_Nen; lblO_Vuong.Font = Font_Chu;
            lblO_Vuong.Text = O_Max.ToString();

            #region Hien cac muc Sao

            if (O_Max >= 256)
            {
                lblO_Vuong.ForeColor = Color.White;
                switch (O_Max)
                {
                    case 256:
                        picSao.Image = new Bitmap(Duong_Dan + "Muc_2.png");
                        break;
                    case 512:
                        picSao.Image = new Bitmap(Duong_Dan + "Muc_3.png");
                        break;
                    case 1024:
                        picSao.Image = new Bitmap(Duong_Dan + "Muc_4.png");
                        break;
                    case 2048:
                        picSao.Image = new Bitmap(Duong_Dan + "Muc_5.png");
                        break;
                    default:
                        picSao.Image = new Bitmap(Duong_Dan + "Muc_5.png");
                        break;
                }
            }
            else
            {
                lblO_Vuong.ForeColor = Color.Black;
                if (O_Max == 128)
                {
                    picSao.Image = new Bitmap(Duong_Dan + "Muc_1.png");
                }
                else
                {
                    picSao.Image = new Bitmap(Duong_Dan + "Muc_0.png");
                }
            }

            #endregion

            #region Doc thanh tich

            arrGia_Tri = new int[objThanh_Tich.Row];
            arrDiem_Max = new int[objThanh_Tich.Row];
            arrNguoi_Choi = new string[objThanh_Tich.Row];
            FileStream File_Doc = new FileStream(Duong_Dan + "Thanh_Tich\\Thanh_Tich.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader Doc = new StreamReader(File_Doc);
            for (Dem = 0; Dem < objThanh_Tich.Row; Dem++)
            {
                arrNguoi_Choi[Dem] = Doc.ReadLine().Trim();
                arrGia_Tri[Dem] = Convert.ToInt32(Doc.ReadLine().Trim());
                arrDiem_Max[Dem] = Convert.ToInt32(Doc.ReadLine().Trim());
            }
            Doc.Close();
            File_Doc.Close();

            #endregion

            #region Sap xep thanh tich

            if (O_Max >= arrGia_Tri[objThanh_Tich.Row - 1])
            {
                for (Dem = 0; Dem < objThanh_Tich.Row; Dem++)
                {
                    if (O_Max == arrGia_Tri[Dem])
                    {
                        if (Diem > arrDiem_Max[Dem])
                        {
                            TT_Moi = 1;
                            arrDiem_Max[Dem] = Diem;
                        }
                        else
                        {
                            TT_Moi = 0;
                        }
                        break;
                    }
                    else
                    {
                        if (O_Max > arrGia_Tri[Dem])
                        {
                            TT_Moi = 1;
                            for (int i = objThanh_Tich.Row - 1; i >= Dem; i--)
                            {
                                if (i != Dem)
                                {
                                    arrGia_Tri[i] = arrGia_Tri[i - 1];
                                    arrDiem_Max[i] = arrDiem_Max[i - 1];
                                    arrNguoi_Choi[i] = arrNguoi_Choi[i - 1];
                                }
                                else
                                {
                                    arrGia_Tri[i] = O_Max;
                                    arrDiem_Max[i] = Diem;
                                }
                            }
                            break;
                        }
                        else
                        {
                            TT_Moi = 0;
                        }
                    }
                }
            }
            else
            {
                TT_Moi = 0;
            }

            #endregion

            if (TT_Moi == 0)
            {
                btnLuu.Visible = false;
                txtTen.Visible = false;
            }
            else
            {
                this.Text = "Thành Tích Mới";
                this.AcceptButton = btnLuu;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim() == "")
            {
                arrNguoi_Choi[Dem] = "Không tên";
            }
            else
            {
                arrNguoi_Choi[Dem] = txtTen.Text.Trim();
            }
            FileStream File_Ghi = new FileStream(Duong_Dan + "Thanh_Tich\\Thanh_Tich.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter Ghi = new StreamWriter(File_Ghi);
            for (Dem = 0; Dem < objThanh_Tich.Row; Dem++)
            {
                Ghi.WriteLine(arrNguoi_Choi[Dem]);
                Ghi.WriteLine(arrGia_Tri[Dem]);
                Ghi.WriteLine(arrDiem_Max[Dem]);
            }
            Ghi.Flush();
            Ghi.Close();
            File_Ghi.Close();
            this.Close();
        }

        private void frmKet_Thuc_Load(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTen.Text.Trim().Length < 9)
            {
                e.Handled = false;
            }
            else
            {
                if (!Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 161;
            const int WM_SYSCOMMAND = 274;
            const int HTCAPTION = 2;
            const int SC_MOVE = 61456;
            if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
            {
                return;
            }
            if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
            {
                return;
            }
            base.WndProc(ref m);
        }

    }
}