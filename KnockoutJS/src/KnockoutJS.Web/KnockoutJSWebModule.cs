using Autofac;
using KnockoutJS.Web.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web
{
    public class KnockoutJSWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<HomeController>().PropertiesAutowired();//属性注入控制器
        }
    }
}
