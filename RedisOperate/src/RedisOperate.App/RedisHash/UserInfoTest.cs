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
            #region 用户数据
            var userInfo = new UserInfo()
            {
                Id = 9527,
                Account = "SAssassin",
                Address = "湖南长沙",
                Email = "530521314@qq.com",
                Name = "微笑刺客"
            };

            //设置Redis_key
            var userInfoKey = $"userinfo_{userInfo.Id}";
            #endregion

            #region String用法
            using (RedisStringService service = new RedisStringService())
            {
                service.KeyFlush();

                //整个用户信息序列化并存储
                service.StringSet(userInfoKey, userInfo);

                //依据key读取已有值并反序列化，得到用户信息
                var userInfoCache = service.StringGet<UserInfo>(userInfoKey);

                //更改用户信息中的属性值
                userInfoCache.Account = "Admin";

                //重新回存并序列化用户信息，覆盖之前值
                service.StringSet(userInfoKey, userInfoCache);
            }
            #endregion

            #region Hash用法
            using (RedisHashService service = new RedisHashService())
            {
                service.KeyFlush();

                #region 用法一：拆分属性存储
                //初始化属性值
                service.HashSet(userInfoKey, "Account", userInfo.Account);
                service.HashSet(userInfoKey, "Name", userInfo.Name);
                service.HashSet(userInfoKey, "Address", userInfo.Address);
                service.HashSet(userInfoKey, "Email", userInfo.Email);

                //更改某些属性值
                service.HashSet(userInfoKey, "Account", "Admin");
                service.HashSet(userInfoKey, "Name", "微笑d刺客");
                #endregion

                #region 用法二：整体存储
                service.KeyFlush();

                //整个用户信息序列化并存储为一对field-value，类似于string用法
                service.HashSet(userInfoKey, "userInfo", userInfo);

                //依据key及field读取已有值并反序列化，得到用户信息
                var userInfoCache = service.HashGet<UserInfo>(userInfoKey, "userInfo");

                //更改用户信息中的属性值
                userInfoCache.Account = "Admin";

                //重新回存并序列化用户信息，覆盖之前值
                service.HashSet(userInfoKey, "userInfo", userInfoCache);
                #endregion
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
        
        public string Email { get; set; }
        
        public string Address { get; set; }
    }
}
