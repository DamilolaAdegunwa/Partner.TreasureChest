using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ingenuity.Web.Infrastructure;
using Ingenuity.Web.Models;

namespace Ingenuity.Web.Controllers
{
    /// <summary>
    /// 订单管理
    /// </summary>
    public class OrderController : Controller
    {
        #region Fields
        private readonly BJDbContext _BJDbContext;
        #endregion

        #region Ctor
        public OrderController(BJDbContext bjDbContext)
        {
            _BJDbContext = bjDbContext;
        }
        #endregion

        #region 订单
        /// <summary>
        /// 订单列表
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderList()
        {
            var orderList = _BJDbContext.Order.ToList();
            foreach (var order in orderList)
            {
                order.IsComplete = _BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id).Count() > 0
                    && _BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id && (m.CompleteStatus == (int)CompleteStatusEnum.待加工 || m.CompleteStatus == (int)CompleteStatusEnum.正加工)).Count() == 0;
            }

            return View(orderList);
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderDetail(int orderId)
        {
            var order = _BJDbContext.Find<Order>(orderId);
            ViewBag.MaterialInfoList = _BJDbContext.MaterialInfo.Where(m => m.OrderId == orderId).ToList();
            return View(order);
        }

        /// <summary>
        /// 订单添加
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            order.CreateDate = DateTime.Now;
            order.OrderNumber = DateTime.Now.ToString("yyyyMMdd")+"_"+new Random().Next(1,9999);
            _BJDbContext.Add(order);
            _BJDbContext.SaveChanges();
            return RedirectToAction("OrderList");
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteOrder(int orderId)
        {
            var order = _BJDbContext.Find<Order>(orderId);
            _BJDbContext.Remove<Order>(order);
            _BJDbContext.SaveChanges();
            return RedirectToAction("OrderList");
        }

        /// <summary>
        /// 订单更新
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateOrder(int orderId)
        {
            var order = _BJDbContext.Find<Order>(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            var oldOrder = _BJDbContext.Find<Order>(order.Id);
            oldOrder.CompanyName = order.CompanyName;
            oldOrder.WorkerName = order.WorkerName;
            oldOrder.ModleNum = order.ModleNum;
            oldOrder.ProductName = order.ProductName;
            oldOrder.Size = order.Size;
            oldOrder.Count = order.Count;
            _BJDbContext.Update(oldOrder);
            _BJDbContext.SaveChanges();
            return RedirectToAction("OrderList");
        }
        #endregion

        #region 物料清单
        /// <summary>
        /// 订单相关物料清单列表
        /// </summary>
        /// <returns></returns>
        public IActionResult MaterialBill()
        {
            var list = _BJDbContext.MaterialInfo.ToList();
            foreach (var item in list)
            {
                item.OrderName = _BJDbContext.Order.Find(item.OrderId).ProductName;
            }
            return View(list);
        }

        /// <summary>
        /// 新增物料清单
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateMaterialBill(int orderId)
        {
            var materialInfo = new MaterialInfo()
            {
                OrderId = orderId,
            };
            return View(materialInfo);
        }

        [HttpPost]
        public IActionResult CreateMaterialBill(MaterialInfo materialInfo)
        {
            var orderCount = _BJDbContext.Order.Find(materialInfo.OrderId).Count;
            materialInfo.UseCount = orderCount * materialInfo.UseCount;
            materialInfo.CreateDate = DateTime.Now;
            _BJDbContext.Add(materialInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("OrderList");
        }

        /// <summary>
        /// 新增物料清单
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateMaterialBill(int materialInfoId)
        {
            var materialInfo = _BJDbContext.Find<MaterialInfo>(materialInfoId);
            materialInfo.UseCount = materialInfo.UseCount / _BJDbContext.Order.Find(materialInfoId).Count;
            return View(materialInfo);
        }

        [HttpPost]
        public IActionResult UpdateMaterialBill(MaterialInfo materialInfo)
        {
            var oldMaterialInfo = _BJDbContext.Find<MaterialInfo>(materialInfo.Id);
            oldMaterialInfo.MaterialName = materialInfo.MaterialName;
            oldMaterialInfo.UseCount = materialInfo.UseCount;
            _BJDbContext.Update(oldMaterialInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("MaterialBill");
        }

        /// <summary>
        /// 删除物料清单
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteMaterialBill(int materialInfoId)
        {
            var materialInfo = _BJDbContext.Find<MaterialInfo>(materialInfoId);
            _BJDbContext.Remove<MaterialInfo>(materialInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("MaterialBill");
        }
        #endregion
    }
}