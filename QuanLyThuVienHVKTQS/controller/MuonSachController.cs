using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVienHVKTQS.Model;

namespace QuanLyThuVienHVKTQS.controller
{
    class MuonSachController
    {
        QuanLiThuVienHVKTQSDataContext db = null;
        public MuonSachController()
        {
            db = new QuanLiThuVienHVKTQSDataContext();
        }

        public List<MuonSach> Detail()
        {
            var list = db.MuonSaches.ToList();
            return list;
        }

        public int Add(MuonSach ms)
        {
            try
            {
                db.MuonSaches.InsertOnSubmit(ms);
                db.SubmitChanges();
                return ms.Mamuon;
            }
            catch(Exception)
            {
                return 0;
                throw;
            }
        }
        public bool Edit(MuonSach ms)
        {
            var obj = db.MuonSaches.First(m => m.Mamuon == ms.Mamuon);
            if(obj!=null)
            {
                try
                {
                    obj.sothe = ms.sothe;
                    obj.masach = ms.masach;
                    obj.soluong = ms.soluong;
                    obj.ngaymuon = ms.ngaymuon;
                    obj.hantra = ms.hantra;
                    obj.manv = ms.manv;

                    db.SubmitChanges();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var obj = db.MuonSaches.First(m => m.Mamuon == id);
                db.MuonSaches.DeleteOnSubmit(obj);
                db.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
                throw;
            }
        }
    }
}
