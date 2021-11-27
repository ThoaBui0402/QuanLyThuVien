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
    public partial class TTMuonTra : Form
    {
        List<MuonSach> l = null;
        private bool Them_bool = false;
        private bool Sua_bool = false;
        public TTMuonTra()
        {
            InitializeComponent();
            Hienthi_MS();
        }
        public void btn_enable(bool t)
        {
            group_MS.Enabled = t;
            Them_MS.Enabled = !t;
            Sua_MS.Enabled = !t;
            Xoa_MS.Enabled = !t;
            Luu_MS.Enabled = t;
            Boqua_MS.Enabled = t;

            Them_bool = false;
            Sua_bool = false;
        }
        public void Hienthi_MS()
        {
            var ms = new MuonSachController();
            l = ms.Detail().ToList();
            listView_MS.Items.Clear();
            int i = 1;

            var dg = new DocGiaController();
            List<docgia> listdg = dg.Detail().ToList();
            sothecbx.DataSource = listdg;
            sothecbx.DisplayMember = "hoten";
            sothecbx.ValueMember = "sothe";

            var s = new SachController();
            List<sach> Listsach = s.Detail().ToList();
            masachcbx.DataSource = Listsach;
            masachcbx.DisplayMember = "tensach";
            masachcbx.ValueMember = "masach";

            var nv = new NhanVienController();
            List<nhanvien> Listnv = nv.Detail().ToList();
            manvcbx.DataSource = Listnv;
            manvcbx.DisplayMember = "tennv";
            manvcbx.ValueMember = "manv";

            foreach (MuonSach m in l)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "" + i++;
                item.SubItems.Add(m.Mamuon.ToString());
                item.SubItems.Add(m.sothe.ToString());
                item.SubItems.Add(m.masach.ToString());
                item.SubItems.Add(m.soluong.ToString());
                item.SubItems.Add(m.ngaymuon.ToString());
                item.SubItems.Add(m.hantra.ToString());
                item.SubItems.Add(m.manv.ToString());

                listView_MS.Items.Add(item);
            }
            if (PhanQuyen.quyen == 1)
                btn_enable(false);
            else
            {
                group_MS.Enabled = false;
                Them_MS.Enabled = Sua_MS.Enabled = Xoa_MS.Enabled = Luu_MS.Enabled = Boqua_MS.Enabled = false;
                Thoat_MS.Enabled = true;
            }
        }
        private void Them_MS_Click(object sender, EventArgs e)
        {

            btn_enable(true);
            mamuontxt.Text = "";
            sothecbx.Text = "";
            masachcbx.Text = "";
            soluongtxt.Text = "";
            ngaymuon.Text = "";
            hantra.Text = "";
            manvcbx.Text = "";

            Them_bool = true;
        }

        private void listView_MS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView_MS.SelectedItems.Count == 0) return;
                int id = Convert.ToInt32(listView_MS.SelectedItems[0].SubItems[1].Text);
                int index = l.FindIndex(m => m.Mamuon == id);

                mamuontxt.Text = l[index].Mamuon.ToString();
                sothecbx.Text = l[index].docgia.hoten.ToString();
                masachcbx.Text = l[index].sach.tensach.ToString();
                if (l[index].soluong == null) soluongtxt.Text = "0";
                else soluongtxt.Text = l[index].soluong.ToString();

                ngaymuon.Text = l[index].ngaymuon.ToString();
                hantra.Text = l[index].hantra.ToString();
                manvcbx.Text = l[index].nhanvien.tennv.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Fail");
            }
        }

        private void Sua_MS_Click(object sender, EventArgs e)
        {
            btn_enable(true);
            Sua_bool = true;
        }

        private void Xoa_MS_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa", "delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(mamuontxt.Text);
                var entity = new MuonSachController();
                if (entity.Delete(id))
                    Hienthi_MS();
                else
                    MessageBox.Show("Xóa không thành công");
            }
        }

        private void Luu_MS_Click(object sender, EventArgs e)
        {
            if (Them_bool == true && Sua_bool == false)
            {
                var ms = new MuonSachController();
                var entity = new MuonSach();

                entity.Mamuon = Convert.ToInt32(mamuontxt.Text);
                entity.sothe = Convert.ToInt32(sothecbx.SelectedValue.ToString());
                entity.masach = Convert.ToInt32(masachcbx.SelectedValue.ToString());
                entity.soluong = Convert.ToInt32(soluongtxt.Text);
                entity.ngaymuon = ngaymuon.Value;
                entity.hantra = hantra.Value;
                entity.manv = Convert.ToInt32(manvcbx.SelectedValue.ToString());

                if (ms.Add(entity) > 0)
                    Hienthi_MS();
                else
                    MessageBox.Show("Thêm không thành công");
            }
            else if (Them_bool == false && Sua_bool == true)
            {
                var ms = new MuonSachController();
                var entity = new MuonSach();
                entity.Mamuon = Convert.ToInt32(mamuontxt.Text);
                entity.sothe = Convert.ToInt32(sothecbx.SelectedValue.ToString());
                entity.masach = Convert.ToInt32(masachcbx.SelectedValue.ToString());
                entity.soluong = Convert.ToInt32(soluongtxt.Text);
                entity.ngaymuon = ngaymuon.Value;
                entity.hantra = hantra.Value;
                entity.manv = Convert.ToInt32(manvcbx.SelectedValue.ToString());

                if (ms.Edit(entity))
                    Hienthi_MS();
                else
                    MessageBox.Show("Sửa không thành công");

            }
        }

        private void Boqua_MS_Click(object sender, EventArgs e)
        {
            btn_enable(false);
        }

        private void Thoat_MS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void search_MStxt_TextChanged(object sender, EventArgs e)
        {
            int i = 1;
            QuanLiThuVienHVKTQSDataContext db = new QuanLiThuVienHVKTQSDataContext();
            var lst = (from s in db.MuonSaches where (s.Mamuon.ToString().Contains(search_MStxt.Text) || s.sothe.ToString().Contains(search_MStxt.Text) || s.masach.ToString().Contains(search_MStxt.Text)) select s).ToList();
            listView_MS.Items.Clear();
            foreach (MuonSach m in lst)
            {
                ListViewItem item = new ListViewItem();
                item.Text = "" + i++;
                item.SubItems.Add(m.Mamuon.ToString());
                item.SubItems.Add(m.sothe.ToString());
                item.SubItems.Add(m.masach.ToString());
                item.SubItems.Add(m.soluong.ToString());
                item.SubItems.Add(m.ngaymuon.ToString());
                item.SubItems.Add(m.hantra.ToString());
                item.SubItems.Add(m.manv.ToString());

                listView_MS.Items.Add(item);
            }
        }
    }
}
