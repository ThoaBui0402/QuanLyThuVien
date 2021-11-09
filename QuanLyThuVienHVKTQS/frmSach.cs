using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVienHVKTQS.controller;
using QuanLyThuVienHVKTQS.Model;

namespace QuanLyThuVienHVKTQS
{
    public partial class frmSach : Form
    {
        List<sach> l = null;
        private bool Them_bool = false;
        private bool Sua_bool = false;
        public frmSach()
        {
            InitializeComponent();
            HienThiSach();
        }
        void HienThiSach()
        {
            var s = new SachController();
            l = s.Detail();
            lvSach.Items.Clear();

            var i = 1;

            var nxb = new NhaXuatBanController();
            List<nhaxuatban> listNXB = nxb.Detail();

            cbbNXB.DataSource = listNXB;
            cbbNXB.DisplayMember = "tennxb";
            cbbNXB.ValueMember = "manxb".ToString();

            txtMaSach.Text = l[0].masach.ToString();
            txtTenSach.Text = l[0].tensach.ToString();
            txtTacGia.Text = l[0].tentacgia.ToString();
            if (l[0].nhaxuatban != null)
                cbbNXB.Text = l[0].nhaxuatban.tennxb.ToString();
            else
                cbbNXB.Text = "";
            txtNamXB.Text = l[0].namxb.ToString();
            txtSoTrang.Text = l[0].sotrang.ToString();
            txtGiaTien.Text = l[0].giatien.ToString();
            txtSoLuong.Text = l[0].soluong.ToString();
            txtNgonNgu.Text = l[0].ngonngu.ToString();
            txtTheLoai.Text = l[0].theloai.ToString();
            foreach (sach row in l)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "" + i++;

                item.SubItems.Add(row.masach.ToString());
                item.SubItems.Add(row.tensach.ToString());
                item.SubItems.Add(row.theloai.ToString());
                item.SubItems.Add(row.ngonngu.ToString());
                item.SubItems.Add(row.soluong.ToString());

                lvSach.Items.Add(item);
            }
            if (PhanQuyen.quyen == 1)
                btn_edit(false);
            else
            {
                grpEdit.Enabled = false;
                btnThemSach.Enabled = btnSuaSach.Enabled = btnXoaSach.Enabled = btnLuuSach.Enabled = btnBoQua.Enabled = false;
                btnThoat.Enabled = true;
            }
        }
        public void btn_edit(bool t)
        {
            grpEdit.Enabled = t;
            btnLuuSach.Enabled = t;
            btnBoQua.Enabled = t;
            btnThemSach.Enabled = !t;
            btnSuaSach.Enabled = !t;
            btnXoaSach.Enabled = !t;
            btnThoat.Enabled = !t;
            Them_bool = false;
            Sua_bool = false;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grpEdit_Enter(object sender, EventArgs e)
        {

        }

        private void lvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSach.SelectedItems.Count == 0)
                return;
            int i = Convert.ToInt32(lvSach.SelectedItems[0].SubItems[1].Text);
            int index = l.FindIndex(m => m.masach == i);
            txtMaSach.Text = l[index].masach.ToString();
            txtTenSach.Text = l[index].tensach.ToString();
            txtTacGia.Text = l[index].tentacgia.ToString();
            if (l[index].manxb != null)
                cbbNXB.Text = l[index].nhaxuatban.tennxb.ToString();
            else
                cbbNXB.Text = "";
            txtNamXB.Text = l[index].namxb.ToString();
            txtSoTrang.Text = l[index].sotrang.ToString();
            txtGiaTien.Text = l[index].giatien.ToString();
            txtSoLuong.Text = l[index].soluong.ToString();
            txtNgonNgu.Text = l[index].ngonngu.ToString();
            txtTheLoai.Text = l[index].theloai.ToString();
        }

        private void groupsach_btn_Enter(object sender, EventArgs e)
        {

        }

        private void search_sachtxt_TextChanged(object sender, EventArgs e)
        {
            int i = 1;
            QuanLiThuVienHVKTQSDataContext db = new QuanLiThuVienHVKTQSDataContext();
            var lst = (from s in db.saches where (s.masach.ToString().Contains(search_sachtxt.Text) || s.tensach.ToString().Contains(search_sachtxt.Text)) select s).ToList();
            lvSach.Items.Clear();
            foreach (sach s in lst)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "" + i++;
                item.SubItems.Add(s.masach.ToString());
                item.SubItems.Add(s.tensach.ToString());
                item.SubItems.Add(s.theloai.ToString());
                item.SubItems.Add(s.ngonngu.ToString());
                item.SubItems.Add(s.soluong.ToString());

                lvSach.Items.Add(item);
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                int masach = Convert.ToInt32(txtMaSach.Text);
                var s = new SachController();
                if (s.Del(masach))
                    HienThiSach();
                else
                {
                    MessageBox.Show("Không xóa được!");
                }
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            btn_edit(true);
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            //txtNXB.Text = "";
            txtNamXB.Text = "";
            txtSoTrang.Text = "";
            txtGiaTien.Text = "";
            txtSoLuong.Text = "";
            txtNgonNgu.Text = "";
            txtTheLoai.Text = "";
            this.Them_bool = true;
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
             
          }

        private void btnLuuSach_Click(object sender, EventArgs e)
        {
            if (Them_bool == true && Sua_bool == false)
            {
                sach entity = new sach();
                //txtMaSach.Text = "";
                entity.tensach = txtTenSach.Text;
                entity.tentacgia = txtTacGia.Text;
                entity.manxb = Convert.ToInt32(cbbNXB.SelectedValue.ToString());
                if (txtNamXB.Text.Length > 0)
                    entity.namxb = Convert.ToInt32(txtNamXB.Text);
                if (txtSoTrang.Text.Length > 0)
                    entity.sotrang = Convert.ToInt32(txtSoTrang.Text);
                if (txtGiaTien.Text.Length > 0)
                    entity.giatien = Convert.ToDecimal(txtGiaTien.Text);
                if (txtSoLuong.Text.Length > 0)
                    entity.soluong = Convert.ToInt32(txtSoLuong.Text);
                entity.ngonngu = txtNgonNgu.Text;
                entity.theloai = txtTheLoai.Text;
                var s = new SachController();
                int t = s.Add(entity);
                if (t > 0)
                    HienThiSach();
            }
            if (Them_bool == false && Sua_bool == true)
            {
                sach entity = new sach();
                entity.masach = Convert.ToInt32(txtMaSach.Text);
                entity.tensach = txtTenSach.Text;
                entity.tentacgia = txtTacGia.Text;
                entity.manxb = Convert.ToInt32(cbbNXB.SelectedValue.ToString());
                if (txtNamXB.Text.Length > 0)
                    entity.namxb = Convert.ToInt32(txtNamXB.Text);
                if (txtSoTrang.Text.Length > 0)
                    entity.sotrang = Convert.ToInt32(txtSoTrang.Text);
                if (txtGiaTien.Text.Length > 0)
                    entity.giatien = Convert.ToDecimal(txtGiaTien.Text);
                if (txtSoLuong.Text.Length > 0)
                    entity.soluong = Convert.ToInt32(txtSoLuong.Text);
                entity.ngonngu = txtNgonNgu.Text;
                entity.theloai = txtTheLoai.Text;
                var s = new SachController();
                if (s.Edit(entity))
                    HienThiSach();
                else
                {
                    MessageBox.Show("khong sua duoc!");
                }
            }
            btn_edit(false);
        }

         

         
     }
}
