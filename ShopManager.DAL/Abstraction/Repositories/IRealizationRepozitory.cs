using ShopManager.Model.Entities;
using System.Collections.Generic;
using System;
namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface IRealizationRepozitory
    {
        bool AddNewRealization(IEnumerable<Realization> orders );
        Realization GetRealizationById(Guid Id);
    }
}
