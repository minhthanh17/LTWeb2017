using DbSachOnline.Dao;
using DbSachOnline.EF;
using LTWeb2017.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb2017.Controllers
{
    public class LoginKHController : Controller
    {
        // GET: LoginKH
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(DBKhachHang KH)
        {
            if (ModelState.IsValid)
            {
                var dao = new KHDaoLogin();
                bool kt = dao.Login(KH.TaiKhoan, KH.MatKhau);
                if (kt)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            return View("Index");
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(KhachHang Kh)
        {
            if (ModelState.IsValid)
            {
                var dao = new KHDaoLogin();
                bool kt = dao.Insert(Kh);
                if(kt)
                {
                    return RedirectToAction("Index", "LoginKH");
                }
                else
                {
                    ModelState.AddModelError("", "Có đánh dấu * là thông tin bắt buộc");
                }
            }
            return View();
        }
    }
}