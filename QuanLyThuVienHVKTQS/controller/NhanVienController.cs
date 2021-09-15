using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVienHVKTQS.Model;

namespace QuanLyThuVienHVKTQS.controller
{
    class NhanVienController
    {
        QuanLiThuVienHVKTQSDataContext db = null;
        public NhanVienController()
        {
            db = new QuanLiThuVienHVKTQSDataContext();
        }

        public List<nhanvien> Detail()
        {
            var list = db.nhanviens.ToList();
            return list;
        }

        public int Add(nhanvien entity)
        {
            try
            {
                db.nhanviens.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.manv;
            }
            catch(Exception)
            {
                return 0;
                throw;
            }
        }

        public bool edit(nhanvien nv)
        {
            var obj = db.nhanviens.First(m => m.manv == nv.manv);
            if(obj!=null)
            {
                try
                {
                    obj.tennv = nv.tennv;
                    obj.ngaysinh=nv.ngaysinh;
                    obj.gioitinh=nv.gioitinh;
                    obj.sdt=nv.sdt;
                    obj.diachi=nv.diachi;
                    obj.socmtnd=nv.socmtnd;
                    obj.quyenhan = nv.quyenhan;
                    db.SubmitChanges();
                }
                catch(Exception)
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
                var obj = db.nhanviens.First(m => m.manv == id);
                db.nhanviens.DeleteOnSubmit(obj);
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
