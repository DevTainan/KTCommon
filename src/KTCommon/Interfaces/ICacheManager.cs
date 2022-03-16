﻿namespace KTCommon.Interfaces
{
    public interface ICacheManager
    {
        void Set(string key, object value);
        object Get(string key);
    }
}
