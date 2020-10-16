
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Aaron.SDK.T4.MySql
{
    public class SystemDBContext : IDisposable
    {
        private string _connectionString;
        private IDbConnection _dbConnection = null;
        public void Dispose()
        {
            _dbConnection?.Close();
            _dbConnection?.Dispose();
        }
        public SystemDBContext(string ConnectionString)
        {
            this._connectionString = ConnectionString;
        }
        /// <summary>
        /// 返回连接实例
        /// </summary>

        /// <summary>
        /// 创建数据库连接对象并打开链接
        /// </summary>
        /// <returns></returns>
        public IDbConnection Db
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new MySqlConnection(_connectionString);
                }
                //判断连接状态
                if (_dbConnection.State == ConnectionState.Closed)
                {
                    _dbConnection.Open();
                }
                return _dbConnection;
            }

        }




        /// <summary>
        /// 查出一条记录的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T Find<T>(string sql, object param = null)
        {
            return Db.QueryFirstOrDefault<T>(sql, param);
        }

        /// <summary>
        /// 查出多条记录的实体泛型集合
        /// </summary>
        /// <typeparam name="T">泛型T</typeparam>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Db.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }
    }
}
