using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DbSachOnline.Dao;
using DbSachOnline.EF;

namespace LTWeb2017.Areas.Admin.Controllers
{
    public class SachController : Controller
    {
        // GET: Admin/Sach
        public ActionResult Index(string timKiem,int page=1,int pageSize=10)
        {
            var dao = new SachDao();
            ViewBag.StringTim = timKiem;
            var list = dao.ListAllSach(timKiem,page, pageSize);
            return View(list);
        }
        
        public ActionResult Create()
        {
            SetViewBagChuDe();
            SetViewBagNXB();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sach sach)
        {
            SetViewBagChuDe();
            SetViewBagNXB();
            if (ModelState.IsValid)
            {

                var dao = new SachDao();
                bool kt = dao.Insert(sach);
                if (kt)
                {
                    
                    return RedirectToAction("Index", "Sach");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin có đánh dấu * bắt buộc phải nhập");
                }
            }
            return View();
        }
        public void SetViewBagNXB(int? selectedID=null)
        {
            var dao = new NhaXuatBanDao();
            ViewBag.MaNXB =new SelectList(dao.ListNXB(), "MaNXB", "TenNXB", selectedID);
        }
        public void SetViewBagChuDe(int? selectedID = null)
        {
            var dao = new ChuDeDao();
            ViewBag.MaChuDe = new SelectList(dao.ListChuDe(),"MaChuDe","TenChuDe",selectedID);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            
            var sach = new SachDao().FindSachWithId(id);
            SetViewBagChuDe(sach.MaChuDe);
            SetViewBagNXB(sach.MaNXB);
            return View(sach);
        }
        [HttpPost]
        public ActionResult Edit(Sach sach)
        {
            SetViewBagChuDe();
            SetViewBagNXB();
            if (ModelState.IsValid)
            {

                var dao = new SachDao();
                bool kt = dao.Edit(sach);
                if (kt)
                {

                    return RedirectToAction("Index", "Sach");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin có đánh dấu * bắt buộc phải nhập");
                }
            }
            return View();
        }
    }
}