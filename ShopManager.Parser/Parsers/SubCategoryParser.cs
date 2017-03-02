using System;
using System.Data.SqlClient;
using ShopManager.Model.Entities;
using ShopManager.Parser;

namespace ShopManager.Parser.Parsers
{
    public class SubCategoryParser
    {

        private static SubCategoryParser _instance;
        private SubCategoryParser()
        {

        }

        public static SubCategoryParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new SubCategoryParser());
            }
        }
        public SubCategory MakeEmployeeResult(SqlDataReader reader)
        {
            var model = new SubCategory();
            if (reader.ColumnExists("Id"))
            {
                model.Id = reader["Id"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["Id"].ToString());
            }

            if (reader.ColumnExists("CategoryId"))
            {
                model.CategoryId = reader["CategoryId"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["CategoryId"].ToString());
            }

            if (reader.ColumnExists("Name"))
            {
                model.Name = reader["Name"] is DBNull
                ? string.Empty
                : reader["Name"].ToString();
            }
            return model;
        }
    }
}
