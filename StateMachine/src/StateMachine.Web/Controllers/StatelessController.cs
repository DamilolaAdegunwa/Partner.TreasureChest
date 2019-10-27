using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StateMachine.Web.Models;

namespace StateMachine.Web.Controllers
{
    public class StatelessController : Controller
    {
        static readonly List<Order> orderList = new List<Order>()
        {
            new Order(1,"衣服","80",150),
            new Order(2,"裤子","443",100),
            new Order(3,"鞋子","3306",200),
            new Order(4,"袜子","9527",50),
        };

        public IActionResult Index()
        {
            return View(orderList);
        }
    }
}