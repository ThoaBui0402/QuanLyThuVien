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
            
        }
        private void ShowDG()
        {
           
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
        private void dangnhapbtn_Click(object sender, EventArgs e)
        {
            var entity = new User();
            entity.UserName = usernametxt.Text;
            entity.Password = passwordtxt.Text;
            
            try
            {
                var s = new UserController();
                var result = s.IsAdmin(entity);
                if (result == -1)
                {
                    MessageBox.Show("Đăng nhập không chính xác");
                    PhanQuyen.quyen = -1;
                    Load_Main();
                }
                else if (result == 0)
                {
                    MessageBox.Show("Đăng nhập thành công với quyền user");
                    PhanQuyen.quyen = 0;
                    Load_Main();

                }
                else if (result == 1)
                {
                    MessageBox.Show("Đăng nhập thành công với quyền admin");
                    PhanQuyen.quyen = 1;
                    Load_Main();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Đăng nhập không thành công");
                PhanQuyen.quyen = -1;
                Load_Main();

            }
            
        }

        

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usernametxt.Text = "";
            passwordtxt.Text = "";
            PhanQuyen.quyen = -1;
            Load_Main();
        }
        //Đăng ký
        private void dangkybtn_Click(object sender, EventArgs e)
        {
            var entity = new User();
            entity.UserName = usernametxt.Text;
            entity.Password = passwordtxt.Text;
            entity.IsAdmin = false;
            var s = new UserController();
            var result = s.Add(entity);
            if (result > 0)
            {
                MessageBox.Show("Đăng ký thành công");
            }
            else if (result == -1)
            {
                MessageBox.Show("Tên tài khoản đã tồn tại!");
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công ");
            }
        }
        private void thoatChươngTrinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void danhMucĐôcGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
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
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
