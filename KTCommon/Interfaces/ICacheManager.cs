namespace KTCommon.Interfaces
{
    public interface ICacheManager
    {
        void Set(string key, object value);
        T Get<T>(string key);
    }
}
