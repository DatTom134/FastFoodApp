using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FastFoodApp.Repositories
{
    // Base class dùng chung cho tất cả repository JSON
    public abstract class BaseRepository<T>
    {
        protected readonly string _filePath;
        protected List<T> _cache;

        protected static readonly JsonSerializerOptions _opts = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            // Serialize enum thành string thay vì thành số -> dễ đọc JSON
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };

        protected BaseRepository(string fileName)
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
            // Tạo thư mục Data nếu chưa có - ! là null-forgiving operator
            _cache = DocFile();
        }

        private List<T> DocFile()
        {
            if (!File.Exists(_filePath)) return new List<T>();
            try
            {
                string json = File.ReadAllText(_filePath, System.Text.Encoding.UTF8);
                return JsonSerializer.Deserialize<List<T>>(json, _opts) ?? new List<T>();
            }
            catch { return new List<T>(); }
        }

        protected void LuuFile()
        {
            string json = JsonSerializer.Serialize(_cache, _opts);
            File.WriteAllText(_filePath, json, System.Text.Encoding.UTF8);
        }
    }
}
