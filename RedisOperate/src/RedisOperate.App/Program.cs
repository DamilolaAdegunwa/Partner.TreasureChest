using RedisOperate.RedisTool.Interface;
using System;
using System.Threading.Tasks;

namespace RedisOperate.App
{
    class Program
    {
        private static bool IsGoOn = true;//秒杀活动是否结束

        static void Main(string[] args)
        {
            {
                //using (RedisStringService service = new RedisStringService())
                //{
                //    service.KeyFlush();
                //    service.StringSet("RedisStringService_key1", "RedisStringService_value1");
                //    Console.WriteLine(service.StringGet("RedisStringService_key1"));
                //    Console.WriteLine(service.StringGetSet("RedisStringService_key1", "RedisStringService_value2"));
                //    Console.WriteLine(service.StringGet("RedisStringService_key1"));

                //    service.StringAppend("RedisStringService_key1", "Append");
                //    Console.WriteLine(service.StringGet("RedisStringService_key1"));
                //    service.StringSet("RedisStringService_key1", "RedisStringService_value", new TimeSpan(0, 0, 0, 5));
                //    Console.WriteLine(service.StringGet("RedisStringService_key1"));
                //    Thread.Sleep(5000);
                //    Console.WriteLine(service.StringGet("RedisStringService_key1"));
                //}
            }
            {
                RedisBase.StringService.StringSet("Stock", 10);

                for (int i = 0; i < 5000; i++)
                {
                    int k = i;
                    Task.Run(() =>//每个线程就是一个用户请求
                    {
                        if (IsGoOn)
                        {
                            var index = RedisBase.StringService.StringDecrement("Stock");//-1并且返回  
                            if (index >= 0)
                            {
                                Console.WriteLine($"{k.ToString("000")} Success，Product Index:{index}");
                                //可以分队列，去数据库操作
                            }
                            else
                            {
                                if (IsGoOn)
                                {
                                    IsGoOn = false;
                                }
                                Console.WriteLine($"{k.ToString("000")} Failed，Product Index:{index}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{k.ToString("000")} Finish......");
                        }
                    });
                }
            }

            Console.ReadLine();
        }
    }
}
