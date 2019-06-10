using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ingenuity.Web.Infrastructure;

namespace Ingenuity.Web.Controllers
{
    /// <summary>
    /// 报表管理
    /// </summary>
    public class ReportController : Controller
    {
        #region Fields
        private readonly BJDbContext _BJDbContext;
        #endregion

        #region Ctor
        public ReportController(BJDbContext bjDbContext)
        {
            _BJDbContext = bjDbContext;
        }
        #endregion

        public IActionResult Order()
        {
            var orderList = _BJDbContext.Order.ToList();
            ViewBag.DataObject = JsonConvert.SerializeObject(orderList.OrderByDescending(c=>c.CreateDate));
            return View();
        }
        public IActionResult Material()
        {
            var materialList = _BJDbContext.MaterialInfo.ToList();
            ViewBag.DataObject = JsonConvert.SerializeObject(materialList.OrderByDescending(c => c.CreateDate));
            return View();
        }
        public IActionResult Ship()
        {
            var shipList = _BJDbContext.Ship.ToList();
            ViewBag.DataObject = JsonConvert.SerializeObject(shipList.OrderByDescending(c => c.CreateDate));
            return View();
        }
        public IActionResult WareHouse()
        {
            var wareHouseList = _BJDbContext.Warehouse.ToList();
            ViewBag.DataObject = JsonConvert.SerializeObject(wareHouseList.OrderByDescending(c => c.InDate));
            return View();
        }
        public IActionResult Inventory()
        {
            var inventoryList = _BJDbContext.InventoryInfo.ToList();
            ViewBag.DataObject = JsonConvert.SerializeObject(inventoryList.OrderByDescending(c => c.UpdateDate));
            return View();
        }
        public IActionResult Process()
        {
            var processInfoList = _BJDbContext.ProcessInfo.ToList();
            foreach (var processInfo in processInfoList)
            {
                var materialInfo = _BJDbContext.MaterialInfo.Where(m => m.Id == processInfo.MaterialInfoId).FirstOrDefault();
                processInfo.CompleteStatus = materialInfo.CompleteStatus;
                processInfo.MaterialName = materialInfo.MaterialName;
                processInfo.OrderName = _BJDbContext.Order.Find(materialInfo.OrderId).ProductName;
                var equip = _BJDbContext.EquipInfo.Where(e => e.Id == processInfo.EquipInfoId).FirstOrDefault();
                processInfo.T_EquipNumber = equip.EquipNumber;
            }
            ViewBag.DataObject = JsonConvert.SerializeObject(processInfoList.OrderByDescending(c => c.CreateDate));

            return View();
        }
        public IActionResult BadPart()
        {
            var badPartList = _BJDbContext.BadPart.ToList();
            foreach (var item in badPartList)
            {
                var partProcess = _BJDbContext.PartProcess.Find(item.PartProcessId);
                var processInfo = _BJDbContext.ProcessInfo.Where(p => p.MaterialInfoId == partProcess.MaterialInfoId).FirstOrDefault();
                var materialInfo = _BJDbContext.MaterialInfo.Where(m => m.Id == partProcess.MaterialInfoId).FirstOrDefault();
                var order = _BJDbContext.Order.Where(o => o.Id == materialInfo.OrderId).FirstOrDefault();
                item.ProcessName = processInfo == null ? string.Empty : processInfo.WorkName;
                item.MaterialName = materialInfo.MaterialName;
                item.OrderName = order.ProductName;
            }
            ViewBag.DataObject = JsonConvert.SerializeObject(badPartList.OrderByDescending(c => c.CreateDate));
            return View();
        }

    }
}