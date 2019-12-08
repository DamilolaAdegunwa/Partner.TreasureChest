using System;
using CodeHelper.Generator.DataBaseCoders;
using CodeHelper.Generator.SimpleCoders;

namespace CodeHelper.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 简单替换
            //Console.WriteLine("Hello Simple Generator!");
            //var simpleCoder = new SimpleCoder();
            //simpleCoder.Builder();
            //Console.WriteLine("See You Simple Generator!");
            #endregion

            #region 数据库替换

            #region 数据库连接
            var dataBaseHelper = new DataBaseHelper();
            dataBaseHelper.Execute("use fastconnectdb;");
            {
                //dataBaseHelper.Execute("insert into companys(name,address) values('hello world','earth');");
                //foreach (var item in dataBaseHelper.GetSqlDatas("select * from companys"))
                //{
                //    Console.WriteLine(item["Name"] + " " + item["Address"]);
                //}
            }
            //{
            //    var tables = dataBaseHelper.GetAllTables();
            //    foreach (var item in tables)
            //    {
            //        Console.WriteLine(item.Name + " " + item.Comment);
            //    }
            //}
            {
                var tables = dataBaseHelper.GetAllTablesBySchema("fastconnectdb");
                foreach (var item in tables)
                {
                    Console.WriteLine(item.Name + " " + item.Comment);
                }
            }
            {
                var columns = dataBaseHelper.GetAllColumnsByTable("fastconnectdb", "companys");
                foreach (var item in columns)
                {
                    Console.WriteLine(item.Name + " " + item.TableName + " " + item.IsNullable + " " + item.DataType);
                }
            }
            #endregion

            #region 模板替换
            var dataBaseCoder = new DataBaseCoder();
            var result = dataBaseCoder.RazorParse("company");
            Console.Write(result);
            #endregion

            #endregion

            #region 反射替换

            #endregion

            Console.Read();
        }
    }
}
