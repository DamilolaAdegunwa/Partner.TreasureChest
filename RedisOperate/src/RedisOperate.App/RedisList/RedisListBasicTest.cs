using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOperate.App.RedisList
{
    /// <summary>
    /// 基础测试
    /// </summary>
    public class RedisListBasicTest
    {
        public static void Run()
        {
            //using (RedisListService service = new RedisListService())
            //{
            //    service.FlushAll();

            //    //service.Add("article", "eleven1234");
            //    //service.Add("article", "kevin");
            //    //service.Add("article", "大叔");
            //    //service.Add("article", "C卡");
            //    //service.Add("article", "触不到的线");
            //    //service.Add("article", "程序错误");
            //    service.RPush("article", "eleven1234");
            //    service.RPush("article", "kevin");
            //    service.RPush("article", "大叔");
            //    service.RPush("article", "C卡");
            //    service.RPush("article", "触不到的线");
            //    service.RPush("article", "程序错误");

            //    var result1 = service.Get("article");
            //    var result2 = service.Get("article", 0, 3);
            //    //可以按照添加顺序自动排序；而且可以分页获取

            //    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            //    //栈
            //    service.FlushAll();
            //    service.Add("article", "eleven1234");
            //    service.Add("article", "kevin");
            //    service.Add("article", "大叔");
            //    service.Add("article", "C卡");
            //    service.Add("article", "触不到的线");
            //    service.Add("article", "程序错误");

            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine(service.PopItemFromList("article"));
            //        var result3 = service.Get("article");
            //    }
            //    Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            //    // 队列：生产者消费者模型   
            //    service.FlushAll();
            //    service.RPush("article", "eleven1234");
            //    service.RPush("article", "kevin");
            //    service.RPush("article", "大叔");
            //    service.RPush("article", "C卡");
            //    service.RPush("article", "触不到的线");
            //    service.RPush("article", "程序错误");

            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine(service.PopItemFromList("article"));
            //        var result4 = service.Get("article");
            //    }
            //    //分布式缓存，多服务器都可以访问到，多个生产者，多个消费者，任何产品只被消费一次
            //}
        }
    }
}
