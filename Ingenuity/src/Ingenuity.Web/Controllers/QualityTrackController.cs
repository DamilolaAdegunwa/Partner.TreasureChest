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
    /// 质量跟踪
    /// </summary>
    public class QualityTrackController : Controller
    {
        #region Fields
        private readonly BJDbContext _BJDbContext;
        #endregion

        #region Ctor
        public QualityTrackController(BJDbContext bjDbContext)
        {
            _BJDbContext = bjDbContext;
        }
        #endregion

        /// <summary>
        /// 不良品管理
        /// </summary>
        /// <returns></returns>
        public IActionResult InferiorProduct()
        {
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
            return View(list);
        }

        /// <summary>
        /// 更新不良品信息
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateInferiorProduct(int badPartId)
        {
            var badPart = _BJDbContext.Find<BadPart>(badPartId);
            var partProcess = _BJDbContext.PartProcess.Find(badPart.PartProcessId);
            var processInfo = _BJDbContext.ProcessInfo.Where(p => p.MaterialInfoId == partProcess.MaterialInfoId).FirstOrDefault();
            badPart.ProcessName = processInfo == null ? string.Empty : processInfo.WorkName;
            return View(badPart);
        }

        [HttpPost]
        public IActionResult UpdateInferiorProduct(BadPart badPart)
        {
            var oldBadPart = _BJDbContext.Find<BadPart>(badPart.Id);
            oldBadPart.BadCount = badPart.BadCount;
            _BJDbContext.Update(oldBadPart);
            _BJDbContext.SaveChanges();
            return RedirectToAction("InferiorProduct");
        }

        /// <summary>
        /// 删除不良品信息
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteInferiorProduct(int badPartId)
        {
            var badPart = _BJDbContext.Find<BadPart>(badPartId);
            _BJDbContext.Remove<BadPart>(badPart);
            _BJDbContext.SaveChanges();
            return RedirectToAction("InferiorProduct");
        }
    }
}