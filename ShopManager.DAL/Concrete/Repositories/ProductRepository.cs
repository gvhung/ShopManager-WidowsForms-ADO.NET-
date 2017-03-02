using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.Model.Entities;
using ShopManager.Parser.Parsers;
using ShopManager.Parser;
using System.Data.SqlClient;

namespace ShopManager.DAL.Concrete.Repositories
{
    internal class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(string connection):base(connection)
        {

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return ExecuteReaderWithoutParameters("spGetAllProducts", ProductParser.GetInstance.MakeProductResult);
        }
        public Product GetProductByCode(string code)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Code", code) };
            return ExecuteReaderOneRow("spGetProductByCode", ProductParser.GetInstance.MakeProductResult,param);
        }

        public Product GetProductById(Guid id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", id) };
                return ExecuteReaderOneRow("spGetProductById", ProductParser.GetInstance.MakeProductResult, param);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void AddNewProduct(Product product,string CategoryName, string SubCategoryName)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@Code", product.Code),
                new SqlParameter("@ActualPrice", product.ActualPrice),
                new SqlParameter("@CategoryName", CategoryName),
                new SqlParameter("@SubCategoryName", SubCategoryName),
            };
            ExecuteNoneQuery("spInsertProduct", param);
        }
        public IEnumerable<Product> GetProductByCategory(string CategoryName)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CategoryName", CategoryName),
            };
            return ExecuteReader("spGetProductByCategory",ProductParser.GetInstance.MakeProductResult,param);
        }
        public IEnumerable<Product> GetProductBySubCategory(string SubCategoryName)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SubCategoryName", SubCategoryName),
            };
            return ExecuteReader("spGetProductBySubCategory", ProductParser.GetInstance.MakeProductResult, param);
        }
        public void UpdateProduct(Product product)
        {
            if(product.SubCategoryId== Guid.Empty &&product.CategoryId== Guid.Empty)
            {
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ProductId", product.Id),
                new SqlParameter("@Code", product.Code),
                new SqlParameter("@Name", product.Name),
                new SqlParameter("@ActualPrice",product.ActualPrice)
            };
                ExecuteNoneQuery("spChangeProductCNP", param);
            }
            else
            {

            }
        }
    }
}
