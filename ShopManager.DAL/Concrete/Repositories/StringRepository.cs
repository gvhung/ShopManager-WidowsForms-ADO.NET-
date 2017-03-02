using System;
using ShopManager.DAL.Abstraction.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShopManager.DAL.Concrete.Repositories
{
    class StringRepository:Repository<String>,IStringRepository
    {
        public StringRepository(string connection):base(connection)
        {

        }

        public IEnumerable<string> GetProductsCode()
        {
            return ExecuteReader("spGetAllProductsCode", reader => { return reader["Code"] is DBNull?string.Empty:reader["Code"].ToString();});
        }

        public IEnumerable<String> GetCategoryNames()
        {
            return ExecuteReader("spGetAllCategoryName", reader => { return reader["Name"] is DBNull ? string.Empty : reader["Name"].ToString(); });
        }
        public IEnumerable<String> GetSubCategoryNames(string CategoryName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@CategoryName",CategoryName)
            };
            return ExecuteReader("spGetAllSubCategoryName", reader => { return reader["Name"] is DBNull ? string.Empty : reader["Name"].ToString();},parameters);
        }
        public IEnumerable<String> GetSupplierNames()
        {
            return ExecuteReader("spGetAllSupplierName", reader => { return reader["Name"] is DBNull ? string.Empty : reader["Name"].ToString(); });
        }
    }
}
