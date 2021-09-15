using QuanLyThuVienHVKTQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienHVKTQS.controller
{
    class NhaXuatBanController
    {
        QuanLiThuVienHVKTQSDataContext db = null;
        public NhaXuatBanController()
        {
            db = new QuanLiThuVienHVKTQSDataContext();
        }
        public List<nhaxuatban> Detail()
        {
            var list = db.nhaxuatbans.ToList();
            return list;
        }
        public int Add(nhaxuatban entity)
        {
            try
            {
                db.nhaxuatbans.InsertOnSubmit(entity);
                db.SubmitChanges();
                return entity.manxb;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var obj = db.nhaxuatbans.First(m => m.manxb == id);
                db.nhaxuatbans.DeleteOnSubmit(obj);
                db.SubmitChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
                throw;
            }
            
        }

        public bool Edit(nhaxuatban nxb)
        {
            var obj = db.nhaxuatbans.First(m => m.manxb == nxb.manxb);
            if (obj != null)
            {
                try
                {
                    obj.tennxb = nxb.tennxb;
                    obj.diachi = nxb.diachi;
                    obj.sdt = nxb.sdt;
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
            return true;
        }
    }
}
