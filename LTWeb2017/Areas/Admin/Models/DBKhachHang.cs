using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTWeb2017.Areas.Admin.Models
{
    public class DBKhachHang
    {
        [Required(ErrorMessage ="Nhập tài khoản")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage ="Nhập mật khẩu")]
        public string MatKhau { get; set; }
    }
}