using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Stateless.Graph;
using StateMachine.Web.Models;

namespace StateMachine.Web.Controllers
{
    /// <summary>
    /// 状态机变更方式
    /// </summary>
    public class StatelessController : Controller
    {
        /// <summary>
        /// 静态数据模拟数据库
        /// </summary>
        static readonly List<Order> orderList = new List<Order>()
        {
            new Order(1,"衣服","80",150),
            new Order(2,"裤子","443",100),
            new Order(3,"鞋子","3306",200),
            new Order(4,"袜子","9527",50),
            new Order(5,"外套","8080",230),
            new Order(6,"帽子","1433",60),
        };

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(orderList);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateOrderState(long id, OrderTrigger orderTrigger)
        {
            var order = orderList.Where(o => o.OrderId == id).First();

            var orderManager = new OrderManager(order);
            orderManager.TriggerOrderState(orderTrigger);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 流程运行图
        /// </summary>
        /// <returns></returns>
        public IActionResult DotGraph()
        {
            var orderManager = new OrderManager();
            ViewBag.Graph = orderManager.GetDotGraph();
            return View();
        }
    }
}