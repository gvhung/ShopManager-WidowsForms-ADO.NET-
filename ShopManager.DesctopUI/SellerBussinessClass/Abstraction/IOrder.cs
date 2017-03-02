using System;
using System.Collections.Generic;
using ShopManager.Model.Entities;

namespace ShopManager.DesctopUI.SellerBussinessClass.Abstraction
{
    internal interface IOrder
    {
        bool Add(Product product, Guid empId, int quantity);
        bool Delete(Guid productCode);
        IEnumerable<Realization> ReturnRealizationList();
        bool IsEmpty();
        decimal CountTotalSum();
        void Clear();
    }
}
