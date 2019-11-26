using SqlSugar;

namespace CMS.Tool.WebApi.Models.Base
{
    public class DbService
    {
        private SqlSugarClient _sqlsugarClient;
        public SqlSugarClient db
        {
            get
            {
                if (_sqlsugarClient == null)
                {
                    var conn = System.Web.Configuration.WebConfigurationManager.AppSettings["connstr"];
                    var db = new SqlSugarClient(
                    new ConnectionConfig()
                    {
                        ConnectionString = conn,
                        DbType = DbType.MySql,
                        IsAutoCloseConnection = true
                    });
                    _sqlsugarClient = db;
                }
                return _sqlsugarClient;
            }
        }
    }
}