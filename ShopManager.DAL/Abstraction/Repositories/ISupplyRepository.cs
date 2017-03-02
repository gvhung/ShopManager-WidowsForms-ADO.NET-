using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.Model.Entities;
namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface ISupplyRepository
    {
        void AddNewSupply(IEnumerable<Supply> supplyCollection);
    }
}
