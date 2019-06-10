using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ingenuity.Web.Infrastructure;
using Ingenuity.Web.Models;

namespace Ingenuity.Web.Controllers
{
    /// <summary>
    /// 生产进度
    /// </summary>
    public class ProductScheduleController : Controller
    {
        #region Fields
        private readonly BJDbContext _BJDbContext;
        #endregion

        #region Ctor
        public ProductScheduleController(BJDbContext bjDbContext)
        {
            _BJDbContext = bjDbContext;
        }
        #endregion

        /// <summary>
        /// 完成进度
        /// </summary>
        /// <returns></returns>
        public IActionResult TaskSchedule()
        {
            #region 订单完成数量
            var orderValidList = new List<Models.Order>();
            var orderList = _BJDbContext.Order.ToList();
            foreach (var order in orderList)
            {
                order.IsComplete = _BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id).Count() > 0
                    && _BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id && (m.CompleteStatus == (int)CompleteStatusEnum.待加工 || m.CompleteStatus == (int)CompleteStatusEnum.正加工)).Count() == 0;
                if (order.IsComplete)
                {
                    orderValidList.Add(order);
                }
            }
            ViewBag.OrderCompleteCount = orderValidList.Count();
            #endregion

            #region 订单已出货数量
            ViewBag.OrderShipCount = _BJDbContext.Order.Where(c => c.IsShip == true).ToList().Count();
            #endregion

