using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface IStringRepository
    {
        IEnumerable<String> GetProductsCode();
        IEnumerable<String> GetCategoryNames();
        IEnumerable<String> GetSubCategoryNames(string CategoryName);
        IEnumerable<String> GetSupplierNames();
    }
}
