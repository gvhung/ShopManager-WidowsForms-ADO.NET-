using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.Model.Entities;
using ShopManager.DAL.Abstraction.Repositories;
using System.Data.SqlClient;

namespace ShopManager.DAL.Concrete.Repositories
{
    internal class ReturningRepository:Repository<Returning>,IReturnitngRepository
    {
        public ReturningRepository(string connection):base(connection)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returning"></param>
        public void AddNewReturning(Returning returning)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId", returning.ProductId),
                new SqlParameter("@RealizationId", returning.RealizationId),
                new SqlParameter("@EmployeeId",returning.EmployeeId),
                new SqlParameter("@IsDefect",returning.IsDefected)
            };
            try
            {
                ExecuteNoneQuery("spInsertReturning", parameters);
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