            #region 订单待完成数量
            var orderUnCompleteList = new List<Models.Order>();
            orderList = _BJDbContext.Order.Where(c => c.IsShip == false).ToList();
            foreach (var order in orderList)
            {
                order.IsComplete = _BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id).Count() > 0
                    && _BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id && (m.CompleteStatus == (int)CompleteStatusEnum.待加工 || m.CompleteStatus == (int)CompleteStatusEnum.正加工)).Count() == 0;
                if (!order.IsComplete)
                {
                    orderUnCompleteList.Add(order);
                }
            }
            ViewBag.OrderUnCompleteCount = orderUnCompleteList.Count();
            #endregion

            #region 订单待配置物料清单数量
            var list = new List<Models.Order>();
            orderList = _BJDbContext.Order.Where(c => c.IsShip == false).ToList();
            foreach (var order in orderList)
            {
                if (_BJDbContext.MaterialInfo.Where(m => m.OrderId == order.Id).Count() == 0)
                {
                    list.Add(order);
                }
            }
            ViewBag.OrderNoMaterialCount = list.Count();
            #endregion

            #region 物料清单总数量
            ViewBag.MaterialCount = _BJDbContext.MaterialInfo.ToList().Count();
            #endregion

            #region 物料清单正加工数量
            ViewBag.MaterialCompletingCount = _BJDbContext.MaterialInfo.Where(m => m.CompleteStatus == (int)CompleteStatusEnum.正加工).ToList().Count();
            #endregion

            #region 物料清单已完成数量
            ViewBag.MaterialCompletedCount = _BJDbContext.MaterialInfo.Where(m => m.CompleteStatus == (int)CompleteStatusEnum.加工完成).ToList().Count();
            #endregion

            #region 物料清单待加工数量
            ViewBag.MaterialWaitCompleteCount = _BJDbContext.MaterialInfo.Where(m => m.CompleteStatus == (int)CompleteStatusEnum.待加工).ToList().Count();
            #endregion

            #region 在制品信息
            var workingProductInfoList = new List<WorkingProductInfo>();
            var materialInfoList = _BJDbContext.MaterialInfo.Where(M => M.CompleteStatus == (int)CompleteStatusEnum.正加工).ToList();
            foreach (var materialInfo in materialInfoList)
            {
                var count = 0;
                _BJDbContext.PartProcess.Where(p => p.MaterialInfoId == materialInfo.Id).ToList().ForEach(c => count += c.TotalCount);
                var order = _BJDbContext.Order.Find(materialInfo.OrderId);
                workingProductInfoList.Add(new WorkingProductInfo()
                {
                    AimCount = materialInfo.UseCount.ToString(),
                    FinishCount = count.ToString(),
                    DifferCount = (materialInfo.UseCount - count).ToString(),
                    MaterialName = materialInfo.MaterialName,
                    OrderId = materialInfo.OrderId.ToString(),
                    OrderName = order.ProductName,
                });
            }

            ViewBag.AimCount = JsonConvert.SerializeObject(workingProductInfoList.Select(w => w.AimCount).Take(10).ToList());
            ViewBag.FinishCount = JsonConvert.SerializeObject(workingProductInfoList.Select(w => w.FinishCount).Take(10).ToList());
            ViewBag.MaterialName = JsonConvert.SerializeObject(workingProductInfoList.Select(w => w.MaterialName).Take(10).ToList());
            #endregion

            return View();
        }

        /// <summary>
        /// 图表分析
        /// </summary>
        /// <returns></returns>
        public IActionResult ChartAnalysis()
        {
            #region 在制品信息
            var workingProductInfoList = new List<WorkingProductInfo>();
            var materialInfoList = _BJDbContext.MaterialInfo.Where(M => M.CompleteStatus == (int)CompleteStatusEnum.正加工).ToList();
            foreach (var materialInfo in materialInfoList)
            {
                var count = 0;
                _BJDbContext.PartProcess.Where(p => p.MaterialInfoId == materialInfo.Id).ToList().ForEach(c => count += c.TotalCount);
                var order = _BJDbContext.Order.Find(materialInfo.OrderId);
                workingProductInfoList.Add(new WorkingProductInfo()
                {
                    AimCount = materialInfo.UseCount.ToString(),
                    FinishCount = count.ToString(),
                    DifferCount = (materialInfo.UseCount - count).ToString(),
                    MaterialName = materialInfo.MaterialName,
                    OrderId = materialInfo.OrderId.ToString(),
                    OrderName = order.ProductName,
                });
            }

            ViewBag.AimCount = JsonConvert.SerializeObject(workingProductInfoList.Select(w => w.AimCount).Take(10).ToList());
            ViewBag.FinishCount = JsonConvert.SerializeObject(workingProductInfoList.Select(w => w.FinishCount).Take(10).ToList());
            ViewBag.MaterialName = JsonConvert.SerializeObject(workingProductInfoList.Select(w => w.MaterialName).Take(10).ToList());
            #endregion

            #region 订单总量与出货量
            var orderList = _BJDbContext.Order.OrderByDescending(o => o.CreateDate).Take(10);
            ViewBag.OrderCount = JsonConvert.SerializeObject(orderList.Select(O => O.Count).ToList());
            var countRecord = new List<int>();
            foreach (var order in orderList)
            {
                var count = 0;
                _BJDbContext.Ship.Where(s => s.OrderId == order.Id.ToString()).ToList().ForEach(c => count += c.Count);
                countRecord.Add(count);
            }
            ViewBag.OrderShipCount = JsonConvert.SerializeObject(countRecord);
            ViewBag.OrderName = JsonConvert.SerializeObject(orderList.Select(O => O.ProductName).ToList());
            #endregion

            #region 不良品列表
            var list = _BJDbContext.BadPart.ToList();
            foreach (var item in list)
            {
                var partProcess = _BJDbContext.PartProcess.Find(item.PartProcessId);
                var processInfo = _BJDbContext.ProcessInfo.Where(p => p.MaterialInfoId == partProcess.MaterialInfoId).FirstOrDefault();
                var materialInfo = _BJDbContext.MaterialInfo.Where(m => m.Id == partProcess.MaterialInfoId).FirstOrDefault();
                var order = _BJDbContext.Order.Where(o => o.Id == materialInfo.OrderId).FirstOrDefault();
                item.ProcessName = processInfo == null ? string.Empty : processInfo.WorkName;
                item.MaterialName = materialInfo.MaterialName;
                item.OrderName = order.ProductName;
            }
            ViewBag.ProcessName = JsonConvert.SerializeObject(list.Select(l => l.ProcessName + "_" + l.MaterialName).Take(10).ToList());
            ViewBag.BadCount = JsonConvert.SerializeObject(list.Select(l => l.BadCount).Take(10).ToList());
            #endregion

            return View();
        }
    }
}