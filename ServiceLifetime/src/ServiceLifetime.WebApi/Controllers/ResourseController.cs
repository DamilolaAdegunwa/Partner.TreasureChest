using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLifetime.WebApi.Controllers
{
    /// <summary>
    /// 放置资源用于模拟请求
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ResourseController : ControllerBase
    {
        [HttpGet]
        [Route(nameof(GetResourse))]
        public IActionResult GetResourse()
        {
            return Ok(new { CompanyName = "星城科技", Address = "湖南长沙雨花区", Phone = "9527" });
        }

        [HttpPost]
        [Route(nameof(PostResourse))]
        public IActionResult PostResourse(string companyName)
        {
            return Ok(new { CompanyName = companyName, Address = "湖南长沙雨花区", Phone = "9527" });
        }
    }
}