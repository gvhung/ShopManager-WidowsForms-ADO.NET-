using System;
using System.Collections.Generic;
using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.Model.Entities;
using ShopManager.Parser.Parsers;
using System.Data.SqlClient;


namespace ShopManager.DAL.Concrete.Repositories
{
    internal class SubCategoryRepository:Repository<SubCategory>,ISubCategoryRepository
    {
        public SubCategoryRepository(string strConnect) : base(strConnect)
        {

        }

        public SubCategory GetSubCategoryById(Guid id)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", id) };
            return ExecuteReaderOneRow("spGetSubCategoryById", SubCategoryParser.GetInstance.MakeEmployeeResult,param);
        }

        public IEnumerable<SubCategory> GetSubCategoryByCategoryId(Guid id)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@CategoryId", id) };
            return ExecuteReader("spGetSubCategoriesByCategoryId",SubCategoryParser.GetInstance.MakeEmployeeResult,param);
        }

        public void AddNewSubCategory(string categoryName,string subCategoryName)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@CategoryName", categoryName),
                new SqlParameter("@Name", subCategoryName)
            };
            ExecuteNoneQuery("spInsertSubCategory", param);
        }
    }
}
