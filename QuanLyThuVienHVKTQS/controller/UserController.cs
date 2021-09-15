using QuanLyThuVienHVKTQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienHVKTQS.controller
{
    class UserController
    {
        QuanLiThuVienHVKTQSDataContext db = null;
        public UserController()
        {
            db = new QuanLiThuVienHVKTQSDataContext();
        }
        public List<User>Detail()
        {
            var list=db.Users.ToList();
            return list;
        }
        public int IsAdmin (User user)
        {
            var s = db.Users.First(m => m.UserName == user.UserName && m.Password == user.Password);
            if(s!=null)
            {
                if (s.IsAdmin == true) return 1;
                else return 0;
            } 
            else
            {
                return -1;
            }
        }

        public int Add(User user)
        {
            try
            {
                var result = db.Users.First(m => m.UserName == user.UserName);
                if (result == null)
                {
                    db.Users.InsertOnSubmit(user);
                    db.SubmitChanges();
                    return user.ID;
                }
                else return -1;
            }
            catch(Exception)
            {
                return 0;
            }
        }
        public bool Edit(User user)
        {
            var obj = db.Users.First(m => m.ID == user.ID);
            if(obj!=null)
            {
                try
                {
                    obj.UserName = user.UserName;
                    obj.Password = user.Password;
                    obj.IsAdmin = user.IsAdmin;

                    db.SubmitChanges();
                    return true;
                }
                catch(Exception)
                { return false;
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
                var obj = db.Users.First(m => m.ID == id);
                db.Users.DeleteOnSubmit(obj);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
