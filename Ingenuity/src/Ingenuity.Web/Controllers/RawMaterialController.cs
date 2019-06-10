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
    /// 原材料管理
    /// </summary>
    public class RawMaterialController : Controller
    {
        #region Fields
        private readonly BJDbContext _BJDbContext;
        #endregion

        #region Ctor
        public RawMaterialController(BJDbContext bjDbContext)
        {
            _BJDbContext = bjDbContext;
        }
        #endregion

        #region 库存
        /// <summary>
        /// 库存列表
        /// </summary>
        /// <returns></returns>
        public IActionResult InventoryList()
        {
            var list = _BJDbContext.InventoryInfo.ToList();
            return View(list);
        }

        /// <summary>
        /// 新增库存信息
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateInventoryInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateInventoryInfo(InventoryInfo inventoryInfo)
        {
            inventoryInfo.UpdateDate = DateTime.Now;
            _BJDbContext.Add(inventoryInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("InventoryList");
        }

        /// <summary>
        /// 更新库存信息
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateInventoryInfo(int inventoryInfoId)
        {
            var inventoryInfo = _BJDbContext.Find<InventoryInfo>(inventoryInfoId);
            return View(inventoryInfo);
        }

        [HttpPost]
        public IActionResult UpdateInventoryInfo(InventoryInfo inventoryInfo)
        {
            var inventory = _BJDbContext.InventoryInfo.Where(i=>i.MaterialName == inventoryInfo.MaterialName&&i.DepotSite == inventoryInfo.DepotSite && i.Id != inventoryInfo.Id).FirstOrDefault();
            if (inventory != null)
            {
                inventory.RemainCount += inventoryInfo.RemainCount;
                inventory.TotalCount += inventoryInfo.TotalCount;
                inventory.Remark = inventoryInfo.Remark;
                inventory.UpdateDate = DateTime.Now;
                var oldInventoryInfo = _BJDbContext.Find<InventoryInfo>(inventoryInfo.Id);
                _BJDbContext.Remove(oldInventoryInfo);
            }
            else
            {
                var oldInventoryInfo = _BJDbContext.Find<InventoryInfo>(inventoryInfo.Id);
                oldInventoryInfo.MaterialName = inventoryInfo.MaterialName;
                oldInventoryInfo.RemainCount = inventoryInfo.RemainCount;
                oldInventoryInfo.TotalCount = inventoryInfo.TotalCount;
                oldInventoryInfo.DepotSite = inventoryInfo.DepotSite;
                oldInventoryInfo.Remark = inventoryInfo.Remark;
                oldInventoryInfo.UpdateDate = DateTime.Now;
                _BJDbContext.Update(oldInventoryInfo);
            }
            _BJDbContext.SaveChanges();
            return RedirectToAction("InventoryList");
        }
        #endregion
    }
}