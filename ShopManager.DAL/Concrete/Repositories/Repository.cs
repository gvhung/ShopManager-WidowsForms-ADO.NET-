using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.DAL.Concrete.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShopManager.DAL.Concrete.Repositories
{
    internal  class Repository<TEntity>
    {
        private readonly SqlCommandWrapper _sqlWrapper;

        protected Repository(string connection)
        {
            _sqlWrapper = new SqlCommandWrapper(connection);
        }

        protected IEnumerable<TEntity> ExecuteReader(string spName, Func<SqlDataReader, TEntity> callback, SqlParameter[] parameters = null)
        {
            var result = _sqlWrapper.ExecuteReader(spName, parameters, callback);
            return (IEnumerable<TEntity>)result;
        }

        protected void ExecuteNoneQuery(string spName, SqlParameter[] parameters)
        {
            _sqlWrapper.ExecuteNoneQuery( spName, parameters);
        }

        protected TEntity ExecuteReaderOneRow(string spName, Func<SqlDataReader, TEntity> callback, SqlParameter[] parameters = null)
        {
            var result = _sqlWrapper.ExecuteReaderOneRow(spName, parameters, callback);
            return (TEntity)result;
        }

        protected IEnumerable<TEntity> ExecuteReaderWithoutParameters(string spName, Func<SqlDataReader, TEntity> callback)
        {
            var result = _sqlWrapper.ExecuteReader(spName, null, callback);
            return (IEnumerable<TEntity>)result;
        }

        protected bool ExecuteNoneQueryMoreOneRecord(string spName, IEnumerable<SqlParameter[]> parameters)
        {
            var check = _sqlWrapper.ExecuteNoneQueryMoreOneRecord(spName, parameters);
            return check;
        }
    }
}
