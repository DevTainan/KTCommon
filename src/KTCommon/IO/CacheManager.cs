using KTCommon.Interfaces;
using System;
using System.IO;
using System.Runtime.Caching;

namespace KTCommon.IO
{
    public class CacheManager : ICacheManager
    {
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly string _dirPath;
        private bool IsSaveFileEnabled { get { return !string.IsNullOrEmpty(_dirPath); } }
        private Func<object, string> _serializer;
        private Func<string, Type, object> _deserializer;

        public CacheManager() : this(string.Empty, null, null) { }
        public CacheManager(string dirPath, Func<object, string> serializer, Func<string, Type, object> deserializer)
        {
            _dirPath = dirPath;
            _serializer = serializer;
            _deserializer = deserializer;
        }

        // 寫入檔案備份, 再寫入快取
        public void Set(string key, object value) { Set(key, value, DateTimeOffset.Now.AddSeconds(10)); }
        public void Set(string key, object value, DateTimeOffset offset)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = offset;

            if (IsSaveFileEnabled)
            {
                string filePath = Path.Combine(_dirPath, $"{key}.txt");
                Directory.CreateDirectory(_dirPath);
                File.WriteAllText(filePath, ConvertToText(value));
                policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePath.Split('\n')));
            }

            _cache.Set(key, value, policy);
        }

        // 讀取快取, 若沒有資料, 再讀取檔案
        public object Get(string key)
        {
            object obj = _cache.Get(key);

            if (obj == null && IsSaveFileEnabled)
            {
                string filePath = Path.Combine(_dirPath, $"{key}.txt");
                if (File.Exists(filePath))
                {
                    string text = File.ReadAllText(filePath);
                    obj = ConvertToObj(text);
                }
            }

            return obj;
        }

        private string ConvertToText(object value)
        {
            var cacheData = new CacheData(DateTime.Now, _serializer(value));
            return _serializer(cacheData);
        }

        private object ConvertToObj(string text)
        {
            var cacheData = (CacheData)_deserializer(text, typeof(CacheData));
            return _deserializer(cacheData.Content, typeof(object));
        }

        internal struct CacheData
        {
            public DateTime Timetag { get; private set; }
            public string Content { get; private set; }

            public CacheData(DateTime timetag, string content)
            {
                Timetag = timetag;
                Content = content;
            }
        }
    }
}
