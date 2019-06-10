using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DingTalk.Web.Models;

namespace DingTalk.Web.Controllers
{
    public class HttpClientController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public HttpClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route(nameof(Index))]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("http://aspnetcore.online/api/resource/getresource");
            return Ok(result);
        }

        [HttpGet]
        [Route(nameof(GetWebResource))]
        public async Task<IActionResult> GetWebResource()
        {
            //do something...
            using (var httpClient = new HttpClient())
            {
                var requestUri = "http://aspnetcore.online/api/resource/getresource";
                var httpResponseMessage = await httpClient.GetAsync(requestUri);
                //do something...

                return Ok(httpResponseMessage);
            }
        }

        [HttpGet]
        [Route(nameof(PostWebResource))]
        public async Task<IActionResult> PostWebResource()
        {
            //do something...
            using (var httpClient = new HttpClient())
            {
                var requestUri = "http://aspnetcore.online/api/resource/postresource";
                var httpResponseMessage = await httpClient.PostAsJsonAsync(requestUri, "星城软件");
                //do something...

                return Ok(httpResponseMessage);
            }
        }
    }
}
