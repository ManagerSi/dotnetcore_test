using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisConsoleDemo
{
    public class RedisConnectorHelper
    {
        private static Lazy<ConnectionMultiplexer> _redisConnect;
        static RedisConnectorHelper()
        {
            if (_redisConnect == null)
            {
                _redisConnect = new Lazy<ConnectionMultiplexer>(CreateRedisConnect, LazyThreadSafetyMode.PublicationOnly);
            }
        }

        private static ConnectionMultiplexer CreateRedisConnect()
        {

            //StackExchange.redsi 支持 Redis 集群;
            // string connString = "127.0.0.1:6379,127.0.0.1:6380";
            //string connString = "127.0.0.1:6379";
            string connString = "localhost:6379";

            return ConnectionMultiplexer.Connect(connString);
        }

        public static ConnectionMultiplexer GetRedisConnect
        {
            get { return _redisConnect.Value; }
        }

        public static IDatabase GetDatabase(int db=-1, object asyncState=null)
        {
            return _redisConnect.Value.GetDatabase(db, asyncState);
        }



        #region List Operater
        /// 
        ///Inserts a value in the head of the list. If the key does not exist, create and then insert the value
        /// 
        /// 
        /// 
        /// 
        public long ListLeftPush(string redisKey, string redisValue, int db = -1)
        {
            var _db = GetDatabase(db);
            return _db.ListLeftPush(redisKey, redisValue);
        }
        /// 
        ///Inserts a value at the end of the list. If the key does not exist, create and then insert the value
        /// 
        /// 
        /// 
        /// 
        public long ListRightPush(string redisKey, string redisValue, int db = -1)
        {
            var _db = GetDatabase(db);
            return _db.ListRightPush(redisKey, redisValue);
        }

        /// 
        ///Inserts an array collection at the end of the list. If the key does not exist, create and then insert the value
        /// 
        public long ListRightPush(string redisKey, IEnumerable<string> redisValue, int db = -1)
        {
            var _db = GetDatabase(db);
            var redislist = new List<RedisValue>();
            foreach (var item in redisValue)
            {
                redislist.Add(item);
            }
            return _db.ListRightPush(redisKey, redislist.ToArray());
        }


        /// 
        ///Remove and return the first element stored in the key list to deserialize
        /// 
        /// 
        /// 
        public T ListLeftPop<T>(string redisKey, int db = -1) where T : class
        {
            var _db = GetDatabase(db);
            return JsonConvert.DeserializeObject<T>(_db.ListLeftPop(redisKey));
        }

        /// 
        ///Remove and return the last element stored in the key list to deserialize
        ///Can only be an object collection
        /// 
        /// 
        /// 
        public T ListRightPop<T>(string redisKey, int db = -1) where T : class
        {
            var _db = GetDatabase(db);
            return JsonConvert.DeserializeObject<T>(_db.ListRightPop(redisKey));
        }



        #endregion
    }
}
