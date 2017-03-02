using ShopManager.Model.Entities;
using System.Collections.Generic;
using System;

namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetSalesByDateAndCode(DateTime searchDate , string searchProductCode );
        IEnumerable<Sale> GetSalesByCode(string searchProductCode);
        IEnumerable<Sale> GetSalesByDate(DateTime searchDate);
        IEnumerable<Sale> GetSalesAll();
    }
}
