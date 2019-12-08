using CodeHelper.Generator.Utils;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeHelper.Generator.DataBaseCoders
{
    /// <summary>
    /// 数据库辅助类
    /// </summary>
    public class DataBaseHelper
    {
        private IConfiguration configuration;
        private readonly string connectionStr;

        public DataBaseHelper()
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionStr = configuration.GetConnectionString("Default");
        }

        public void Execute(string cmd)
        {
            using (var SqlConnection = new MySqlConnection(connectionStr))
            {
                SqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(cmd, SqlConnection);
                mySqlCommand.ExecuteNonQuery();
                SqlConnection.Close();
            }
        }

        /// <summary>
        /// 查询数据库中所有表
        /// </summary>
        /// <returns></returns>
        public List<TableInfo> GetAllTables()
        {
            using (var SqlConnection = new MySqlConnection(connectionStr))
            {
                SqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("select table_name,table_comment from information_schema.tables", SqlConnection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();

                List<TableInfo> sqlDatasList = new List<TableInfo>();
                while (dataReader.Read())
                {
                    var tableInfo = new TableInfo
                    {
                        Name = dataReader[dataReader.GetName(0)].ToString(),
                        Comment = dataReader[dataReader.GetName(1)].ToString()
                    };
                    sqlDatasList.Add(tableInfo);
                }

                dataReader.Close();
                SqlConnection.Close();
                return sqlDatasList;
            }
        }

        /// <summary>
        /// 查询指定数据库中的所有表
        /// </summary>
        /// <param name="dbschema"></param>
        /// <returns></returns>
        public List<TableInfo> GetAllTablesBySchema(string dbschema)
        {
            using (var SqlConnection = new MySqlConnection(connectionStr))
            {
                SqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(string.Format("select table_name,table_comment from information_schema.tables where table_schema='{0}'", dbschema), SqlConnection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();

                List<TableInfo> sqlDatasList = new List<TableInfo>();
                while (dataReader.Read())
                {
                    var tableInfo = new TableInfo
                    {
                        Name = dataReader[dataReader.GetName(0)].ToString(),
                        Comment = dataReader[dataReader.GetName(1)].ToString()
                    };
                    sqlDatasList.Add(tableInfo);
                }

                dataReader.Close();
                SqlConnection.Close();
                return sqlDatasList;
            }
        }

        public List<ColumnInfo> GetAllColumnsByTable(string dbschema, string tablename)
        {
            using (var SqlConnection = new MySqlConnection(connectionStr))
            {
                SqlConnection.Open();
                var columsInfo = string.Format(@"select table_name,column_name,ordinal_position,is_nullable,data_type,character_maximum_length,column_key,column_comment
                    from information_schema.COLUMNS
                    where table_schema = '{0}' and table_name = '{1}'", dbschema, tablename);

                MySqlCommand mySqlCommand = new MySqlCommand(columsInfo, SqlConnection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();

                List<ColumnInfo> sqlDatasList = new List<ColumnInfo>();
                while (dataReader.Read())
                {
                    var columnInfo = new ColumnInfo()
                    {
                        TableName = dataReader[dataReader.GetName(0)].ToString(),
                        Name = dataReader[dataReader.GetName(1)].ToString(),
                        OrdinalPosition = StringExtension.GetValueOrNull<int>(dataReader[dataReader.GetName(2)].ToString()),
                        IsNullable = dataReader[dataReader.GetName(3)].ToString(),
                        DataType = dataReader[dataReader.GetName(4)].ToString(),
                        CharacterMaximumLength = StringExtension.GetValueOrNull<int>(dataReader[dataReader.GetName(2)].ToString()),
                        ColumnKey = dataReader[dataReader.GetName(6)].ToString(),
                        ColumnComment = dataReader[dataReader.GetName(7)].ToString(),
                    };
                    sqlDatasList.Add(columnInfo);
                }

                dataReader.Close();
                SqlConnection.Close();
                return sqlDatasList;
            }
        }

        public List<Dictionary<string, string>> GetSqlDatas(string cmd)
        {
            using (var SqlConnection = new MySqlConnection(connectionStr))
            {
                SqlConnection.Open();
                List<Dictionary<string, string>> sqlDatas_list = new List<Dictionary<string, string>>();
                MySqlCommand mySqlCommand = new MySqlCommand(cmd, SqlConnection);
                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Dictionary<string, string> pairs = new Dictionary<string, string>();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        pairs[dataReader.GetName(i)] = dataReader[dataReader.GetName(i)].ToString();
                    }
                    sqlDatas_list.Add(pairs);
                }
                dataReader.Close();
                SqlConnection.Close();
                return sqlDatas_list;
            }
        }
    }

    /// <summary>
    /// 数据库表中列信息
    /// </summary>
    public class ColumnInfo
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        public int? OrdinalPosition { get; set; }

        /// <summary>
        /// 是否可空
        /// </summary>
        public string IsNullable { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 字符长度
        /// </summary>
        public int? CharacterMaximumLength { get; set; }

        /// <summary>
        /// 列类型
        /// </summary>
        public string ColumnKey { get; set; }

        /// <summary>
        /// 列备注
        /// </summary>
        public string ColumnComment { get; set; }
    }

    /// <summary>
    /// 数据库表信息
    /// </summary>
    public class TableInfo
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Comment { get; set; }
    }
}
