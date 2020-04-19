using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;

namespace RedisOperate.RedisTool.Init
{
    /// <summary>
    /// Redis管理中心
    /// </summary>
    public class RedisManager
    {
        private static readonly object Locker = new object();
        private static ConnectionMultiplexer _instance;
        /// <summary>
        /// Redis保存的Key前缀，会自动添加到指定的Key名称前
        /// </summary>
        internal static readonly string RedisSysCustomKey = AppConfigurataionServices.Configuration["RedisConfig:RedisSysCustomKey"];
        /// <summary>
        /// 当前连接的Redis中的DataBase索引，默认0-16，可以在service.conf配置，最高64
        /// </summary>
        internal static readonly int RedisDataBaseIndex = int.Parse(AppConfigurataionServices.Configuration["RedisConfig:RedisDataBaseIndex"]);
        /// <summary>
        /// 当前连接的Redis中连接字符串，格式为：127.0.0.1:6379,allowadmin=true,passowrd=pwd
        /// </summary>
        internal static readonly string RedisHostConnection = AppConfigurataionServices.Configuration["RedisConfig:RedisHostConnection"];

        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionCache = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        /// <summary>
        /// 单例获取
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null || !_instance.IsConnected)
                        {
                            _instance = GetConnectionMultiplexer();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 缓存获取
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static ConnectionMultiplexer GetConnectionMultiplexer(string connectionString = null)
        {
            connectionString = connectionString ?? RedisHostConnection;

            if (!ConnectionCache.ContainsKey(connectionString))
            {
                ConnectionCache[connectionString] = GetManager(connectionString);
            }

            return ConnectionCache[connectionString];
        }

        /// <summary>
        /// 内部方法，获取Redis连接
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static ConnectionMultiplexer GetManager(string connectionString)
        {
            var connect = ConnectionMultiplexer.Connect(connectionString);

            //注册如下事件
            connect.ConnectionFailed += MuxerConnectionFailed;
            connect.ConnectionRestored += MuxerConnectionRestored;
            connect.ErrorMessage += MuxerErrorMessage;
            connect.ConfigurationChanged += MuxerConfigurationChanged;
            connect.HashSlotMoved += MuxerHashSlotMoved;
            connect.InternalError += MuxerInternalError;

            return connect;
        }

        #region 事件
        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged(object sender, EndPointEventArgs e)
        {
            Console.WriteLine($"Configuration changed: {e.EndPoint}");
        }

        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            Console.WriteLine($"ErrorMessage: {e.Message}");
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine($"ConnectionRestored: {e.EndPoint}");
        }

        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine($"Reconnection：Endpoint failed: {e.EndPoint},  {e.FailureType} , {(e.Exception == null ? "" : e.Exception.Message)}");
        }

        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            Console.WriteLine($"HashSlotMoved:NewEndPoint{e.NewEndPoint}, OldEndPoint{e.OldEndPoint}");
        }

        /// <summary>
        /// redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            Console.WriteLine($"InternalError:Message{ e.Exception.Message}");
        }
        #endregion
    }
}
