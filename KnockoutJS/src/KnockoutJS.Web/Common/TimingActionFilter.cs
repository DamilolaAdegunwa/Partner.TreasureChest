using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Common
{
    /// <summary>
    /// 方法耗时统计
    /// </summary>
    public class TimingActionFilter : ActionFilterAttribute
    {
        private readonly ILoggerFactory _logger;

        public TimingActionFilter(ILoggerFactory logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            GetTimer(filterContext, "action").Start();
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            GetTimer(filterContext, "action").Stop();
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            GetTimer(filterContext, "render").Start();
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            GetTimer(filterContext, "render").Stop();

            var actionTimer = GetTimer(filterContext, "action");
            var renderTimer = GetTimer(filterContext, "render");

            //等待换成事件总线
            _logger.CreateLogger("TimingActionFilter").LogWarning(
                    $"控制器:{filterContext.RouteData.Values["controller"]} \n" +
                    $"方法:{filterContext.RouteData.Values["action"]} \n" +
                    $"执行:{actionTimer.ElapsedMilliseconds}ms \n" +
                    $"渲染:{renderTimer.ElapsedMilliseconds}ms");

            base.OnResultExecuted(filterContext);
        }

        private Stopwatch GetTimer(ActionContext context, string name)
        {
            string key = "__timer__" + name;
            if (context.HttpContext.Items.ContainsKey(key))
            {
                return (Stopwatch)context.HttpContext.Items[key];
            }

            var result = new Stopwatch();
            context.HttpContext.Items[key] = result;
            return result;
        }
    }
}
