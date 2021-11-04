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
    public partial class DangNhap : Form
    {
        frmMain frm = new frmMain();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
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
                    frm.Load_Main();
                    this.Hide();
                    frm.Show();
                }
                else if (result == 0)
                {
                    MessageBox.Show("Đăng nhập thành công với quyền user");
                    PhanQuyen.quyen = 0;
                    frm.Load_Main();
                    this.Hide();
                    frm.Show();

                }
                else if (result == 1)
                {
                    MessageBox.Show("Đăng nhập thành công với quyền admin");
                    PhanQuyen.quyen = 1;
                    frm.Load_Main();
                    this.Hide();
                    frm.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Đăng nhập không thành công");
                PhanQuyen.quyen = -1;
                frm.Load_Main();
                this.Hide();
                frm.Show();

            }

        }



        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usernametxt.Text = "";
            passwordtxt.Text = "";
            PhanQuyen.quyen = -1;
            frm.Load_Main();
            this.Hide();
            frm.Show();
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
    }
}
