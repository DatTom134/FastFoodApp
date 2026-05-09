using System;
using System.Collections.Generic;
using System.Text;
using FastFoodApp.Models;

namespace FastFoodApp.Services
{
    public class GioHangService
    {
        // GioHang chỉ tồn tại trong session - không lưu file
        private readonly List<ChiTietGioHang> _items = new();

        public IReadOnlyList<ChiTietGioHang> Items => _items.AsReadOnly();
        public int SoLuong => _items.Sum(i => i.SoLuong);
        public decimal TongTien => _items.Sum(i => i.ThanhTien);
        public bool Rong => _items.Count == 0;

        public void Them(MonAn mon, int soLuong = 1, string ghiChu = "")
        {
            // Nếu đã có món này -> cộng thêm số lượng
            var existing = _items.FirstOrDefault(i => i.MonAn.Id == mon.Id && i.GhiChu == ghiChu);
            if (existing != null)
                existing.SoLuong += soLuong;
            else
                _items.Add(new ChiTietGioHang { MonAn = mon, SoLuong = soLuong, GhiChu = ghiChu });
        }

        public void CapNhatSoLuong(int monId, int soLuongMoi)
        {
            var item = _items.FirstOrDefault(i => i.MonAn.Id == monId);
            if (item == null) return;
            if (soLuongMoi <= 0) _items.Remove(item);
            else item.SoLuong = soLuongMoi;
        }

        public void Xoa(int monId) => _items.RemoveAll(i => i.MonAn.Id == monId);
        public void XoaTatCa() => _items.Clear();

    }
}
