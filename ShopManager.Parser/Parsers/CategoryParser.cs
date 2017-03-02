using System;
using System.Data.SqlClient;
using ShopManager.Model.Entities;
using ShopManager.Parser;

namespace ShopManager.Parser.Parsers
{
    public class CategoryParser
    {
        private static CategoryParser _instance;
        private CategoryParser()
        {

        }

        public static CategoryParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new CategoryParser());
            }
        }
        public Category MakeCategoryResult(SqlDataReader reader)
        {
            var model = new Category();
            if (reader.ColumnExists("Id"))
            {
                model.Id = reader["Id"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["Id"].ToString());
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
