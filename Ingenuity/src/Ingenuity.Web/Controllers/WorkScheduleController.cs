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
    /// 工单进度
    /// </summary>
    public class WorkScheduleController : Controller
    {
        #region Fields
        private readonly BJDbContext _BJDbContext;
        #endregion

        #region Ctor
        public WorkScheduleController(BJDbContext bjDbContext)
        {
            _BJDbContext = bjDbContext;
        }
        #endregion

        #region 工序安排
        /// <summary>
        /// 工序列表
        /// </summary>
        /// <returns></returns>
        public IActionResult ProcessInfoList()
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

            return View(processInfoList);
        }

        /// <summary>
        /// 为订单添加工序
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateProcessInfo(int materialInfoId)
        {
            ViewBag.EquipInfoList = _BJDbContext.EquipInfo.ToList();
            var processInfo = _BJDbContext.ProcessInfo.Where(p => p.MaterialInfoId == materialInfoId).FirstOrDefault();
            if (processInfo != null)
            {
                return View("UpdateProcessInfo", processInfo);
            }

            processInfo = new ProcessInfo()
            {
                MaterialInfoId = materialInfoId,
            };
            return View(processInfo);
        }

        [HttpPost]
        public IActionResult CreateProcessInfo(ProcessInfo processInfo)
        {
            processInfo.CreateDate = DateTime.Now;
            _BJDbContext.Add(processInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("MaterialBill", "Order");
        }

        /// <summary>
        /// 删除工序
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteProcessInfo(int processInfoId)
        {
            var processInfo = _BJDbContext.Find<ProcessInfo>(processInfoId);
            _BJDbContext.Remove<ProcessInfo>(processInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("ProcessInfoList");
        }

        /// <summary>
        /// 更新工序安排
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateProcessInfo(int processInfoId)
        {
            var order = _BJDbContext.Find<ProcessInfo>(processInfoId);
            ViewBag.EquipInfoList = _BJDbContext.EquipInfo.ToList();
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateProcessInfo(ProcessInfo processInfo)
        {
            var oldProcessInfo = _BJDbContext.Find<ProcessInfo>(processInfo.Id);
            oldProcessInfo.WorkName = processInfo.WorkName;
            oldProcessInfo.EquipInfoId = processInfo.EquipInfoId;
            _BJDbContext.Update(oldProcessInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("MaterialBill", "Order");
        }

        [HttpPost]
        public IActionResult StartProcessInfo(int processInfoId)
        {
            var success = true;
            var message = string.Empty;

            var processInfo = _BJDbContext.Find<ProcessInfo>(processInfoId);
            var materialInfo = _BJDbContext.Find<MaterialInfo>(processInfo.MaterialInfoId);
            if (materialInfo.CompleteStatus == (int)CompleteStatusEnum.待加工)
            {
                var inventoryInfo = _BJDbContext.InventoryInfo.Where(i => i.MaterialName == materialInfo.MaterialName && i.RemainCount >= materialInfo.UseCount).FirstOrDefault();
                if (inventoryInfo != null)
                {
                    inventoryInfo.RemainCount -= materialInfo.UseCount;
                    _BJDbContext.Update(inventoryInfo);

                    materialInfo.CompleteStatus = (int)CompleteStatusEnum.正加工;
                    _BJDbContext.Update(materialInfo);

                    processInfo.TechnologySituation = true;
                    _BJDbContext.Update(processInfo);

                    _BJDbContext.SaveChanges();
                    message = "该材料充足，开始加工！";
                }
                else
                {
                    success = false;
                    message = "物料清单:" + materialInfo.MaterialName + "_材料不足，需要增加库存！";
                }
            }
            else
            {
                success = false;
                message = "该物料清单正在加工中！";
            }

            return Json(new { success, message });
        }
        #endregion

        #region 设备信息

        /// <summary>
        /// 设备列表
        /// </summary>
        /// <returns></returns>
        public IActionResult EquipList()
        {
            var list = _BJDbContext.EquipInfo.ToList();
            return View(list);
        }

        /// <summary>
        /// 新增设备
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateEquipInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEquipInfo(EquipInfo equipInfo)
        {
            equipInfo.EquipNumber = DateTime.Now.ToString("yyyyMMdd") + "-" + new Random().Next(10, 99);
            equipInfo.CreateDate = DateTime.Now;
            _BJDbContext.Add(equipInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("EquipList");
        }

        /// <summary>
        /// 更新设备信息
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateEquipInfo(int equipInfoId)
        {
            var equipInfo = _BJDbContext.Find<EquipInfo>(equipInfoId);
            return View(equipInfo);
        }

        [HttpPost]
        public IActionResult UpdateEquipInfo(EquipInfo equipInfo)
        {
            var oldEquipInfo = _BJDbContext.Find<EquipInfo>(equipInfo.Id);
            oldEquipInfo.OperateSituation = equipInfo.OperateSituation;
            oldEquipInfo.Site = equipInfo.Site;
            oldEquipInfo.Name = equipInfo.Name;
            oldEquipInfo.WorkSituation = equipInfo.WorkSituation;
            _BJDbContext.Update(oldEquipInfo);
            _BJDbContext.SaveChanges();
            return RedirectToAction("EquipList");
        }
        #endregion

        #region 在制品
        /// <summary>
        /// 在制品查询
        /// </summary>
        /// <returns></returns>
        public IActionResult WorkingProduct()
        {
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

            return View(workingProductInfoList);
        }
        #endregion

        #region 材料加工
        /// <summary>
        /// 物料清单列表
        /// </summary>
        /// <returns></returns>
        public IActionResult PartProcessList()
        {
            var list = _BJDbContext.MaterialInfo.Where(m => m.CompleteStatus == (int)CompleteStatusEnum.正加工);
            foreach (var item in list)
            {
                item.OrderName = _BJDbContext.Order.Find(item.OrderId).ProductName;
            }
            return View(list);
        }

        /// <summary>
        /// 材料加工
        /// </summary>
        /// <returns></returns>
        public IActionResult PartProcessInfo(int materialInfoId)
        {
            PartProcess partProcess = new PartProcess()
            {
                MaterialInfoId = materialInfoId,
            };
            return View(partProcess);
        }

        [HttpPost]
        public IActionResult PartProcessInfo(PartProcess partProcess, int badCount)
        {
            var count = 0;//当前完成总数
            var materialInfo = _BJDbContext.MaterialInfo.Where(m => m.Id == partProcess.MaterialInfoId).FirstOrDefault();
            _BJDbContext.PartProcess.Where(p => p.MaterialInfoId == partProcess.MaterialInfoId).ToList().ForEach(c => count += c.TotalCount);

            if (count <= materialInfo.UseCount)
            {
                partProcess.CreateDate = DateTime.Now;
                _BJDbContext.Add(partProcess);
                _BJDbContext.SaveChanges();

                BadPart badPart = new BadPart();
                badPart.PartProcessId = partProcess.Id;
                badPart.CreateDate = DateTime.Now;
                badPart.BadCount = badCount;
                _BJDbContext.Add(badPart);

                if (count + partProcess.TotalCount >= materialInfo.UseCount)
                {
                    materialInfo.CompleteStatus = (int)CompleteStatusEnum.加工完成;
                    _BJDbContext.Update(materialInfo);
                }
            }

            _BJDbContext.SaveChanges();

            return RedirectToAction("PartProcessList");
        }
        #endregion
    }
}