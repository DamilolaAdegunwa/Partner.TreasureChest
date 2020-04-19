using RedisOperate.RedisTool.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisOperate.App.RedisHash
{
    /// <summary>
    /// 用户信息Hash测试
    /// </summary>
    public class UserInfoTest
    {
        public static void Run()
        {
            #region 简单方式
            var userInfo = new UserInfo()
            {
                Id = 123,
                Account = "Administrator",
                Address = "武汉市",
                Email = "57265177@qq.com",
                Name = "Eleven",
                Password = "123456",
                QQ = 57265177
            };

            using (RedisStringService service = new RedisStringService())
            {
                //初始设置
                service.StringSet($"userinfo_{userInfo.Id}", userInfo);

                //需要更改属性值
                var userCache = service.StringGet<UserInfo>($"userinfo_{userInfo.Id}");
                userCache.Account = "Admin";

                //重新回存
                service.StringSet($"userinfo_{userInfo.Id}", userCache);
            }
            #endregion

            #region Hash做法
            var userInfo1 = new UserInfo()
            {
                Id = 123,
                Account = "Administrator",
                Address = "武汉市",
                Email = "57265177@qq.com",
                Name = "Eleven",
                Password = "123456",
                QQ = 57265177
            };

            using (RedisHashService service = new RedisHashService())
            {
                service.KeyFlush();

                #region 拆分属性存储
                //初始化
                service.HashSet($"userinfo_{userInfo1.Id}", "Account", userInfo1.Account);
                service.HashSet($"userinfo_{userInfo1.Id}", "Name", userInfo1.Name);
                service.HashSet($"userinfo_{userInfo1.Id}", "Address", userInfo1.Address);
                service.HashSet($"userinfo_{userInfo1.Id}", "Email", userInfo1.Email);
                service.HashSet($"userinfo_{userInfo1.Id}", "Password", userInfo1.Password);

                //对某些属性进行更改
                service.HashSet($"userinfo_{userInfo1.Id}", "Account", "Admin");
                service.HashSet($"userinfo_{userInfo1.Id}", "Name", "SAssassin");
                #endregion

                #region 整体存储
                service.HashSet($"userinfo_{userInfo1.Id}", "userInfo", userInfo1);
                var existUserInfo = service.HashGet<UserInfo>($"userinfo_{userInfo1.Id}", "userInfo");
                #endregion
            }

            using (RedisHashService service = new RedisHashService())
            {

            }
            #endregion
        }
    }

    /// <summary>
    /// 用户信息实体
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long QQ { get; set; }
    }
}
