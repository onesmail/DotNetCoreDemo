using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    /// <summary>
    /// 工具：https://www.litedb.org/
    /// https://github.com/mbdavid/litedb
    /// </summary>
    public class LiteDBLibrary
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        public static BsonValue Add<T>(T TValue, string tableName = "")
        {
            using var db = LiteDatabaseManager.GetDataBase();
            if (string.IsNullOrWhiteSpace(tableName))
            {
                var type = typeof(T);
                tableName = type.Name;
            }
            var customers = db.GetCollection<T>(tableName);
            return customers.Insert(TValue);
        }
    }

    /// <summary>
    /// 连接管理
    /// </summary>
    public class LiteDatabaseManager
    {
        public static string ConnectionString = "MyData.db";

        public static LiteDatabase GetDataBase()
        {
            return new LiteDatabase(ConnectionString);
        }
    }
}
