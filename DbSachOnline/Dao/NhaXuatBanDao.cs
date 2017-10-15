using DbSachOnline.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSachOnline.Dao
{
    public class NhaXuatBanDao
    {
        DbSach db = null;
        public NhaXuatBanDao()
        {
            db = new DbSach();
        }
        public List<NhaXuatBan> ListNXB()
        {
            return db.NhaXuatBans.OrderBy(n => n.MaNXB).ToList();
        }

    }
}
