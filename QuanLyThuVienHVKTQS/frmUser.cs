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
    public partial class frmUser : Form
    {
        private bool Them_bool=false;
        private bool Sua_bool=false;
        List<User> l = null;
        public frmUser()
        {
            InitializeComponent();
            HienThi_User();
        }
        public void btn_enable(bool t)
        {
            groupuser.Enabled = t;
            luu_userbtn.Enabled = t;
            boqua_userbtn.Enabled = t;
            Them_userbtn.Enabled = !t;
            Sua_userbtn.Enabled = !t;
            xoa_userbtn.Enabled = !t;
            Them_bool = Sua_bool = false;
        }
        public void HienThi_User()
        {
            
            var user = new UserController();
            l = user.Detail();
            listView_User.Items.Clear();
            int i = 1;
            foreach (User u in l)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "" + i++;
                item.SubItems.Add(u.ID.ToString());
                item.SubItems.Add(u.UserName.ToString());
                item.SubItems.Add(u.Password.ToString());
                item.SubItems.Add(u.IsAdmin.ToString());

                listView_User.Items.Add(item);
            }
            btn_enable(false);
        }

        public void ListView_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_User.SelectedItems.Count == 0) return;
            int id = Convert.ToInt32(listView_User.SelectedItems[0].SubItems[1].Text);
            int index = l.FindIndex(m=>m.ID==id);

            IDtxt.Text = l[index].ID.ToString();
            usernametxt.Text = l[index].UserName.ToString();
            passwordtxt.Text = l[index].Password.ToString();
            isadmincbx.Text = l[index].IsAdmin.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btn_enable(true);
            IDtxt.Text = "";
            usernametxt.Text = "";
            passwordtxt.Text = "";
            isadmincbx.Text = "false";
            Them_bool = true;
            
        }

        private void Sua_userbtn_Click(object sender, EventArgs e)
        {
            btn_enable(true);
            Sua_bool = true;
            
        }

        private void xoa_userbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa người dùng này?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(IDtxt.Text);
                var entity = new UserController();
                if (entity.Delete(id))
                    HienThi_User();
                else
                    MessageBox.Show("Xóa người dùng không thành công");
            }
        }

        private void luu_userbtn_Click(object sender, EventArgs e)
        {
            if(Them_bool==true && Sua_bool==false)
            {
                var user = new User();
                
                user.UserName = usernametxt.Text;
                user.Password = passwordtxt.Text;
                user.IsAdmin = Convert.ToBoolean(isadmincbx.Text);

                var entity = new UserController();
                if(entity.Add(user)>0)
                {
                    HienThi_User();
                }
                else if(entity.Add(user)==-1)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                }
                else
                    MessageBox.Show("Thêm không thành công");
            }
            else if(Them_bool == false && Sua_bool == true)
            {
                var user = new User();
                user.ID =Convert.ToInt32(IDtxt.Text);
                user.UserName = usernametxt.Text;
                user.Password = passwordtxt.Text;
                user.IsAdmin =Convert.ToBoolean(isadmincbx.Text);

                var entity = new UserController();
                if (entity.Edit(user))
                {
                    
                    HienThi_User();
                }
                else
                    MessageBox.Show("Thêm không thành công");
            }
            btn_enable(false);
        }

        private void boqua_userbtn_Click(object sender, EventArgs e)
        {
            btn_enable(false);
        }

        private void thoat_userbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void search_usertxt_TextChanged(object sender, EventArgs e)
        {
            QuanLiThuVienHVKTQSDataContext db = new QuanLiThuVienHVKTQSDataContext();
            var list = (from u in db.Users where (u.ID.ToString().Contains(search_usertxt.Text) || u.UserName.ToString().Contains(search_usertxt.Text)) select u).ToList();
            listView_User.Items.Clear();
            int i = 1;
            foreach (User u in list)
            {
                ListViewItem item = new ListViewItem();
                item.Text = ""+i++;
                item.SubItems.Add(u.ID.ToString());
                item.SubItems.Add(u.UserName);
                item.SubItems.Add(u.Password);
                item.SubItems.Add(u.IsAdmin.ToString());

                listView_User.Items.Add(item);

            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {

        }

        private void quanLiSachToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
