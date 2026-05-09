using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodApp.Models
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string MatKhauHash { get; set; } = "";
        public VaiTro VaiTro { get; set; } = VaiTro.User;
        public DateTime NgayTao { get; set; } = DateTime.Now;

        public bool LaAdmin => VaiTro == VaiTro.Admin;
    }
}
