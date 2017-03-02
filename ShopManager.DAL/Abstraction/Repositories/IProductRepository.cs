using ShopManager.Model.Entities;
using System.Collections.Generic;
using System;

namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductByCode(string code);
        Product GetProductById(Guid id);
        IEnumerable<Product> GetProductByCategory(string CategoryName);
        IEnumerable<Product> GetProductBySubCategory(string SubCategoryName);
        void AddNewProduct(Product product,string CategoryName,string SubCategoryName);
        void UpdateProduct(Product product);
    }
}
