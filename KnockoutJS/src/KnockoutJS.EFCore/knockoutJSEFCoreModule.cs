using Autofac;
using KnockoutJS.Core.IRepositories;
using KnockoutJS.EFCore;
using KnockoutJS.EFCore.Repositories;
using koInstance.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace KnockoutJS.EFCore
{
    public class KnockoutJSEFCoreModule : Autofac.Module
    {
        public IConfiguration Configuration { get; }
        private readonly string connectionString = string.Empty;

        public KnockoutJSEFCoreModule(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("Default");
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(KnockoutJSRepositoryBase<>)).As(typeof(IRepositoryBase<>)).InstancePerDependency();//注册仓储泛型
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CartRepository>().As<ICartRepository>().InstancePerLifetimeScope();
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>().InstancePerLifetimeScope();

            //注册 options，供 DbContext 服务初始化使用
            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ShoppingCartContext>();
                KnockoutJSDbContextConfigurer.Configure(optionsBuilder, connectionString);
                return optionsBuilder.Options;
            }).InstancePerLifetimeScope();

            //注册 DbContext
            builder.RegisterType<ShoppingCartContext>().AsSelf().InstancePerLifetimeScope();

            //注入UOW依赖，确保每次请求都是同一个对象
            builder.RegisterType<UnitOfWork<ShoppingCartContext>>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
