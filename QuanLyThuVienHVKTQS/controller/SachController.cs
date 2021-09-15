using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVienHVKTQS.Model;
namespace QuanLyThuVienHVKTQS.controller
{
    class SachController
    {
        QuanLiThuVienHVKTQSDataContext db = null;
        public SachController()
        {
            db = new QuanLiThuVienHVKTQSDataContext();
        }
        public List<sach> Detail()
        {
            var list = db.saches.ToList();
            return list;
        }
        public int Add(sach entity)
        {
            try
            {
                db.saches.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.masach;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        public bool Edit(sach entity)
        {
            var obj = db.saches.First(m => m.masach == entity.masach);
            if (obj != null)
            {
                try
                {
                    obj.tensach = entity.tensach;
                    obj.tentacgia = entity.tentacgia;
                    obj.manxb = entity.manxb;
                    obj.namxb = entity.namxb;
                    obj.sotrang = entity.sotrang;
                    obj.giatien = entity.giatien;
                    obj.soluong = entity.soluong;
                    obj.ngonngu = entity.ngonngu;
                    obj.theloai = entity.theloai;
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
        public bool Del(int masach)
        {
            try
            {
                var result = db.saches.First(m => m.masach == masach);
                db.saches.DeleteOnSubmit(result);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }
    }
}
