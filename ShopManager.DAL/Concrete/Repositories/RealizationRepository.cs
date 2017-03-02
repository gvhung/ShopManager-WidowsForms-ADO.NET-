using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.Model.Entities;
using System.Data.SqlClient;
using ShopManager.Parser.Parsers;
using System.Data;

namespace ShopManager.DAL.Concrete.Repositories
{
    class RealizationRepository:Repository<Realization>,IRealizationRepozitory
    {
        public RealizationRepository(string connection):base (connection)
        {

        }

        //Add range of orders
        public bool AddNewRealization(IEnumerable<Realization> orders)
        {
            List<SqlParameter[]> parameters = new List<SqlParameter[]>();
            foreach(var item in orders)
            {
                parameters.Add( 
                    new SqlParameter[]{
                        new SqlParameter("@EmployeeId",item.EmployeeId),
                        new SqlParameter("@ProductId",item.ProductId),
                        new SqlParameter("@Quantity",item.Quantity),
                        new SqlParameter("@Income",item.Income)
                    }
                );
            }

            return ExecuteNoneQueryMoreOneRecord("spInsertRealization", parameters);
        }

        public Realization GetRealizationById(Guid id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", id) };
                return ExecuteReaderOneRow("spGetRealizationById", RealizationParser.GetInstance.MakeRealizationResult, param);
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }
    }
}
