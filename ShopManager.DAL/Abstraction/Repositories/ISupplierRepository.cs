using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.Model.Entities;

namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface ISupplierRepository
    {
        void AddNewSupplier(Supplier suplier);
        Supplier GetSupplierByName(string name);
        Supplier GetSupplierById(Guid id);
    }
}
