using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.DAL.Abstraction;
using ShopManager.DAL.Abstraction.Repositories;

namespace ShopManager.DAL.Abstraction.UnitOfWork
{
    public interface IManagerUnitOfWork:IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }

        ISupplierRepository SupplierRepository { get; }
        ISupplyRepository SupplyRepository { get; }
        IDefectedProductRepository DefectedProductRepository { get; }
    }
}
