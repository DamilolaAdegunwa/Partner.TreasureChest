using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogPanel.Web.Models;
using Microsoft.Extensions.Logging;
using System.Text;
using Serilog;

namespace LogPanel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _logger.LogDebug($"开始监控整个网站的日志信息_Debug{DateTime.Now}");
            _logger.LogInformation($"开始监控整个网站的日志信息Information_{DateTime.Now}");
            return View();
        }

        public IActionResult About()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ViewData["Message"] = "Your application description page.";

            try
            {
                _logger.LogInformation($"业务逻辑执行前，运行正常");
                //执行其它业务逻辑
                int textInt = 5;
                int result = textInt / 0;
                //执行其它业务逻辑
                _logger.LogInformation($"业务逻辑执行后，运行正常");
            }
            catch (Exception ex)
            {
                _logger.LogError($"出现异常,异常信息{ex.Message}");
                throw;
            }

            return View();
        }

        public IActionResult Contact()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Log.Debug("Log.Debug:Serilog Start Send Message");
            Log.Information("Log.Information:Serilog Start send Message");
            Log.Logger.Debug("Log.Logger:Serilog Start Send Message");
            Log.Logger.Information("Log.Logger.Information:Serilog Start Send Message");
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
