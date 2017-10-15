using DbSachOnline.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace DbSachOnline.Dao
{
    public class SachDao
    {
        DbSach db = null;
        public SachDao()
        {
            db = new DbSach();
        }
        public IEnumerable<Sach> ListAllSach(string timKiem,int page,int pageSize)
        {
            IQueryable<Sach> model = db.Saches;
            if (timKiem != null)
            {
                model = model.Where(n => n.TenSach.Contains(timKiem) || n.NhaXuatBan.TenNXB.Contains(timKiem));
            }
            return model.OrderBy(n => n.MaSach).ToPagedList(page, pageSize);
        }
        public bool Insert(Sach sach)
        {
            if (sach.TenSach != null  && sach.GiaBan != null && sach.SoLuongTon>0)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public Sach FindSachWithId(int id)
        {
            return db.Saches.Find(id);
        }
        public bool Edit(Sach sach)
        {
            var EditSach = db.Saches.Find(sach.MaSach);
            EditSach.TenSach = sach.TenSach;
            EditSach.MaNXB = sach.MaNXB;
            EditSach.GiaBan = sach.GiaBan;
            EditSach.SoLuongTon = sach.SoLuongTon;
            EditSach.AnhBia = sach.AnhBia;
            EditSach.ChuDe = sach.ChuDe;
            EditSach.MaChuDe = sach.MaChuDe;
            db.SaveChanges();
            return true;
        }
        //phần hiển thị
        public List<Sach> ListSach()
        {
            return db.Saches.Take(4).ToList();
        }
        public List<Sach> ListSachGiaCao()
        {
            return db.Saches.Where(n=>n.GiaBan>100000).Take(4).ToList();
        }
        public List<Sach> ListSachSale()
        {
            return db.Saches.Where(n => n.Moi == 1).Take(4).ToList();
        }
        public List<Sach> ListOldSach()
        {
            return db.Saches.Where(n => n.Moi == 0).Take(10).ToList();
        }
    }
}
