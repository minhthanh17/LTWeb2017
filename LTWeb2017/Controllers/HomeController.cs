using DbSachOnline.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb2017.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return PartialView();
        }
        //sách mới
        public ActionResult NewSach()
        {
            var dao = new SachDao();
            var listSach = dao.ListSach();
            return PartialView(listSach);
        }
        //sách độc quyền
        public ActionResult ListSachGiaCao()
        {
            var dao = new SachDao();
            var listSach = dao.ListSachGiaCao();
            return PartialView(listSach);
        }
        //sách giảm giá
        public ActionResult ListSachSale()
        {
            var dao = new SachDao();
            var listSach = dao.ListSachSale();
            return PartialView(listSach);
        }
        //sách cũ
        public ActionResult ListOldSach()
        {
            var dao = new SachDao();
            var listSach = dao.ListOldSach();
            return PartialView(listSach);
        }
        // sách theo chủ đề
        public ActionResult ListBookWithTitle()
        {
            var dao = new ChuDeDao();
            var list = dao.ListChuDe();
            return PartialView(list);
        }
    }
}