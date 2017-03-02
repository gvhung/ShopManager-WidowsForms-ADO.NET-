using System;
using System.Collections.Generic;
using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.Model.Entities;
using ShopManager.Parser.Parsers;
using System.Data.SqlClient;


namespace ShopManager.DAL.Concrete.Repositories
{
    internal class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(string strConnect) : base(strConnect)
        {

        }
        public Category GetCategoryById(Guid id)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", id) };
            return ExecuteReaderOneRow("spGetCategoryById", CategoryParser.GetInstance.MakeCategoryResult,param);
        }
        public IEnumerable<Category> GetAllCategory()
        {
            return ExecuteReaderWithoutParameters("spGetAllCategory", CategoryParser.GetInstance.MakeCategoryResult);
        }
        public void AddCategory(string name)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Name", name) };
            ExecuteNoneQuery("spInsertCategory", param);
        }
        public Category GetCategoryByName(string name)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Name", name) };
            return ExecuteReaderOneRow("spGetCategoryByName",CategoryParser.GetInstance.MakeCategoryResult, param);
        }
    }
}
