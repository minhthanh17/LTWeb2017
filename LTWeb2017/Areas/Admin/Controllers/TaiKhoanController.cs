using DbSachOnline.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DbSachOnline.EF;

namespace LTWeb2017.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index(string timKiem,int page = 1, int pageSize = 4)
        {
            var dao = new KhachHangDao();
            ViewBag.StringTim = timKiem;
            var list = dao.ListAllKH(timKiem,page, pageSize);
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KhachHang KH)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                bool kt = dao.Insert(KH);
                if (kt)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin có đánh dấu * bắt buộc phải nhập");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var KH = new KhachHangDao().FindKhWithID(id);
            return View(KH);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang KH)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                bool kt = dao.Update(KH);
                if (kt)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Thay đổi thất bại");
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                var KH = dao.FindKhWithID(id);
                bool kt = dao.Delete(KH);
                if (kt)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Xóa thất bại");
                }
            }
            return View();
        }
    }
}