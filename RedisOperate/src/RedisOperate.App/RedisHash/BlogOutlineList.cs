using RedisOperate.RedisTool.Interface;
using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisOperate.App.RedisHash
{
    public class BlogOutlineList
    {
        public static void Run()
        {
            var service = RedisBase.HashService;

            #region 博客概要信息列表
            var blogOutlineInfoList = new List<BlogOutlineInfo>()
            {
                new BlogOutlineInfo()
                {
                    Id = "9527",
                    Title = "CSharp",
                    Author = "微笑刺客",
                    CreateTime = DateTime.Now,
                    Content = "CSharp从入门到升仙",
                    CommentCount =0,
                    ReadCount = 0,
                    RecommendCount = 0
                },
                new BlogOutlineInfo()
                {
                    Id = "9528",
                    Title = "Mysql",
                    Author = "微笑刺客",
                    CreateTime = DateTime.Now,
                    Content = "Mysql从入门到遁地",
                    CommentCount =0,
                    ReadCount = 0,
                    RecommendCount = 0
                },
                new BlogOutlineInfo()
                {
                    Id = "9529",
                    Title = "Docker",
                    Author = "微笑刺客",
                    CreateTime = DateTime.Now,
                    Content = "Docker从入门到转行",
                    CommentCount =0,
                    ReadCount = 0,
                    RecommendCount = 0
                },
                new BlogOutlineInfo()
                {
                    Id = "9530",
                    Title = "k8s",
                    Author = "微笑刺客",
                    CreateTime = DateTime.Now,
                    Content = "k8s从入门到失眠",
                    CommentCount =0,
                    ReadCount = 0,
                    RecommendCount = 0
                },
                new BlogOutlineInfo()
                {
                    Id = "9531",
                    Title = ".Net Core",
                    Author = "微笑刺客",
                    CreateTime = DateTime.Now,
                    Content = ".Net Core从入门到精通",
                    CommentCount =0,
                    ReadCount = 0,
                    RecommendCount = 0
                },
                new BlogOutlineInfo()
                {
                    Id = "9532",
                    Title = "vue.js",
                    Author = "微笑刺客",
                    CreateTime = DateTime.Now,
                    Content = "vuejs从入门到进阶",
                    CommentCount =0,
                    ReadCount = 0,
                    RecommendCount = 0
                },
            };
            #endregion

            #region 存储数据到Redis_Hash中
            service.KeyFlush();

            foreach (var blogOutlineInfo in blogOutlineInfoList)
            {
                //设置Redis_key
                var blogOutlineInfoKey = $"blogOutlineInfo_{blogOutlineInfo.Id}";

                //初始化属性值
                service.HashSet(blogOutlineInfoKey, nameof(BlogOutlineInfo.Title), blogOutlineInfo.Title);
                service.HashSet(blogOutlineInfoKey, nameof(BlogOutlineInfo.Content), blogOutlineInfo.Content);
                service.HashSet(blogOutlineInfoKey, nameof(BlogOutlineInfo.Author), blogOutlineInfo.Author);
                service.HashSet(blogOutlineInfoKey, nameof(BlogOutlineInfo.CreateTime), blogOutlineInfo.CreateTime);
                service.HashSet(blogOutlineInfoKey, nameof(BlogOutlineInfo.CommentCount), blogOutlineInfo.CommentCount);
                service.HashSet(blogOutlineInfoKey, nameof(BlogOutlineInfo.ReadCount), blogOutlineInfo.ReadCount);
                service.HashSet(blogOutlineInfoKey, nameof(BlogOutlineInfo.RecommendCount), blogOutlineInfo.RecommendCount);
            }
            #endregion

            #region 增加推荐数量
            service.HashIncrement("blogOutlineInfo_9527", "RecommendCount", 1);
            #endregion

            #region 更改简介内容
            service.HashSet("blogOutlineInfo_9530", "Content", "k8s从入门到失业");
            #endregion

            #region 增加阅读量
            service.HashIncrement("blogOutlineInfo_9528", "ReadCount", 1);
            #endregion

            #region 展示现有概要列表
            var newBlogIdList = new List<string>()
            {
                "9527",
                "9528",
                "9529",
                "9530",
                "9531",
                "9532",
            };

            foreach (var newBlogId in newBlogIdList)
            {
                //设置Redis_key
                var blogOutlineInfoKey = $"blogOutlineInfo_{newBlogId}";

                Console.WriteLine($"Title:" + service.HashGet<string>(blogOutlineInfoKey, nameof(BlogOutlineInfo.Title)));
                Console.WriteLine($"Content:" + service.HashGet<string>(blogOutlineInfoKey, nameof(BlogOutlineInfo.Content)));
                Console.WriteLine($"Author:" + service.HashGet<string>(blogOutlineInfoKey, nameof(BlogOutlineInfo.Author)));
                Console.WriteLine($"CreateTime:" + service.HashGet<DateTime>(blogOutlineInfoKey, nameof(BlogOutlineInfo.CreateTime)));
                Console.WriteLine($"CommentCount:" + service.HashGet<int>(blogOutlineInfoKey, nameof(BlogOutlineInfo.CommentCount)));
                Console.WriteLine($"ReadCount:" + service.HashGet<int>(blogOutlineInfoKey, nameof(BlogOutlineInfo.ReadCount)));
                Console.WriteLine($"RecommendCount:" + service.HashGet<int>(blogOutlineInfoKey, nameof(BlogOutlineInfo.RecommendCount)));
                Console.WriteLine("-----------Next-----------");
            }
            #endregion
        }
    }

    /// <summary>
    /// 博客概要信息
    /// </summary>
    public class BlogOutlineInfo
    {
        /// <summary>
        /// 博客Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容简介
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// 阅读数量
        /// </summary>
        public int ReadCount { get; set; }

        /// <summary>
        /// 推荐数量
        /// </summary>
        public int RecommendCount { get; set; }
    }
}
