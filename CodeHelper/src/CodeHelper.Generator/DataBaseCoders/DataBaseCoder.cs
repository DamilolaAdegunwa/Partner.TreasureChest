//using CodeHelper.Generator.Utils;
//using RazorEngine;
//using RazorEngine.Templating; // For extension methods.
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace CodeHelper.Models
//{
//    /// <summary>
//    /// 数据库解析器
//    /// </summary>
//    public class DataBaseCoder
//    {
//        public string RazorDto { get; set; }
//        public string IRazorAppService { get; set; }
//        public string RazorAppService { get; set; }
//        public string RazorController { get; set; }
//        public string RazorView { get; set; }

//        public DataBaseCoder()
//        {
//            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Template", "RazorDto.txt");
//            RazorDto = File.ReadAllText(filePath);

//            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Template", "RazorAppService.txt");
//            RazorAppService = File.ReadAllText(filePath);

//            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Template", "IRazorAppService.txt");
//            IRazorAppService = File.ReadAllText(filePath);

//            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Template", "RazorController.txt");
//            RazorController = File.ReadAllText(filePath);

//            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Template", "RazorView.txt");
//            RazorView = File.ReadAllText(filePath);
//        }

//        public string RazorParse(string tablename, string tablecomment)
//        {
//            #region 实体Dto
//            var dto_result = Razor.Parse(dto_template, new
//            {
//                DtoNameSpace = "Ace.Application.CMS.Models",
//                DtoName = Utils.ToCamelName(tablename) + "Info",
//                Columns = columsInfo
//            }, "dto");
//            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\Dto", $"{UtilHelper.ToCamelName(tablename) + "Info"}.cs"), dto_result);
//            builder.Append(dto_result);
//            #endregion

//            #region 应用服务实现
//            var app_result = Razor.Parse(app_template, new
//            {
//                AppNameSpace = "Ace.Application.CMS.Implements",
//                DtoName = Utils.ToCamelName(tablename) + "Info",
//                AppClassName = Utils.ToCamelName(tablename),
//                Table = tablename,
//                Columns = columsInfo,
//                TableComment = tablecomment,
//                Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
//            }, "app");
//            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\Implements", $"{UtilHelper.ToCamelName(tablename) + "Service"}.cs"), app_result);
//            builder.Append(app_result);
//            #endregion

//            #region 应用服务接口
//            var appjk_result = Razor.Parse(appjk_template, new
//            {
//                AppNameSpace = "Ace.Application.CMS.Interfaces",
//                DtoName = Utils.ToCamelName(tablename) + "Info",
//                AppClassName = Utils.ToCamelName(tablename),
//                Table = tablename,
//                Columns = columsInfo,
//                TableComment = tablecomment,
//                Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
//            }, "appjk");
//            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\Interfaces", $"I{UtilHelper.ToCamelName(tablename) + "Service"}.cs"), appjk_result);
//            builder.Append(appjk_result);
//            #endregion

//            #region 控制器
//            var ctrl_result = Razor.Parse(ctrl_template, new
//            {
//                AppClassName = Utils.ToCamelName(tablename),
//                DtoName = Utils.ToCamelName(tablename) + "Info",
//                TableComment = tablecomment,
//                Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
//            }, "ctrl");
//            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\Controller", $"{UtilHelper.ToCamelName(tablename) + "Controller"}.cs"), ctrl_result);
//            builder.Append(ctrl_result);
//            #endregion

//            #region 视图
//            var view_result = Engine.Razor.RunCompile(RazorView, new
//            {
//                TableName = Utils.ToCamelName(tablename).ToLower(),
//                TableComment = string.IsNullOrEmpty(tablecomment) ? tablename : tablecomment,
//                Columns = columsInfo,
//                Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
//            }, "view");
//            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\View", $"{UtilHelper.ToCamelName(tablename).ToLower()}.html"), view_result);
//            builder.Append(view_result);
//            #endregion

//            return builder.ToString();
//        }
//    }
//}
