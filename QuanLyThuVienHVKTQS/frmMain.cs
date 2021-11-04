using QuanLyThuVienHVKTQS.controller;
using QuanLyThuVienHVKTQS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyThuVienHVKTQS
{
    
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Load_Main();
        }
        public void Load_Main()
        {
            quanLiDanhMucToolStripMenuItem.Enabled = false;
            if(PhanQuyen.quyen==1)
            {
                quanLiDanhMucToolStripMenuItem.Enabled = true;
                đăngXuâtToolStripMenuItem.Enabled = true;
                danhMucĐôcGiaToolStripMenuItem.Enabled = true;
                danhMucNhânViênToolStripMenuItem.Enabled = true;
                danhMucNhaXuâtBanToolStripMenuItem.Enabled = true;
                quanLiSachToolStripMenuItem.Enabled = true;
                quảnLýMượntrảSáchToolStripMenuItem.Enabled = true;
                quanlynguoidung_toolStripMenuItem.Enabled = true;

            }
            else if(PhanQuyen.quyen==0)
            {
                quanLiDanhMucToolStripMenuItem.Enabled = true;
                đăngXuâtToolStripMenuItem.Enabled = true;
                danhMucĐôcGiaToolStripMenuItem.Enabled = true;
                danhMucNhânViênToolStripMenuItem.Enabled = true;
                danhMucNhaXuâtBanToolStripMenuItem.Enabled = true;
                quanLiSachToolStripMenuItem.Enabled = true;
                quảnLýMượntrảSáchToolStripMenuItem.Enabled = true;
                quanlynguoidung_toolStripMenuItem.Enabled = false;
            }
            else
            {
                đăngXuâtToolStripMenuItem.Enabled = false;
                quanLiDanhMucToolStripMenuItem.Enabled = false;
            }
        }
        
        private void Show_NXB()
        {
           
        }
        private void Show_Sach()
        {
            frmSach s = new frmSach();
            s.ShowDialog();
        }
        private void ShowDG()
        {
            frmDocGia dg = new frmDocGia();
            dg.ShowDialog();
        }
        private void Show_NV()
        {
           
        }
        private void Show_MS()
        {
          
        }
        private void Show_User()
        {
            frmUser user = new frmUser();
            user.ShowDialog();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        //Đăng nhập
        
        private void thoatChươngTrinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void danhMucĐôcGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDG();
        }

        private void danhMucNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void quảnLýMượntrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void quanlynguoidung_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_User();
        }
        private void danhMucNhaXuâtBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quanLiSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Sach();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quanLiHêThôngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
