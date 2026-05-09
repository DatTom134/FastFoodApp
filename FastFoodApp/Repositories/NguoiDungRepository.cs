using System;
using System.Collections.Generic;
using System.Text;
using FastFoodApp.Models;

namespace FastFoodApp.Repositories
{
    public interface INguoiDungRepository
    {
        List<NguoiDung> GetAll();
        NguoiDung? GetById(int id);
        NguoiDung? GetByTenDangNhap(string ten);
        void Add(NguoiDung u);
        void Update(NguoiDung u);
    }

    public class NguoiDungRepository : BaseRepository<NguoiDung>, INguoiDungRepository
    {
        public NguoiDungRepository() : base("users.json")
        {
            TaoAdminMacDinh(); // Tự tạo admin nếu chưa có
        }

        public List<NguoiDung> GetAll() => _cache.ToList();
        public NguoiDung? GetById(int id) => _cache.FirstOrDefault(u => u.Id == id);
        public NguoiDung? GetByTenDangNhap(string ten)
            => _cache.FirstOrDefault(u =>
                u.TenDangNhap.Equals(ten, StringComparison.OrdinalIgnoreCase));
        
        public void Add(NguoiDung u)
        {
            u.Id = _cache.Count > 0 ? _cache.Max(x => x.Id) + 1 : 1;
            _cache.Add(u);
            LuuFile();
        }

        public void Update(NguoiDung u)
        {
            int idx = _cache.FindIndex(x => x.Id == u.Id);
            if (idx == -1) return;
            _cache[idx] = u;
            LuuFile();
        }

        // Tạo tài khoản admin mặc định nếu chưa có user nào
        private void TaoAdminMacDinh()
        {
            if (_cache.Any(u => u.VaiTro == VaiTro.Admin)) return;

            _cache.Add(new NguoiDung
            {
                Id = 1,
                TenDangNhap = "admin",
                HoTen = "Quản trị viên",
                MatKhauHash = Helpers.PasswordHelpers.Hash("admin123"),
                VaiTro = VaiTro.Admin,
                NgayTao = DateTime.Now
            });
            LuuFile();
        }
    }
}
