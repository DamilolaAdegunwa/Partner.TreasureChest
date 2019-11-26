using CMS.Tool.WebApi.Models.Base;
using RazorEngine;
using RazorEngine.Templating; // For extension methods.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeHelper.Models
{
    public class Coder: DbService
    {
        public string entity_template { get; set; }
        public string dto_template { get; set; }
        public string app_template { get; set; }
        public string appjk_template { get; set; }
        public string ctrl_template { get; set; }
        public string view_template { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string dbschema { get; set; }
        public Coder()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Template", "实体类razor.txt");
            entity_template = File.ReadAllText(path);

            var dto_path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Template", "DTO类razor.txt");
            dto_template = File.ReadAllText(dto_path);

            var app_path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Template", "应用类razor.txt");
            app_template = File.ReadAllText(app_path);

           var appjk_path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Template", "应用类_接口razor.txt");
            appjk_template = File.ReadAllText(appjk_path);

            var ctrl_path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Template", "控制器razor.txt");
            ctrl_template = File.ReadAllText(ctrl_path);

            var view_path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Template", "View层razor.txt");
            view_template = File.ReadAllText(view_path);

            dbschema = "easycms";
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="keyword">表名,号分割</param>
        /// <param name="zipdir">返回zip路径</param>
        /// <param name="zipname">返回zipname</param>
        /// <returns></returns>
        public string Builder(string tableName, out string zipdir, out string zipname)
        {
            var dir = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate");
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }

            StringBuilder builder = new StringBuilder();
            var tables = db.SqlQueryable<TableInfo>(string.Format(@"select table_name,table_comment from information_schema.tables where table_schema='{0}'", dbschema)).ToList();
            foreach (var tb in tableName.Split(','))
            {
                var tablecomment = tables.Find(c => c.table_name == tb).table_comment;
                var ret = RazorParse(tb, tablecomment);
                builder.Append(ret);
            }

            var srcdir = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate", "Code");
            var folders = new List<string>();
            folders.Add(srcdir);

            var zipFile = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate", "Code.zip");
            var ysret = new ZipHelper().ZipManyFilesOrDictorys(folders.AsEnumerable(), zipFile, "");

            zipdir = zipFile;
            zipname = "Code.zip";

            return builder.ToString();
        }

        public string RazorParse(string tablename, string tablecomment)
        {
            StringBuilder builder = new StringBuilder();
            var columsInfo = db.SqlQueryable<ColumnInfo>(string.Format(@"select table_name,column_name,ordinal_position,is_nullable,data_type,character_maximum_length,column_key,column_comment
                  from information_schema.COLUMNS
                 where table_schema = '{0}' and table_name = '{1}'", dbschema, tablename)).ToList();

            foreach (var item in columsInfo)
            {
                item.data_type = Utils.GetCsType(item.data_type);
                if (!item.data_type.Equals("string") && item.is_nullable.Equals("YES"))
                {
                    item.data_type = item.data_type + "?";
                }
            }

            #region entity
            var entity_result = Razor.Parse(entity_template, new
            {
                EntityNameSpace = "Ace.Entity.CMS",
                EntityName = tablename,
                Columns = columsInfo
            },"entity");

            Utils.Save(
                Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate\\Code\\Entity", $"{tablename}.cs")
                , entity_result);
            builder.Append(entity_result);
            #endregion

            #region dto
            var dto_result = Razor.Parse(dto_template, new
            {
                DtoNameSpace = "Ace.Application.CMS.Models",
                DtoName = Utils.ToCamelName(tablename) + "Info",
                Columns = columsInfo
            },"dto");
            Utils.Save(
               Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate\\Code\\Dto", $"{Utils.ToCamelName(tablename) + "Info"}.cs")
               , dto_result);
            builder.Append(dto_result);
            #endregion

            #region app
            var app_result = Razor.Parse(app_template, new
            {
                AppNameSpace = "Ace.Application.CMS.Implements",
                DtoName = Utils.ToCamelName(tablename) + "Info",
                AppClassName = Utils.ToCamelName(tablename),
                Table = tablename,
                Columns = columsInfo,
                TableComment = tablecomment,
                Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
            },"app");
            Utils.Save(
              Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate\\Code\\Implements", $"{Utils.ToCamelName(tablename) + "Service"}.cs")
              , app_result);
            builder.Append(app_result);
            #endregion

            #region Interfaces
            var appjk_result = Razor.Parse(appjk_template, new
            {
                AppNameSpace = "Ace.Application.CMS.Interfaces",
                DtoName = Utils.ToCamelName(tablename) + "Info",
                AppClassName = Utils.ToCamelName(tablename),
                Table = tablename,
                Columns = columsInfo,
                TableComment = tablecomment,
                Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
            }, "appjk");
            Utils.Save(
              Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate\\Code\\Interfaces", $"I{Utils.ToCamelName(tablename) + "Service"}.cs")
              , appjk_result);
            builder.Append(appjk_result);

            #endregion

            #region controller
            var ctrl_result = Razor.Parse(ctrl_template, new
            {
                AppClassName = Utils.ToCamelName(tablename),
                DtoName = Utils.ToCamelName(tablename) + "Info",
                TableComment = tablecomment,
                Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
            },"ctrl");
            Utils.Save(
             Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate\\Code\\Controller", $"{Utils.ToCamelName(tablename) + "Controller"}.cs")
             , ctrl_result);
            builder.Append(ctrl_result);
            #endregion

            #region view
            var view_result = Razor.Parse(view_template, new
            {
                TableName = Utils.ToCamelName(tablename).ToLower(),
                TableComment = string.IsNullOrEmpty(tablecomment) ? tablename : tablecomment,
                Columns = columsInfo,
                Status = columsInfo.Any(c => c.column_name == "status") ? 1 : 0
            }, "view");
            Utils.Save(
             Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "CodeGenerate\\Code\\View", $"{Utils.ToCamelName(tablename).ToLower()}.html")
             , view_result);
            builder.Append(view_result);
            #endregion

            return builder.ToString();
        }

        public class ColumnInfo
        {
            public string table_name { get; set; }
            public string column_name { get; set; }
            public int? ordinal_position { get; set; }
            public string is_nullable { get; set; }
            public string data_type { get; set; }
            public Int64? character_maximum_length { get; set; }
            public string column_key { get; set; }
            public string column_comment { get; set; }
        }

        public class TableInfo
        {
            public string table_name { get; set; }
            public string table_comment { get; set; }

        }
    }
}
