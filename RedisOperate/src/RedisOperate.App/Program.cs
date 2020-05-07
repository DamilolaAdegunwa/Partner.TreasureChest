using RedisOperate.App.RedisHash;
using RedisOperate.App.RedisList;
using RedisOperate.App.RedisSet;
using RedisOperate.App.RedisString;
using RedisOperate.App.RedisZSet;
using System;

namespace RedisOperate.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //更改appsettings.json中的连接字符串

            #region RedisString
            //RedisStringBasicTest.Run();
            //OverSell.Run();
            #endregion

            #region RedisHash
            //UserInfoTest.Run();
            BlogOutlineList.Run();
            #endregion

            #region RedisSet
            //FriendManager.Run();
            #endregion

            #region RedisZSet
            //RankManager.Run();
            #endregion

            #region RedisList
            //RedisListBasicTest.Run();
            //BlogPageList.Run();
            //ProducerConsumerModel.Run();
            //PublisherSubscriberModel.Run();
            #endregion

            Console.ReadLine();
        }
    }
}
