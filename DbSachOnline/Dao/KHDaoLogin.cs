using DbSachOnline.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSachOnline.Dao
{
    public class KHDaoLogin
    {
        DbSach db = null;
        public KHDaoLogin()
        {
            db = new DbSach();
        }
        public bool Login(string userName, string Password)
        {
            var kt = db.KhachHangs.Count(n => n.TaiKhoan == userName && n.MatKhau == Password);
            if (kt > 0)
                return true;
            else
                return false;
        }
        public bool Insert(KhachHang KH)
        {
            if (KH.HoTen != null && KH.TaiKhoan != null && KH.MatKhau != null)
            {
                KH.status = false;
                db.KhachHangs.Add(KH);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
