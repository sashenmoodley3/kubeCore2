using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlateOrchestrationLayer.Config;
using StackExchange.Redis;

namespace FlateOrchestrationLayer.Workers.RedisWorker
{
    public class RedisOrchestration
    {
        private readonly IDatabase _database;

        public RedisOrchestration(IDatabase database)
        {
            _database = database;
        }

        //public void Connect()
        //{
        //    try
        //    {
        //         var configString = $"{APISettings.RedisHost}:{APISettings.RedisPort},connectRetry=5";
        //         _redis = ConnectionMultiplexer.Connect(configString);

        //        IConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
        //    }
        //    catch (RedisConnectionException err)
        //    {
        //        throw err;
        //    }
        //}



        public void SetRedisItem(string key, string value)
        {
            
            var isSuccessful = _database.StringSet(key, value);
            
        }

        public string GetRedisItem(string key)
        {
            
            var item = _database.StringGet(key);

            return item;
        }
    }
}
