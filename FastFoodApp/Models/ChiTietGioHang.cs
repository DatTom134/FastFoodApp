using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodApp.Models
{
    public class ChiTietGioHang
    {
        public MonAn MonAn { get; set; } = null;
        public int SoLuong { get; set; } = 1;
        public string GhiChu { get; set; } = ""; // "Ít đường", "Không đá"...

        public decimal ThanhTien => MonAn.Gia * SoLuong;
    }
}
