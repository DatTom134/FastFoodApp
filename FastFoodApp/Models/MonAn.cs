using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Text;

namespace FastFoodApp.Models
{
    public class MonAn
    {
        public int Id { get; set; }
        public string Ten { get; set; } = "";
        public string MoTa { get; set; } = "";
        public decimal Gia { get; set; }
        public string DanhMuc { get; set; } = ""; // "Trà sữa","Cà phê","Nước ép"...
        public string Emoji { get; set; } = "🧋"; // Icon hiển thị thay ảnh
        public bool ConHang { get; set; } = true;
        public bool NoiBat { get; set; } = false; // Hiện badge "Hot"

        public override string ToString() => Ten;
    }
}