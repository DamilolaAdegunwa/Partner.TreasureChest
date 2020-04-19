using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RedisOperate.App.RedisString
{
    /// <summary>
    /// 基本测试
    /// </summary>
    public class RedisStringBasicTest
    {
        public static void Run()
        {
            using (RedisStringService service = new RedisStringService())
            {
                service.KeyFlush();
                service.StringSet("RedisStringService_key1", "RedisStringService_value1");
                Console.WriteLine(service.StringGet("RedisStringService_key1"));
                Console.WriteLine(service.StringGetSet("RedisStringService_key1", "RedisStringService_value2"));
                Console.WriteLine(service.StringGet("RedisStringService_key1"));

                service.StringAppend("RedisStringService_key1", "Append");
                Console.WriteLine(service.StringGet("RedisStringService_key1"));
                service.StringSet("RedisStringService_key1", "RedisStringService_value", new TimeSpan(0, 0, 0, 5));
                Console.WriteLine(service.StringGet("RedisStringService_key1"));
                Thread.Sleep(5000);
                Console.WriteLine(service.StringGet("RedisStringService_key1"));
            }
        }
    }
}
