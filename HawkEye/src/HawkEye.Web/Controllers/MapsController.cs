using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HawkEye.Web.Controllers
{
    public class MapsController : Controller
    {
        /// <summary>
        /// 高德地图
        /// </summary>
        /// <returns></returns>
        public IActionResult AliMap()
        {
            return View();
        }

        /// <summary>
        /// 百度地图
        /// </summary>
        /// <returns></returns>
        public IActionResult BaiduMap()
        {
            return View();
        }

        /// <summary>
        /// 腾讯地图
        /// </summary>
        /// <returns></returns>
        public IActionResult TencentMap()
        {
            return View();
        }
    }
}