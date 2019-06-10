using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LogPanel.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //方式一：配置Seq服务器的地址(5341端口为默认地址)
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .MinimumLevel.Override("LoggingService", Serilog.Events.LogEventLevel.Debug)
            //    .Enrich.FromLogContext()
            //    .WriteTo.Seq("http://localhost:5341")
            //    .WriteTo.LiterateConsole()
            //    .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //方式二
            //var serilog = new LoggerConfiguration()
            //        .MinimumLevel.Information()
            //        .MinimumLevel.Override("LoggingService", Serilog.Events.LogEventLevel.Debug)
            //        .Enrich.FromLogContext()
            //        .WriteTo.Seq("http://localhost:5341")
            //        .WriteTo.LiterateConsole();

            //services.AddLogging(loggerBuilder =>
            //{
            //    loggerBuilder.AddSerilog(serilog.CreateLogger());
            //});


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //默认日志功能
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            #region Serilog
            //方式三
            //默认配置
            //loggerFactory.AddSerilog();

            //配置Seq服务器的地址(5341端口为默认地址)
            //注意，实际发布后的地址为"域名或IP:端口"
            var serilog = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("LoggingService", Serilog.Events.LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .WriteTo.Seq("http://localhost:5341")
                .WriteTo.LiterateConsole();
            loggerFactory.AddSerilog(serilog.CreateLogger());
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
