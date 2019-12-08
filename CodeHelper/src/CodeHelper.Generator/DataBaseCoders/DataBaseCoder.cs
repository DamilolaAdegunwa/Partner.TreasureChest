using CodeHelper.Generator.Utils;
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
        public string RazorDto { get; set; }
        public string IRazorAppService { get; set; }
        public string RazorAppService { get; set; }
        public string RazorController { get; set; }
        public string RazorView { get; set; }

        public DataBaseCoder()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBaseCoders\\Templates", "RazorDto.txt");
            RazorDto = File.ReadAllText(filePath);

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

            #region 实体Dto
            //var razorDto = Engine.Razor.RunCompile(RazorDto, "RazorDto", null, new
            //{
            //    DtoNameSpace = "Ace.Application.CMS.Models",
            //    //DtoName = Utils.ToCamelName(tablename) + "Info",
            //    //Columns = columsInfo
            //});
            //UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\Dto", $"{UtilHelper.ToCamelName(entityName) + "Dto"}.cs"), razorDto);
            //builder.Append(razorDto);
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
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\"+ UtilHelper.ToCamelName(entityName) + "s", $"I{UtilHelper.ToCamelName(entityName) + "AppService"}.cs"), iRazorAppService);
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
            UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\" + UtilHelper.ToCamelName(entityName) + "s", $"{ UtilHelper.ToCamelName(entityName) + "AppService"}.cs"), razorAppService);
            builder.Append(razorAppService);
            #endregion

            #region 控制器
            //var razorController = Engine.Razor.RunCompile(RazorController, "RazorController", null, new
            //{
            //    //AppClassName = Utils.ToCamelName(tablename),
            //    //DtoName = Utils.ToCamelName(tablename) + "Info",
            //    //TableComment = tablecomment,
            //    //Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
            //});
            //UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\Controller", $"{UtilHelper.ToCamelName(entityName) + "Controller"}.cs"), razorController);
            //builder.Append(razorController);
            #endregion

            #region 视图
            //var razorView = Engine.Razor.RunCompile(RazorView, "RazorView", null, new
            //{
            //    TableName = Utils.ToCamelName(tablename).ToLower(),
            //    TableComment = string.IsNullOrEmpty(tablecomment) ? tablename : tablecomment,
            //    Columns = columsInfo,
            //    Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
            //});
            //UtilHelper.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeGenerate\\Code\\View", $"{UtilHelper.ToCamelName(entityName).ToLower()}.cshtml"), razorView);
            //builder.Append(razorView);
            #endregion

            return builder.ToString();
        }
    }
}
