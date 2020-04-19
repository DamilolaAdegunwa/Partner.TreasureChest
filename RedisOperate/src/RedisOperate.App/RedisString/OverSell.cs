using RedisOperate.RedisTool.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedisOperate.App.RedisString
{
    /// <summary>
    /// 超卖模型
    /// </summary>
    public class OverSell
    {
        private static bool IsGoOn = true;//秒杀活动是否结束

        public static void Run()
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
    }
}
