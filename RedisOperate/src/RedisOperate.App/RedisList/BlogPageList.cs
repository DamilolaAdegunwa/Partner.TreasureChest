using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RedisOperate.App.RedisList
{
    /// <summary>
    /// 博客展示数据测试
    /// </summary>
    public class BlogPageList
    {
        public static void Run()
        {
            using (RedisListService service = new RedisListService())
            {
                service.ListRightPush("newBlog", "11231_1fsgdfgd");
                service.ListRightPush("newBlog", "41233_3fdfsfdsf");
                service.ListRightPush("newBlog", "12345_4dsdsdsd");
                service.ListRightPush("newBlog", "12354_2dsadsaf");
                service.ListRightPush("newBlog", "12343_3fdsfsdfsdf");
                service.ListRightPush("newBlog", "12323_2fsdfsdfsdfsd");

                //service.TrimList("newBlog", 0, 200);//一个list最多2的32次方-1

                //service.ListGetByIndex("newBlog", 0, 9);
                //service.ListGetByIndex("newBlog", 10, 19);
                //service.ListGetByIndex("newBlog", 20, 29);
            }
        }
    }
}
