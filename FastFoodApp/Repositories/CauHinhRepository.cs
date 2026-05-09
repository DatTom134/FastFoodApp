using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using FastFoodApp.Models;

namespace FastFoodApp.Repositories
{
    public class CauHinhRepository
    {
        private readonly string _filePath;
        private static readonly JsonSerializerOptions _opts = new()
        {
            WriteIndented = true
        };

        public CauHinhRepository()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dir);
            _filePath = Path.Combine(dir, "config.json");
        }

        public CauHinhMomo DocCauHinh()
        {
            if (!File.Exists(_filePath)) return new CauHinhMomo();
            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<CauHinhMomo>(json, _opts) ?? new CauHinhMomo();
            }
            catch { return new CauHinhMomo(); }
        }

        public void LuuCauHinh(CauHinhMomo cauHinh)
        {
            string json = JsonSerializer.Serialize(cauHinh, _opts);
            File.WriteAllText(_filePath, json);
        }
    }
}
