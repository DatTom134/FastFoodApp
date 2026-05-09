using System;
using System.Collections.Generic;
using System.Text;
using FastFoodApp.Models;
using FastFoodApp.Repositories;
using FastFoodApp.Helpers;
using System.Security.Cryptography.Xml;

namespace FastFoodApp.Services
{
    public class AuthServices
    {
        private readonly INguoiDungRepository _repo;
        public NguoiDung? NguoiDungHienTai { get; private set; } // Session
        public AuthServices(INguoiDungRepository repo) => _repo = repo;

        public (bool Ok, string ThongBao, NguoiDung? User) DangNhap(string ten, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(matKhau))
                return (false, "Vui lòng nhập đầy đủ thông tin", null);

            var user = _repo.GetByTenDangNhap(ten.Trim());
            if (user == null) return (false, "Tên đăng nhập không tồn tại", null);

            if (!PasswordHelpers.KiemTra(matKhau, user.MatKhauHash))
                return (false, "Mật khẩu không đúng", null);

            NguoiDungHienTai = user;
            return (true, $"Chào mừng, {user.HoTen}! 👋", user);
        }

        public (bool Ok, string ThongBao) DangKy(string ten, string hoTen, string matKhau, string xacNhan)
        {
            ten = ten.Trim();
            hoTen = hoTen.Trim();

            if (string.IsNullOrWhiteSpace(ten)) return (false, "Tên đăng nhập không được trống!");
            if (string.IsNullOrWhiteSpace(hoTen)) return (false, "Họ tên không được trống!");
            if (matKhau.Length < 6) return (false, "Mật khẩu tối thiếu 6 ký tự");
            if (matKhau != xacNhan) return (false, "Mật khẩu xác thực không khớp!");

            if (_repo.GetByTenDangNhap(ten) != null)
                return (false, $"Tên đăng nhập \"{ten}\" đã tồn tại");

            _repo.Add(new NguoiDung
            {
                TenDangNhap = ten,
                HoTen = hoTen,
                MatKhauHash = PasswordHelpers.Hash(matKhau),
                VaiTro = VaiTro.User
            });
            return (true, "Đăng ký thành công! Hãy đăng nhập.");
        }

        public void DangXuat() => NguoiDungHienTai = null;
    }
}
