using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RedisOperate.App.RedisList
{
    /// <summary>
    /// 博客分页数据
    /// </summary>
    public class BlogPageList
    {
        public static void Run()
        {
            using (RedisListService service = new RedisListService())
            {
                service.ListLeftPush("newBlog", "9527");
                service.ListLeftPush("newBlog", "9528");
                service.ListLeftPush("newBlog", "9529");
                service.ListLeftPush("newBlog", "9530");
                service.ListLeftPush("newBlog", "9531");
                service.ListLeftPush("newBlog", "9532");

                //service.TrimList("newBlog", 0, 200);//一个list最多2的32次方-1

                //service.ListGetByIndex("newBlog", 0, 9);
                //service.ListGetByIndex("newBlog", 10, 19);
                //service.ListGetByIndex("newBlog", 20, 29);
            }
        }
    }
}
