using ShopManager.Model.Entities;
using System.Collections.Generic;

namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface IReturnitngRepository
    {
        void AddNewReturning(Returning returning);
    }
}
