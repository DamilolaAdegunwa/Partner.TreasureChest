using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisOperate.App.RedisZSet
{
    public class RankManager
    {
        private static List<string> UserList = new List<string>()
        {
            "Tenk","花生","Ray","阿莫西林","石昊","ywa"
        };

        public static void Run()
        {
            using (RedisZSetService service = new RedisZSetService())
            {
                service.KeyFlush();//清理全部数据

                Task.Run(() =>
                {
                    while (true)
                    {
                        foreach (var user in UserList)
                        {
                            Thread.Sleep(10);
                            service.SortedSetAdd("陈一发儿", user, new Random().Next(1, 100));//表示在原来刷礼物的基础上增加礼物
                        }
                        Thread.Sleep(20 * 1000);
                    }
                });

                Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(12 * 1000);
                        Console.WriteLine("**********当前排行************");
                        int i = 1;

                        foreach (var item in service.SortedSetRangeByScoreWithScores<string>("陈一发儿"))
                        {
                            Console.WriteLine($"第{i++}名 {item.Key} 分数{item.Value}");
                        }
                    }
                });

                Console.Read();
            }
        }
    }
}
