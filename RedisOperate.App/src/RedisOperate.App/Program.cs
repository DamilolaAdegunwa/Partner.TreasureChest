using RedisOperate.RedisTool.Service;
using RedisOperate.Tool;
using System;
using System.Threading;

namespace RedisOperate.App
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                for (int i = 0; i < 10; i++)
                {
                    var a = RedisService.Redis.StringSet("redis" + i.ToString(), "redis" + DateTime.Now, TimeSpan.FromSeconds(1000000));
                    Console.WriteLine(a);

                    var b = RedisService.Redis.StringGet("redis" + i.ToString());
                    Console.WriteLine(b);
                }
            }
            {
                var service = RedisService.Redis;
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

            Console.ReadLine();
        }
    }
}
