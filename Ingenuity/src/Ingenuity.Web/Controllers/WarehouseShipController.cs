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
    /// 入库出货管理
    /// </summary>
    public class WarehouseShipController : Controller
    {
        #region Fields
        private readonly BJDbContext _BJDbContext;
        #endregion

        #region Ctor
        public WarehouseShipController(BJDbContext bjDbContext)
        {
            _BJDbContext = bjDbContext;
        }
        #endregion

        /// <summary>
        /// 入库业务
        /// </summary>
        /// <returns></returns>
        public IActionResult WarehouseOperation()
        {
            return View();
        }

        /// <summary>
        /// 入库业务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult WarehouseOperation(Warehouse warehouse)
        {
            //增加入库记录
            warehouse.InDate = DateTime.Now;
            _BJDbContext.Warehouse.Add(warehouse);

            //修改库存信息
            var inventoryInfo = _BJDbContext.InventoryInfo.Where(i => i.MaterialName == warehouse.MaterialName
                                        && i.DepotSite == warehouse.DepotSite).FirstOrDefault();
            if (inventoryInfo != null)
            {
                inventoryInfo.TotalCount += warehouse.Count;
                inventoryInfo.RemainCount += warehouse.Count;
            }
            else
            {
                inventoryInfo = new InventoryInfo()
                {
                    DepotSite = warehouse.DepotSite,
                    MaterialName = warehouse.MaterialName,
                    RemainCount = warehouse.Count,
                    TotalCount = warehouse.Count,
                    UpdateDate = DateTime.Now
                };
                _BJDbContext.InventoryInfo.Add(inventoryInfo);
            }
            _BJDbContext.SaveChanges();

            return RedirectToAction("InventoryList", "RawMaterial");
        }

        /// <summary>
        /// 出货列表页
        /// </summary>
        /// <returns></returns>
        public IActionResult ShipOperation()
        {
            var orderValidList = new List<Order>();
            var orderList = _BJDbContext.Order.Where(o => o.IsShip == false).ToList();
            foreach (var order in orderList)
            {
                order.IsComplete = _BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id).Count() > 0
                    && _BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id && (m.CompleteStatus == (int)CompleteStatusEnum.待加工 || m.CompleteStatus == (int)CompleteStatusEnum.正加工)).Count() == 0;
                if (order.IsComplete)
                {
                    orderValidList.Add(order);
                }
            }

            return View(orderValidList);
        }

        /// <summary>
        /// 出货业务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ProductShip(int orderId)
        {
            var ship = new Ship()
            {
                OrderId = orderId.ToString(),
            };
            ship.OrderName = _BJDbContext.Order.Find(orderId).ProductName;
            return View(ship);
        }

        /// <summary>
        /// 出货业务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ProductShip(Ship ship)
        {
            var success = true;
            var message = string.Empty;

            var order = _BJDbContext.Order.Find(int.Parse(ship.OrderId));

            if (ship.Count > order.Count)
            {
                success = false;
                message = "出货量超出订单要求,请修改！";
            }

            if (success)
            {
                ship.CreateDate = DateTime.Now;
                _BJDbContext.Add(ship);
                _BJDbContext.SaveChanges();

                order.IsShip = true;
                _BJDbContext.Update(order);
                _BJDbContext.SaveChanges();

                message = $"{order.CompanyName}的订单{order.ProductName}出货成功！";
            }

            return Json(new { success, message });
        }
    }
}