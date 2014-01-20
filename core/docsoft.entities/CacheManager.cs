using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using ServiceStack.Redis;
using System.Web.Caching;
namespace docsoft.entities
{
    public class CacheManager
    {
        public const string RedisAddress = "localhost";
        #region Cache
        public enum Loai
        {
            Db = 1
            , Redis = 2
            , Cache = 3
        }
        public static Cache Cache
        {
            get { return HttpRuntime.Cache; }
        }
        public static void Clear(Loai loai,string key)
        {
            switch (loai)
            {
                case Loai.Redis:
                    using (var client = new RedisClient(CacheManager.RedisAddress))
                    {
                        var redis = client.As<DanhMuc>();
                        var list = redis.Lists[key];
                        list.RemoveAll();
                    }
                    break;
                case Loai.Cache:
                    Cache.Remove(key);
                    break;
            }
        }
        #endregion
    }
}
