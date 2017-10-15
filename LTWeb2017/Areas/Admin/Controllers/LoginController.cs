using DbSachOnline.Dao;
using LTWeb2017.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb2017.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(DBKhachHang KH)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                int kt = dao.Login(KH.TaiKhoan, KH.MatKhau);
                if(kt!=0)
                {
                    if (kt == 1)
                        return RedirectToAction("Index", "Home");
                    else {
                        ModelState.AddModelError("", "bạn không phải là admin"); 
                        return View("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            return View("Index");
        }
    }
}