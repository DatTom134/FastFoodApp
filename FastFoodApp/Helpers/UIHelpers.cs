using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Threading.Channels;
using System.Security.Policy;

namespace FastFoodApp.Helpers
{
    // các phương thức vẽ UI đẹp
    public static class UIHelpers
    {
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            // GraphicsPath = đường dẫn vẽ hình phức tạp
            int diameter = radius * 2;
            var path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            // AddArc(x,y,w,h,startAngle,sweepAngle) -> vẽ cung tròn tại góc
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure(); // nối điểm cuối với điểm đầu -> đóng hình
            return path;
        }

        // tô màu gradient lên panel
        public static void VeGradient(Graphics g, Rectangle rect, Color mauTren, Color mauDuoi)
        {
            using var brush = new LinearGradientBrush(rect, mauTren, mauDuoi,
                LinearGradientMode.Vertical);
            // LinearGradientBrush -> cọ tô màu chuyển dần từ mauTren -> mauDuoi
            // LinearGradientMode.Vertical -> chuyển theo chiều dọc (trên->dưới)
            g.FillRectangle(brush, rect);
        }

        // Tạo theme của app
        public static class Colors
        {
            public static Color Primary = Color.FromArgb(255, 107, 53);  // #FF6B35 cam
            public static Color PrimaryDark = Color.FromArgb(220, 80, 30); // Cam đậm
            public static Color Secondary = Color.FromArgb(30, 30, 46);   // #1E1E2E tối
            public static Color Surface = Color.FromArgb(242, 242, 247); // Xám nhạt
            public static Color White = Color.White;
            public static Color TextDark = Color.FromArgb(30, 30, 30);
            public static Color TextGray = Color.FromArgb(120, 120, 140);
            public static Color MoMo = Color.FromArgb(165, 0, 203);  // Tím MoMo
            public static Color Success = Color.FromArgb(34, 197, 94);
            public static Color Danger = Color.FromArgb(239, 68, 68);
        }
    }
}
