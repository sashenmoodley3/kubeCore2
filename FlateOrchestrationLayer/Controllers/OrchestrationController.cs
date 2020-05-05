using FlateOrchestrationLayer.Config;
using FlateOrchestrationLayer.Workers.RedisWorker;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlateOrchestrationLayer.Controllers
{
    [Route("api/[controller]")]
    public class OrchestrationController : Controller
    {
       
        [EnableCors("AllowAll")]
        [HttpPost]
        [Route("TestState")]
        public string TestState() {
            try
            {
                var configString = $"{APISettings.REDIS_HOST}:{APISettings.REDIS_PORT},connectRetry=5";
                IConnectionMultiplexer redis = ConnectionMultiplexer.Connect(configString);
                //services.AddScoped(s => redis.GetDatabase());

                RedisOrchestration redisOrchestration = new RedisOrchestration(redis.GetDatabase());

                redisOrchestration.SetRedisItem("Time", DateTime.Now.ToString());

                return redisOrchestration.GetRedisItem("Time");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
