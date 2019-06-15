using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KnockoutJS.Web.Controllers
{
    /// <summary>
    /// 作者
    /// </summary>
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}