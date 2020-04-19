using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOperate.App.RedisList
{
    /// <summary>
    /// 生产者消费者模型
    /// </summary>
    public class ProducerConsumerModel
    {
        public static void Run()
        {
            using (RedisListService service = new RedisListService())
            {
                service.ListLeftPush("test", "这是一个学生Add1");
                service.ListLeftPush("test", "这是一个学生Add2");
                service.ListLeftPush("test", "这是一个学生Add3");

                service.ListLeftPush("test", "这是一个学生LPush1");
                service.ListLeftPush("test", "这是一个学生LPush2");
                service.ListLeftPush("test", "这是一个学生LPush3");
                service.ListLeftPush("test", "这是一个学生LPush4");
                service.ListLeftPush("test", "这是一个学生LPush5");
                service.ListLeftPush("test", "这是一个学生LPush6");

                service.ListRightPush("test", "这是一个学生RPush1");
                service.ListRightPush("test", "这是一个学生RPush2");
                service.ListRightPush("test", "这是一个学生RPush3");
                service.ListRightPush("test", "这是一个学生RPush4");
                service.ListRightPush("test", "这是一个学生RPush5");
                service.ListRightPush("test", "这是一个学生RPush6");

                List<string> stringList = new List<string>();
                for (int i = 0; i < 10; i++)
                {
                    stringList.Add(string.Format($"放入任务{i}"));
                }
                service.ListLeftPush("task", stringList);

                Console.WriteLine(service.ListLength("test"));
                Console.WriteLine(service.ListLength("task"));
                var list = service.ListRange<string>("test");
                var indexValue = service.ListGetByIndex<string>("task", 2);

                Action act = new Action(() =>
                {
                    while (true)
                    {
                        Console.WriteLine("************请输入数据**************");
                        string testTask = Console.ReadLine();
                        service.ListLeftPush("test", testTask);
                    }
                });
                act.EndInvoke(act.BeginInvoke(null, null));
            }
        }
    }
}
