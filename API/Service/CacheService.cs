using API.interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;
namespace API.Service
{
    public class CacheService : ICacheService
    {
        private IDatabase _db;
        private IServer server;
        public CacheService()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.
                Connect("redis-12946.c93.us-east-1-3.ec2.cloud.redislabs.com:12946," +
                "allowAdmin=true,password=4H5G1kogQSjgyO9wptgkBbhzZ5FuvK8I");
            var db = redis.GetDatabase();
            _db = redis.GetDatabase();
            server = redis.GetServer("redis-12946.c93.us-east-1-3.ec2.cloud.redislabs.com", 12946);
        }
        public T GetData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }
        public bool SetData<T>(string key, T value)
        {
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), TimeSpan.FromMinutes(10));
            return isSet;
        }
        public object RemoveData(string key)
        {
            bool _isKeyExist = _db.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _db.KeyDelete(key);
                
            }
            return false;
        }
        public void Clear()
        {
            server.FlushDatabase();
        }
    }
}
