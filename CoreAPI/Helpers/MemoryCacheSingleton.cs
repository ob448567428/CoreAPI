using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    /// <summary>
    /// global singleton memory cache instance
    /// </summary>
    public class MemoryCacheSingleton
    {
        private const int MEMORYCACHEEXPIREDSECONDS = 1200;
        private static MemoryCacheSingleton instance = null;
        private static readonly object locker = new object();
        private readonly IMemoryCache _memoryCache;

        private MemoryCacheSingleton()
        {

        }
        private MemoryCacheSingleton(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public static MemoryCacheSingleton GetMemoryCacheInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        var memoryCache = new MemoryCache(Options.Create(new MemoryCacheOptions()));
                        instance = new MemoryCacheSingleton(memoryCache);
                    }
                }
            }
            return instance;
        }
        /// <summary>
        /// set token info into memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RefreshMemoeyCache<T>(T t, object key)
        {
            try
            {
                if (_IsExsit<T>(key))
                {
                    _memoryCache.Remove(key);
                }
                _memoryCache.Set(key, t, DateTimeOffset.Now.AddSeconds(MEMORYCACHEEXPIREDSECONDS));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// is exist token info in memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool _IsExsit<T>(object key)
        {
            var indicator = false;
            try
            {
                if (_memoryCache.Get<T>(key) != null)
                {
                    indicator = true;
                }
            }
            catch
            {
                indicator = false;
            }
            return indicator;
        }

        /// <summary>
        /// get token info from memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetT<T>(string key)
        {
            try
            {
                return _memoryCache.Get<T>(key);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// set token info into memory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(object key)
        {
            try
            {
                _memoryCache.Remove(key);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
