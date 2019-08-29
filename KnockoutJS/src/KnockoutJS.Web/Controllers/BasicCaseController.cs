using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnockoutJS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KnockoutJS.Web.Controllers
{
    /// <summary>
    /// ko的基础知识合集
    /// </summary>
    public class BasicCaseController : Controller
    {
        #region 首页
        /// <summary>
        /// 目录
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        #endregion 

        #region 基础知识(一)
        /// <summary>
        /// 简单入门
        /// </summary>
        /// <returns></returns>
        public IActionResult GetStart()
        {
            return View();
        }

        /// <summary>
        /// 简单案例
        /// </summary>
        /// <returns></returns>
        public IActionResult Example()
        {
            return View();
        }
        #endregion

        #region 基础知识(二)
        /// <summary>
        /// 控制文本与文本展示
        /// </summary>
        /// <returns></returns>
        public IActionResult Text()
        {
            return View();
        }

        /// <summary>
        /// 流程控制
        /// </summary>
        /// <returns></returns>
        public IActionResult Flow()
        {
            return View();
        }

        [HttpPost]
        public void CreateUser(string userName, string password)
        {

        }
        #endregion

        #region 基础知识(三)
        /// <summary>
        /// 模板绑定
        /// </summary>
        /// <returns></returns>
        public IActionResult TemplateBind()
        {
            return View();
        }
        #endregion

        #region  基础知识(四)
        List<UnitViewModel> unitViewModels = new List<UnitViewModel>()
        {
            new UnitViewModel()
            {
                BossName="唐朝",
                Address="湖南省长沙市",
                EmployeeCount = 1,
                OrganizationCode="9527",
                UnitName="星城科技",
                UnitTypeValue = UnitTypeEnum.有限公司
            },
            new UnitViewModel()
            {
                BossName="宋朝",
                Address="湖南省长沙市",
                EmployeeCount = 2,
                OrganizationCode="1234",
                UnitName="星城一宿科技",
                    UnitTypeValue = UnitTypeEnum.股份有限公司
            },
            new UnitViewModel()
            {
                BossName="元朝",
                Address="湖南省长沙市",
                EmployeeCount = 3,
                OrganizationCode="007",
                UnitName="星城供应链科技",
                UnitTypeValue = UnitTypeEnum.有限公司
            },
            new UnitViewModel()
            {
                BossName="明朝",
                Address="湖南省长沙市",
                EmployeeCount = 7,
                OrganizationCode="1379",
                UnitName="星城物联网科技",
                UnitTypeValue = UnitTypeEnum.有限责任公司
            },
            new UnitViewModel()
            {
                BossName="清朝",
                Address="湖南省长沙市",
                EmployeeCount = 8,
                OrganizationCode="2598",
                UnitName="星城云科技",
                UnitTypeValue = UnitTypeEnum.国有独资公司
            }
        };

        /// <summary>
        /// 实现前后端交互(手动绑定)
        /// </summary>
        /// <returns></returns>
        public IActionResult ManualMappingUnitViewModelList()
        {
            return View(unitViewModels);
        }

        /// <summary>
        /// 使用ajax请求加载Json数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUnitViewModelList()
        {
            unitViewModels.Add(
                new UnitViewModel()
                {
                    BossName = "汉朝",
                    Address = "湖南省长沙市",
                    EmployeeCount = 0,
                    OrganizationCode = "5836",
                    UnitName = "星城汉化科技",
                    UnitTypeValue = UnitTypeEnum.国有独资公司
                });

            var executeResult = unitViewModels != null;
            var message = executeResult ? "加载完成" : "加载失败，出现异常！";

            return Json(new { executeResult, message, unitViewModels });
        }

        /// <summary>
        /// 使用ajax提交Json数据
        /// 对于用 [FromBody] 修饰的每个操作，最多可以有一个参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ManualMappingUnitViewModelList([FromBody]List<UnitViewModel> unitViewModelList)
        {
            //...
            //todo:执行相关逻辑
            //...

            var executeResult = unitViewModelList != null && unitViewModelList.Count > 0;
            var message = executeResult ? "提交成功！" : "提交失败";

            return Json(new { executeResult, message });
        }

        /// <summary>
        /// 使用ajax提交Json数据
        /// 对于用 [FromBody] 修饰的每个操作，最多可以有一个参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ManualMappingSingleUnitViewModel([FromBody]UnitViewModel unitViewModel)
        {
            //...
            //todo:执行相关逻辑
            //...

            var executeResult = !string.IsNullOrEmpty(unitViewModel.UnitName);
            var message = executeResult ? "提交成功！" : "提交失败";

            return Json(new { executeResult, message });
        }

        /// <summary>
        /// 实现前后端交互(自动绑定)
        /// </summary>
        /// <returns></returns>
        public IActionResult AutoMappingUnitViewModel()
        {
            return View(unitViewModels);
        }
        #endregion

        #region 基础知识(五)
        /// <summary>
        /// 自定义绑定
        /// </summary>
        /// <returns></returns>
        public IActionResult CustomBinding()
        {
            return View();
        }
        #endregion
    }
}