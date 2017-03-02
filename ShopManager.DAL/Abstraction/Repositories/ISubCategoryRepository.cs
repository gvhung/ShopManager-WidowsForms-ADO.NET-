using ShopManager.Model.Entities;
using System;
using System.Collections.Generic;

namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface ISubCategoryRepository
    {
        SubCategory GetSubCategoryById(Guid id);
        IEnumerable<SubCategory> GetSubCategoryByCategoryId(Guid id);
        void AddNewSubCategory(string categoryName, string subCategoryName);
    }
}
