using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisOperate.App.RedisList
{
    /// <summary>
    /// 发布者订阅者模型
    /// </summary>
    public class PublisherSubscriberModel
    {
        public static void Run()
        {
            Task.Run(() =>
            {
                using (RedisListService service = new RedisListService())
                {
                    service.Subscribe("Eleven", (c, message) =>
                    {
                        Console.WriteLine($"注册{1}{c}:{message}，Dosomething else");
                    });//blocking
                }
            });

            Task.Run(() =>
            {
                using (RedisListService service = new RedisListService())
                {
                    service.Subscribe("Eleven", (c, message) =>
                    {
                        Console.WriteLine($"注册{2}{c}:{message}，Dosomething else");
                    });//blocking
                }
            });

            Task.Run(() =>
            {
                using (RedisListService service = new RedisListService())
                {
                    service.Subscribe("Twelve", (c, message) =>
                    {
                        Console.WriteLine($"注册{3}{c}:{message}，Dosomething else");
                    });//blocking
                }
            });

            using (RedisListService service = new RedisListService())
            {
                Thread.Sleep(1000);

                service.Publish("Eleven", "Eleven123");
                service.Publish("Eleven", "Eleven234");
                service.Publish("Eleven", "Eleven345");
                service.Publish("Eleven", "Eleven456");

                service.Publish("Twelve", "Twelve123");
                service.Publish("Twelve", "Twelve234");
                service.Publish("Twelve", "Twelve345");
                service.Publish("Twelve", "Twelve456");
                Console.WriteLine("**********************************************");

                service.Publish("Eleven", "exit");
                service.Publish("Eleven", "123Eleven");
                service.Publish("Eleven", "234Eleven");
                service.Publish("Eleven", "345Eleven");
                service.Publish("Eleven", "456Eleven");

                service.Publish("Twelve", "exit");
                service.Publish("Twelve", "123Twelve");
                service.Publish("Twelve", "234Twelve");
                service.Publish("Twelve", "345Twelve");
                service.Publish("Twelve", "456Twelve");
            }
        }
    }
}
