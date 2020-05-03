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
    public class Orchestration : Controller
    {
        private readonly IDatabase _database;

        public Orchestration(IDatabase database)
        {
            _database = database;
        }

        [EnableCors("AllowAll")]
        [HttpPost]
        [Route("TestState")]
        public string TestState() {
            RedisOrchestration redisOrchestration = new RedisOrchestration(_database);

            redisOrchestration.SetRedisItem("Time", DateTime.Now.ToString());

            return redisOrchestration.GetRedisItem("Time");
            
        }
    }
}
