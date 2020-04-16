using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace RedisOperate.RedisTool
{
    /// <summary>
    /// 读取appsetting.json
    /// </summary>
    public class AppConfigurataionServices
    {
        public static IConfiguration Configuration { get; set; }
        static AppConfigurataionServices()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build();
        }
    }
}
