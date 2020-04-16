﻿using RedisOperate.RedisTool.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedisOperate.RedisTool
{
    class Program
    {
        static void Main(string[] args)
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

            Console.ReadLine();
        }
    }
}
