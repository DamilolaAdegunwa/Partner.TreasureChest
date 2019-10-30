using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StateMachine.Web.Models;

namespace StateMachine.Web.Controllers
{
    /// <summary>
    /// 常用流程变更方式
    /// </summary>
    public class CommonController : Controller
    {
        /// <summary>
        /// 静态数据模拟数据库
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
        /// 跳转支付
        /// </summary>
        /// <returns></returns>
        public IActionResult JumpPayment(long id)
        {
            var order = orderList.Where(o => o.OrderId == id).First();
            if (order.OrderState != OrderState.OrderCreated)
            {
                throw new Exception("状态错误");
            }

            order.SetOrderState(OrderState.OrderPendingPay);//待支付

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <returns></returns>
        public IActionResult CancelOrder(long id)
        {
            var order = orderList.Where(o => o.OrderId == id).First();
            if ((order.OrderState != OrderState.OrderCreated) &&
                (order.OrderState != OrderState.OrderPendingPay) &&
                (order.OrderState != OrderState.OrderPendingSend))
            {
                throw new Exception("状态错误");
            }

            if ((order.OrderState == OrderState.OrderCreated) ||
                (order.OrderState == OrderState.OrderPendingPay))
            {
                order.SetOrderState(OrderState.OrderInvalided);//无效
            }
            else
            {
                order.SetOrderState(OrderState.OrderPendingRefund);//待退款
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 完成支付
        /// </summary>
        /// <returns></returns>
        public IActionResult CompletePayment(long id)
        {
            var order = orderList.Where(o => o.OrderId == id).First();
            if (order.OrderState != OrderState.OrderPendingPay)
            {
                throw new Exception("状态错误");
            }

            order.SetOrderState(OrderState.OrderPendingSend);//待配送

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 完成配送
        /// </summary>
        /// <returns></returns>
        public IActionResult CompleteSend(long id)
        {
            var order = orderList.Where(o => o.OrderId == id).First();
            if (order.OrderState != OrderState.OrderPendingSend)
            {
                throw new Exception("状态错误");
            }

            order.SetOrderState(OrderState.OrderPendingSign);//待签收

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 完成收货
        /// </summary>
        /// <returns></returns>
        public IActionResult CompleteSign(long id)
        {
            var order = orderList.Where(o => o.OrderId == id).First();
            if (order.OrderState != OrderState.OrderPendingSign)
            {
                throw new Exception("状态错误");
            }

            order.SetOrderState(OrderState.OrderCompleted);//已完成

            return RedirectToAction("Index");
        }

        /// <summary>
        /// 完成退款
        /// </summary>
        /// <returns></returns>
        public IActionResult CompleteRefund(long id)
        {
            var order = orderList.Where(o => o.OrderId == id).First();
            if (order.OrderState != OrderState.OrderPendingRefund)
            {
                throw new Exception("状态错误");
            }

            order.SetOrderState(OrderState.OrderInvalided);//无效

            return RedirectToAction("Index");
        }
    }
}