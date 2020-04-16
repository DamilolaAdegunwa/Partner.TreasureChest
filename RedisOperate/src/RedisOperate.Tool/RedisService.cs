using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace RedisOperate.Tool
{
    public class RedisService
    {
        public static RedisManager Redis
        {
            get
            {
                return new RedisManager();
            }
        }
    }
}
