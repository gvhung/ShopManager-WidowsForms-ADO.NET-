using ShopManager.Model.Entities;
using System;
using System.Collections.Generic;

namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(Guid id);
        IEnumerable<Category> GetAllCategory();
        void AddCategory(string name);
        Category GetCategoryByName(string name);
    }
}
