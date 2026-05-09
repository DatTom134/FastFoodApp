using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace FastFoodApp.Helpers
{
    public static class PasswordHelpers
    {
        public static string Hash(string matKhau)
        {
            using var sha256 = SHA256.Create();
            // SHA256.Create() -> tạo instance SHA256 hasher

            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(matKhau));
            // ComputeHash -> nhận mảng byte -> trả về mảng byte 32 phân tử (256 bit)

            return Convert.ToHexString(bytes).ToLower();
            // Convert.ToHexString -> chuyển byte[] thành chuỗi hex
            // "abc" -> "ba7816bf8f01cfea414140de5dae2ec73b00361bbef0469f490fea0ce374d95"
        }

        public static bool KiemTra(string matKhauNhap, string hashLuu)
            => Hash(matKhauNhap) == hashLuu;
        // So sánh hash của mật khẩu nhập với hash đã lưu
    }
}
