using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.Model.Entities;
using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.Parser.Parsers;

namespace ShopManager.DAL.Concrete.Repositories
{
    internal class DefectedProductRepository:Repository<DefectedProduct>,IDefectedProductRepository
    {
        public DefectedProductRepository(string connection):base(connection)
        {

        }
        public IEnumerable<DefectedProduct> GetAllDefectedProduct()
        {
            return ExecuteReaderWithoutParameters("spGetAllDefectedProduct", DefectedProductParser.GetInstance.MakeDefectedProductResult);
        }
    }
}
