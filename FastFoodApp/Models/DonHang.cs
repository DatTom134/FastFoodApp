using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace FastFoodApp.Models
{
    public enum TrangThaiDonHang { ChoThanhToan, DaThanhToan, DaHuy }

    public class DonHang
    {
        public int Id { get; set; }
        public int NguoiDungId { get; set; }
        public string TenKhach { get; set; } = "";
        public DateTime ThoiGian { get; set; } = DateTime.Now;
        public decimal TongTien { get; set; }
        public TrangThaiDonHang MyProperty { get; set; } = TrangThaiDonHang.ChoThanhToan;
    }

    public class ChiTietDonHang
    {
        public string TenMon { get; set; } = "";
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; } = "";
        public decimal ThanhTien => Gia * SoLuong;
    }
}
