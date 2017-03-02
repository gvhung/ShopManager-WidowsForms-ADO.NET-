using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.Model.Entities;
using ShopManager.DAL.Abstraction.Repositories;
using System.Data.SqlClient;
using ShopManager.Parser.Parsers;
namespace ShopManager.DAL.Concrete.Repositories
{
    internal class SupplierRepository:Repository<Supplier>,ISupplierRepository
    {
        public SupplierRepository(string connection):base(connection)
        {

        }

        public void AddNewSupplier(Supplier supplier)
        {

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Name", supplier.Name),
                new SqlParameter("@Phone", supplier.Phone),
                new SqlParameter("@Address", supplier.Address),
                new SqlParameter("@Mail", supplier.Mail)
            };
            ExecuteNoneQuery("sqInsertSupplier", param);
        }
        public Supplier GetSupplierByName(string name)
        {
            SqlParameter[] param = new SqlParameter[]{new SqlParameter("@Name", name),};
            return ExecuteReaderOneRow("spGetSupplierByName", SupplierParser.GetInstance.MakeSupplierResult, param);
        }
        public Supplier GetSupplierById(Guid id)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@SupplierId", id), };
            return ExecuteReaderOneRow("spGetSupplierById", SupplierParser.GetInstance.MakeSupplierResult, param);
        }
    }
}
