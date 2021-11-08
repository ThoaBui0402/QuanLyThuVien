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
    public partial class frmDocGia : Form
    {
        List<docgia> l = null;
        private bool Them_bool = false;
        private bool Sua_bool = false;
        public frmDocGia()
        {
            InitializeComponent();
            HienThi_DG();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void HienThi_DG()
        {
            var dg = new DocGiaController();
            l = dg.Detail();
            listView_DG.Items.Clear();
            int i = 1;

            sothetxt.Text = l[0].sothe.ToString();
            tendgtxt.Text = l[0].hoten.ToString();
            ngaysinhdg.Text = l[0].ngaysinh.ToString();
            if (l[0].gioitinh == null) gioitinhdgtxt.Text = "";
            else gioitinhdgtxt.Text = l[0].gioitinh.ToString();
            if (l[0].email == null) emaildgtxt.Text = "";
            else emaildgtxt.Text = l[0].email.ToString();
            if (l[0].diachi == null) diachidgtxt.Text = "";
            else diachidgtxt.Text = l[0].diachi.ToString();
            if (l[0].socmtnd == null) socmtnddgtxt.Text = "";
            else socmtnddgtxt.Text = l[0].socmtnd.ToString();
            if (l[0].ngaylamthe == null) ngaythedg.Text = "";
            else ngaythedg.Text = l[0].ngaylamthe.ToString();
            if (l[0].handungthe == null) hanthedg.Text = "";
            else hanthedg.Text = l[0].handungthe.ToString();
            foreach (var row in l)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "" + i++;
                item.SubItems.Add(row.sothe.ToString());
                item.SubItems.Add(row.hoten.ToString());
                item.SubItems.Add(row.ngaysinh.ToString());
                item.SubItems.Add(row.ngaylamthe.ToString());

                listView_DG.Items.Add(item);
            }
            if (PhanQuyen.quyen == 1)
                btn_enable(false);
            else
            {
                groupDG.Enabled = false;
                Them_DG.Enabled = Sua_DG.Enabled = Xoa_DG.Enabled = Luu_DG.Enabled = Boqua_DG.Enabled = false;
                Thoat_DG.Enabled = true;
            }
        }

        public void btn_enable(bool t)
        {
            groupDG.Enabled = t;
            Them_DG.Enabled = !t;
            Sua_DG.Enabled = !t;
            Xoa_DG.Enabled = !t;
            Luu_DG.Enabled = t;
            Boqua_DG.Enabled = t;
            Them_bool = false;
            Sua_bool = false;
        }
        public void ListView_DG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_DG.SelectedItems.Count == 0) return;
            int id = Convert.ToInt32(listView_DG.SelectedItems[0].SubItems[1].Text);
            int index = l.FindIndex(m => m.sothe == id);

            sothetxt.Text = l[index].sothe.ToString();
            tendgtxt.Text = l[index].hoten.ToString();
            ngaysinhdg.Text = l[index].ngaysinh.ToString();
            if (l[index].gioitinh == null) gioitinhdgtxt.Text = "";
            else gioitinhdgtxt.Text = l[index].gioitinh.ToString();
            if (l[index].email == null) emaildgtxt.Text = "";
            else emaildgtxt.Text = l[index].email.ToString();
            if (l[index].diachi == null) diachidgtxt.Text = "";
            else diachidgtxt.Text = l[index].diachi.ToString();
            if (l[index].socmtnd == null) socmtnddgtxt.Text = "";
            else socmtnddgtxt.Text = l[index].socmtnd.ToString();
            if (l[index].ngaylamthe == null) ngaythedg.Text = "";
            else ngaythedg.Text = l[index].ngaylamthe.ToString();
            if (l[index].handungthe == null) hanthedg.Text = "";
            else hanthedg.Text = l[index].handungthe.ToString();

        }
      
        private void Them_DG_Click(object sender, EventArgs e)
        {
            btn_enable(true);
            sothetxt.Text = "";
            tendgtxt.Text = "";
            ngaysinhdg.Text = "";
            gioitinhdgtxt.Text = "";
            emaildgtxt.Text = "";
            diachidgtxt.Text = "";
            socmtnddgtxt.Text = "";
            ngaythedg.Text = "";
            hanthedg.Text = "";
            this.Them_bool = true;
        }

        private void Sua_DG_Click(object sender, EventArgs e)
        {
            btn_enable(true);
            Sua_bool = true;
        }

        private void Xoa_DG_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa độc giả này?", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(sothetxt.Text);
                var entity = new DocGiaController();
                if (entity.delete(id))
                    HienThi_DG();
                else
                    MessageBox.Show("Xóa độc giả lỗi");
            }
        }

        private void Luu_DG_Click(object sender, EventArgs e)
        {
            if (Them_bool == true && Sua_bool == false)
            {
                var entity = new docgia();

                entity.sothe =Convert.ToInt32(sothetxt.Text);
                entity.hoten = tendgtxt.Text;
                entity.ngaysinh = ngaysinhdg.Value;
                entity.gioitinh = gioitinhdgtxt.Text;
                entity.diachi = diachidgtxt.Text;
                entity.email = emaildgtxt.Text;
                entity.socmtnd = socmtnddgtxt.Text;
                entity.ngaylamthe = ngaythedg.Value;
                entity.handungthe = hanthedg.Value;

                var dg = new DocGiaController();
                if (dg.Add(entity) > 0)
                    HienThi_DG();
                else
                    MessageBox.Show("Thêm độc giả không thành công");
            }
            if(Them_bool==false && Sua_bool==true)
            {
                var entity = new docgia();
                entity.sothe = Convert.ToInt32(sothetxt.Text);
                entity.hoten = tendgtxt.Text;
                entity.ngaysinh = ngaysinhdg.Value;
                entity.gioitinh = gioitinhdgtxt.Text;
                entity.diachi = diachidgtxt.Text;
                entity.email = emaildgtxt.Text;
                entity.socmtnd = socmtnddgtxt.Text;
                entity.ngaylamthe = ngaythedg.Value;
                entity.handungthe = hanthedg.Value;

                var dg = new DocGiaController();
                if (dg.Edit(entity))
                    HienThi_DG();
                else
                    MessageBox.Show("Sửa độc giả không thành công");
            }
            btn_enable(false);
        }

        private void Boqua_DG_Click(object sender, EventArgs e)
        {
            btn_enable(false);
        }

        private void Thoat_DG_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchtxt_KeyUp(object sender, KeyEventArgs e)
        {
            QuanLiThuVienHVKTQSDataContext db = new QuanLiThuVienHVKTQSDataContext();
            int i = 1;
            var lst = (from s in db.docgias where (s.sothe.ToString().Contains(searchtxt.Text) || s.hoten.ToString().Contains(searchtxt.Text)) select s).ToList();
            listView_DG.Items.Clear();
            foreach (docgia d in lst)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "" + i++;
                item.SubItems.Add(d.sothe.ToString());
                item.SubItems.Add(d.hoten.ToString());
                item.SubItems.Add(d.ngaysinh.ToString());
                item.SubItems.Add(d.ngaylamthe.ToString());

                listView_DG.Items.Add(item);
            }
        }
    }
}
