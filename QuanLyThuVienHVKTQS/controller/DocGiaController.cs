using QuanLyThuVienHVKTQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienHVKTQS.controller
{
    class DocGiaController
    {
        QuanLiThuVienHVKTQSDataContext db = null;
        QuanLiThuVienHVKTQSDataContext db1 = null;
        public DocGiaController()
        {
            db = new QuanLiThuVienHVKTQSDataContext();
            db1 = new QuanLiThuVienHVKTQSDataContext();
        }

        public List<docgia> Detail()
        {
            var list = db.docgias.ToList();
            return list;
        }

        public int Add(docgia dg)
        {
            try
            {
                db.docgias.InsertOnSubmit(dg);
                db.SubmitChanges();
                return dg.sothe;
            }
            catch(Exception)
            {
                return 0;
                throw;
            }
        }

        public bool Edit(docgia dg)
        {
            var obj = db.docgias.First(m => m.sothe == dg.sothe );
            if(obj!=null)
            {
                try
                {
                    obj.hoten = dg.hoten;
                    obj.ngaysinh = dg.ngaysinh;
                    obj.gioitinh = dg.gioitinh;
                    obj.email = dg.email;
                    obj.diachi = dg.diachi;
                    obj.socmtnd = dg.socmtnd;
                    obj.ngaylamthe = dg.ngaylamthe;
                    obj.handungthe = dg.handungthe;
                    db.SubmitChanges();
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
            return true;
        }


        public bool delete(int id)
        {
            try
            {
                var obj = db.docgias.First(m => m.sothe == id);
                db.docgias.DeleteOnSubmit(obj);
                db.SubmitChanges();
            }
            catch(Exception)
            {
                return false;
                throw;
            }
            return true;
        }
    }
}
