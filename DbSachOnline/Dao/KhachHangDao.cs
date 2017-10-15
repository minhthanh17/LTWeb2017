using DbSachOnline.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace DbSachOnline.Dao
{
    public class KhachHangDao
    {
        DbSach db = null;
        public KhachHangDao()
        {
            db = new DbSach();
        }
        public int Login(string userName,string Password)
        {
            var kt = db.KhachHangs.Count(n => n.TaiKhoan == userName && n.MatKhau == Password);
            if (kt > 0)
            {
                if (db.KhachHangs.Count(n => n.status == true) > 0)
                    return 1;
                else
                    return 2;
            }               
            else
                return 0;
        }
        public IEnumerable<KhachHang> ListAllKH(string timKiem,int page,int pageSize)
        {
            IQueryable<KhachHang> model = db.KhachHangs;
            if (timKiem!=null)
            {
                model = model.Where(n => n.HoTen.Contains(timKiem) || n.TaiKhoan.Contains(timKiem));
            }
            return model.OrderByDescending(n => n.MaKH).ToPagedList(page, pageSize);
        }
        public bool Insert(KhachHang KH)
        {
            if(KH.HoTen !=null && KH.TaiKhoan!=null && KH.MatKhau != null) { 
            db.KhachHangs.Add(KH);
            db.SaveChanges();
            return true;
            }
            return false;
        }
        public KhachHang FindKhWithID(int id)
        {
            return db.KhachHangs.Find(id);
        } 
        public bool Update(KhachHang KH)
        {
            int id = KH.MaKH;
            var NewKH = db.KhachHangs.Find(id);
            NewKH.HoTen = KH.HoTen;
            NewKH.MatKhau = KH.MatKhau;
            NewKH.NgaySinh = KH.NgaySinh;
            NewKH.DiaChi = KH.DiaChi;
            db.SaveChanges();
            return true;
        }
        public bool Delete(KhachHang KH)
        {
            db.KhachHangs.Remove(KH);
            db.SaveChanges();
            return true;
        }
    }
}
