using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace KnockoutJS.Application
{
    public class KnockoutJSApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryAppService>().As<ICategoryAppService>().InstancePerLifetimeScope();
            builder.RegisterType<CartAppService>().As<ICartAppService>().InstancePerLifetimeScope();
            builder.RegisterType<BookAppService>().As<IBookAppService>().InstancePerLifetimeScope();
            builder.RegisterType<CartItemAppService>().As<ICartItemAppService>().InstancePerLifetimeScope();
        }
    }
}
