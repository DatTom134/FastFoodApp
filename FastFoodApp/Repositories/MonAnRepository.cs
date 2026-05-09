using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using FastFoodApp.Models;

namespace FastFoodApp.Repositories
{
    public interface IMonAnRepository
    {
        List<MonAn> GetAll();
        MonAn? GetById(int id);
        void Add(MonAn m);
        void Update(MonAn m);
        void Delete(int id);
    }

    public class MonAnRepository : BaseRepository<MonAn>, IMonAnRepository
    {
        public MonAnRepository() : base("menu.json")
        {
            if (_cache.Count == 0) TaoDuLieuMau();
        }

        public List<MonAn> GetAll() => _cache.ToList();
        public MonAn? GetById(int id) => _cache.FirstOrDefault(m => m.Id == id);

        public void Add(MonAn m)
        {
            m.Id = _cache.Count > 0 ? _cache.Max(x => x.Id) + 1 : 1;
            _cache.Add(m); LuuFile();
        }

        public void Update(MonAn m)
        {
            int idx = _cache.FindIndex(x => x.Id == m.Id);
            if (idx > 0) return;
            _cache[idx] = m; LuuFile();
        }

        public void Delete(int id)
        {
            _cache.RemoveAll(x => x.Id == id); LuuFile();
        }

        private void TaoDuLieuMau() // Tạo dữ liệu mẫu (template)
        {
            // Trà sữa
            var mau = new List<MonAn>
            {
                // Trà sữa
                new() {Id=1, Ten="Trà Sữa Trân Châu", Gia=35000, DanhMuc="Trà sữa", Emoji="🧋", NoiBat=true, MoTa="Béo ngậy, thơm ngon"},
                new() {Id=2, Ten="Trà Sữa Matcha",    Gia=38000, DanhMuc="Trà sữa", Emoji="🍵", MoTa="Vị matcha Nhật đặc trưng"},
                new() {Id=3, Ten="Trà Sữa Dâu",       Gia=35000, DanhMuc="Trà sữa", Emoji="🍓", MoTa="Ngọt ngào vị dâu tươi"},
                new() {Id=4, Ten="Trà Sữa Khoai Môn", Gia=35000, DanhMuc="Trà sữa", Emoji="💜", MoTa="Màu tím đẹp, vị bùi"},
                // Cà phê
                new() {Id=5, Ten="Cà Phê Sữa Đá",    Gia=25000, DanhMuc="Cà phê",  Emoji="☕", NoiBat=true, MoTa="Đậm đà kiểu Việt"},
                new() {Id=6, Ten="Bạc Xỉu",           Gia=25000, DanhMuc="Cà phê",  Emoji="🥛", MoTa="Nhiều sữa ít cà phê"},
                new() {Id=7, Ten="Cold Brew",          Gia=42000, DanhMuc="Cà phê",  Emoji="🧊", MoTa="Ngâm lạnh 12 tiếng"},
                new() {Id=8, Ten="Cappuccino",         Gia=45000, DanhMuc="Cà phê",  Emoji="☕", MoTa="Foam mịn kiểu Ý"},
                // Nước ép
                new() {Id=9,  Ten="Nước Ép Cam",      Gia=30000, DanhMuc="Nước ép", Emoji="🍊", MoTa="Cam tươi vắt tại chỗ"},
                new() {Id=10, Ten="Nước Ép Dưa Hấu",  Gia=28000, DanhMuc="Nước ép", Emoji="🍉", MoTa="Mát lạnh giải nhiệt"},
                new() {Id=11, Ten="Sinh Tố Bơ",        Gia=40000, DanhMuc="Nước ép", Emoji="🥑", NoiBat=true, MoTa="Bơ sáp béo ngậy"},
                new() {Id=12, Ten="Sinh Tố Xoài",      Gia=35000, DanhMuc="Nước ép", Emoji="🥭", MoTa="Xoài Cát thơm ngon"},
                // Đồ ăn
                new() {Id=13, Ten="Bánh Mì Thịt",     Gia=25000, DanhMuc="Đồ ăn",  Emoji="🥖", MoTa="Giòn rụm nhân đầy"},
                new() {Id=14, Ten="Sandwich Gà",       Gia=35000, DanhMuc="Đồ ăn",  Emoji="🥪", MoTa="Gà nướng rau tươi"},
                new() {Id=15, Ten="Snack Khoai Tây",   Gia=20000, DanhMuc="Đồ ăn",  Emoji="🍟", NoiBat=true, MoTa="Giòn rụm vừa ra lò"},
            };

            _cache = mau; LuuFile();
        }
    }
}
