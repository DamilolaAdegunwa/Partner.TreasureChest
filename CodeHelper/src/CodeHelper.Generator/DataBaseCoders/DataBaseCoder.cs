﻿using CodeHelper.Generator.Utils;
using RazorEngine;
using RazorEngine.Templating; // For extension methods.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeHelper.Generator.DataBaseCoders
{
    /// <summary>
    /// 数据库解析器
    /// </summary>
    public class DataBaseCoder
    {
        public string RazorListDto { get; set; }
        public string RazorEditDto { get; set; }
        public string IRazorAppService { get; set; }
        public string RazorAppService { get; set; }
        public string RazorController { get; set; }
        public string RazorView { get; set; }

        public DataBaseCoder()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorListDto.txt");
            RazorListDto = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorEditDto.txt");
            RazorEditDto = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorAppService.txt");
            RazorAppService = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "IRazorAppService.txt");
            IRazorAppService = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorController.txt");
            RazorController = File.ReadAllText(filePath);

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorView.txt");
            RazorView = File.ReadAllText(filePath);
        }

        public string RazorParse(string entityName)
        {
            StringBuilder builder = new StringBuilder();

            var applicationPath = string.Format($"CodeResult\\{UtilHelper.ToCamelName(entityName)}s\\Application\\{UtilHelper.ToCamelName(entityName)}s");
            var mvcPath = string.Format($"CodeResult\\{UtilHelper.ToCamelName(entityName)}s\\Mvc");

            #region 数据传输对象
            var razorListDto = Engine.Razor.RunCompile(RazorListDto, "RazorListDto", null, new
            {
                ProjectRootName = "Surround",
                ProjectNameSpace = "Partner.Surround",
                ProjectModule = "Base",
                EntityName = UtilHelper.ToCamelName(entityName),
                EntityDescription = "公司",
                EntityKeyType = "int"
            });
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"Dto\\{UtilHelper.ToCamelName(entityName)}ListDto.cs"), razorListDto);
            builder.Append(razorListDto);

            var razorEditDto = Engine.Razor.RunCompile(RazorEditDto, "RazorEditDto", null, new
            {
                ProjectRootName = "Surround",
                ProjectNameSpace = "Partner.Surround",
                ProjectModule = "Base",
                EntityName = UtilHelper.ToCamelName(entityName),
                EntityDescription = "公司",
                EntityKeyType = "int"
            });
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"Dto\\{UtilHelper.ToCamelName(entityName)}EditDto.cs"), razorEditDto);
            builder.Append(razorEditDto);
            #endregion

            #region 应用服务接口
            var iRazorAppService = Engine.Razor.RunCompile(IRazorAppService, "IRazorAppService", null, new
            {
                ProjectNameSpace = "Partner.Surround",
                ProjectModule = "Base",
                EntityName = UtilHelper.ToCamelName(entityName),
                EntityDescription = "公司",
                EntityKeyType = "int"
            });
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"I{UtilHelper.ToCamelName(entityName)}AppService.cs"), iRazorAppService);
            builder.Append(iRazorAppService);
            #endregion

            #region 应用服务实现
            var razorAppService = Engine.Razor.RunCompile(RazorAppService, "RazorAppService", null, new
            {
                ProjectRootName = "Surround",
                ProjectNameSpace = "Partner.Surround",
                ProjectModule = "Base",
                EntityName = UtilHelper.ToCamelName(entityName),
                EntityNameLower = UtilHelper.ToCamelName(entityName).ToLower(),
                EntityDescription = "公司",
                EntityKeyType = "int"
            });
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, applicationPath, $"{UtilHelper.ToCamelName(entityName)}AppService.cs"), razorAppService);
            builder.Append(razorAppService);
            #endregion

            #region 控制器
            var razorController = Engine.Razor.RunCompile(RazorController, "RazorController", null, new
            {
                ProjectRootName = "Surround",
                ProjectNameSpace = "Partner.Surround",
                ProjectModule = "Base",
                EntityName = UtilHelper.ToCamelName(entityName),
                EntityNameLower = UtilHelper.ToCamelName(entityName).ToLower(),
                EntityDescription = "公司",
                EntityKeyType = "int"
            });
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mvcPath + "\\Controllers\\", $"{UtilHelper.ToCamelName(entityName)}Controller.cs"), razorController);
            builder.Append(razorController);
            #endregion

            #region 视图
            var razorView = Engine.Razor.RunCompile(RazorView, "RazorView", null, new
            {
                ProjectRootName = "Surround",
                ProjectNameSpace = "Partner.Surround",
                ProjectModule = "Base",
                EntityName = UtilHelper.ToCamelName(entityName),
                EntityNameLower = UtilHelper.ToCamelName(entityName).ToLower(),
                EntityDescription = "公司",
                EntityKeyType = "int"
            });
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mvcPath + "\\Views\\Index.cshtml"), razorView);
            builder.Append(razorView);
            #endregion

            return builder.ToString();
        }
    }
}
