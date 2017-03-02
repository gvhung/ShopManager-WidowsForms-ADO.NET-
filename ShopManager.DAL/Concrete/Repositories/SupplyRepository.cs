using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.DAL.Concrete.Repositories;
using ShopManager.Model.Entities;
using ShopManager.Parser.Parsers;
using ShopManager.DAL.Abstraction.Repositories;
using System.Data.SqlClient;
namespace ShopManager.DAL.Concrete.Repositories
{
    class SupplyRepository:Repository<Supply>,ISupplyRepository
    {
        public SupplyRepository(string connection):base(connection)
        {

        }

        public void AddNewSupply(IEnumerable<Supply> collection)
        {
            List<SqlParameter[]> parameters = new List<SqlParameter[]>();
            foreach (var item in collection)
            {
                parameters.Add(
                    new SqlParameter[]{
                        new SqlParameter("@ProductId",item.ProductId),
                        new SqlParameter("@SupplierId",item.SupplierId),
                        new SqlParameter("@Price",item.Price),
                        new SqlParameter("@Quantity",item.Quantity)
                    }
                );
            }

             ExecuteNoneQueryMoreOneRecord("spInsertSupply", parameters);
        }
    }
}
