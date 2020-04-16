using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedisOperate.App
{
    /// <summary>
    /// 超卖场景
    /// </summary>
    public class Oversell
    {
        private static bool IsGoOn = true;//秒杀活动是否结束
        public static void Show()
        {
            using (RedisStringService service = new RedisStringService())
            {
                service.StringSet("Stock", 10);//初始库存
            }

            for (int i = 0; i < 5000; i++)
            {
                int k = i;
                Task.Run(() =>//每个线程就是一个用户请求
                {
                    using (RedisStringService service = new RedisStringService())
                    {
                        if (IsGoOn)
                        {
                            long index = service.Decr("Stock");//-1并且返回  
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
                    }
                });
            }
            Console.Read();
        }
    }
}
