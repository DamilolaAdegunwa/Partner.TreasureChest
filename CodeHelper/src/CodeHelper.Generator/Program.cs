using System;
using System.IO;
using CodeHelper.Generator.DataBaseCoders;
using CodeHelper.Generator.SimpleCoders;
using CodeHelper.Generator.Utils;
using Microsoft.Extensions.Configuration;
using RazorEngine;
using RazorEngine.Templating;

namespace CodeHelper.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Razor引擎Demo
            {
                //string template = "Hello @Model.Name, welcome to RazorEngine!";
                //var result = Engine.Razor.RunCompile(template, "templateKey", null, new { Name = "World" });
                //Console.WriteLine(result);
            }
            #endregion

            #region 简单替换
            {
                //Console.WriteLine("Hello Simple Generator!");
                //var simpleCoder = new SimpleCoder();
                //simpleCoder.Builder();
                //Console.WriteLine("See You Simple Generator!");
            }
            #endregion

            #region 数据库替换

            #region 数据库连接
            //切换数据库
            var dataBaseHelper = new DataBaseHelper();
            dataBaseHelper.Execute("use fastconnectdb;");

            {
                //执行sql语句
                //dataBaseHelper.Execute("insert into companys(name,address) values('hello world','earth');");
                //foreach (var item in dataBaseHelper.GetSqlDatas("select * from companys"))
                //{
                //    Console.WriteLine(item["Name"] + " " + item["Address"]);
                //}
            }
            {
                //获取数据库表集合
                //var tables = dataBaseHelper.GetAllTables();
                //foreach (var item in tables)
                //{
                //    Console.WriteLine(item.Name + " " + item.Comment);
                //}
            }
            {
                //获取指定数据库中的表集合
                //var tables = dataBaseHelper.GetAllTablesBySchema("fastconnectdb");
                //foreach (var item in tables)
                //{
                //    Console.WriteLine(item.Name + " " + item.Comment);
                //}
            }
            {
                //获取指定数据库中指定表下的字段集合
                //var columns = dataBaseHelper.GetAllColumnsByTable("fastconnectdb", "companys");
                //foreach (var item in columns)
                //{
                //    Console.WriteLine(item.Name + " " + item.TableName + " " + item.IsNullable + " " + item.DataType + " " + item.ColumnKey + " " + item.ColumnComment);
                //}
            }
            #endregion

            #region 模板替换
            {
                Console.WriteLine("数据库表名：");
                var tableName = Console.ReadLine();

                Console.WriteLine("实体名：");
                var entityName = Console.ReadLine();

                Console.WriteLine("实体描述：");
                var entityDescription = Console.ReadLine();

                var configurationSection = UtilHelper.GetConfigurationSection("ProjectSettings");
                var tableColumns = dataBaseHelper.GetAllColumnsByTable(configurationSection.GetSection("DataBaseName").Value, tableName);
                var entityKeyType = ColumnInfo.GetPrimaryKeyType(tableColumns);

                var templateParseModel = new TemplateParseModel()
                {
                    ProjectRootName = configurationSection.GetSection("ProjectRootName").Value,
                    ProjectNameSpace = configurationSection.GetSection("ProjectNameSpace").Value,
                    ProjectModule = configurationSection.GetSection("ProjectModule").Value,
                    EntityName = UtilHelper.ToCamelName(entityName),
                    EntityNameLower = UtilHelper.ToCamelName(entityName).ToLower(),
                    EntityDescription = entityDescription,
                    EntityKeyType = entityKeyType
                };

                var dataBaseCoder = new DataBaseCoder();
                var result = dataBaseCoder.RazorParse(templateParseModel);
                Console.Write(result);
            }
            #endregion

            #endregion

            #region 反射替换

            #endregion

            Console.Read();
        }
    }
}
