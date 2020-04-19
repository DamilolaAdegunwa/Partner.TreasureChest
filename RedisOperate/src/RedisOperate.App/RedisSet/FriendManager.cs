using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOperate.App.RedisSet
{
    class FriendManager
    {
        public static void Run()
        {
            //去重：IP统计去重；添加好友申请；投票限制；点赞；
            //交叉并的使用
            using (RedisSetService service = new RedisSetService())
            {
                service.KeyFlush();//清理全部数据
                service.SetAdd("Eleven", "Powell");
                service.SetAdd("Eleven", "Tenk");
                service.SetAdd("Eleven", "spider");
                service.SetAdd("Eleven", "spider");
                service.SetAdd("Eleven", "spider");
                service.SetAdd("Eleven", "aaron");
                service.SetAdd("Eleven", "Linsan");

                service.SetAdd("Powell", "Eleven");
                service.SetAdd("Powell", "Tenk");
                service.SetAdd("Powell", "ywa");
                service.SetAdd("Powell", "Pang");
                service.SetAdd("Powell", "Jeff");

                var result = service.SetCombineIntersect<string>("Eleven", "Powell");
                var result2 = service.SetCombineDifference<string>("Powell", "Eleven");
                var result3 = service.SetCombineDifference<string>("Eleven", "Powell");
                var result4 = service.SetCombineUnion<string>("Eleven", "Powell");
            }

        }
    }
}
