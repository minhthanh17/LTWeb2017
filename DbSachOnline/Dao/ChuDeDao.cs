using DbSachOnline.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbSachOnline.Dao
{
    public class ChuDeDao
    {
        DbSach db = null;
        public ChuDeDao()
        {
            db = new DbSach();
        }
        public List<ChuDe> ListChuDe()
        {
            return db.ChuDes.ToList();
        }
    }
}
