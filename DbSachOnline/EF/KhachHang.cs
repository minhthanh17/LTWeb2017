namespace DbSachOnline.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int MaKH { get; set; }

        [StringLength(50)]
        [Display(Name ="Họ tên *")]
        public string HoTen { get; set; }
        [Display(Name = "Ngày sinh")]

        public DateTime? NgaySinh { get; set; }
        [Display(Name = "Giới tính")]

        [StringLength(3)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài khoản *")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu *")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
