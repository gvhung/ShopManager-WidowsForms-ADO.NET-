using System;
using System.Data.SqlClient;
using System.Globalization;
using ShopManager.Model.Entities;
using ShopManager.Parser;
namespace ShopManager.Parser.Parsers
{
    public class ProductParser
    {

            private static ProductParser _instance;
            private ProductParser()
            {

            }
            public static ProductParser GetInstance
            {
                get
                {
                    return _instance ?? (_instance = new ProductParser());
                }
            }
            public Product MakeProductResult(SqlDataReader reader)
            {
                var model = new Product();
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

                if (reader.ColumnExists("Code"))
                {
                    model.Code = reader["Code"] is DBNull
                    ? string.Empty
                    : reader["Code"].ToString();
                }

                if (reader.ColumnExists("Description"))
                {
                    model.Description = reader["Description"] is DBNull
                    ? string.Empty
                    : reader["Description"].ToString();
                }

                if (reader.ColumnExists("ActualPrice"))
                {
                    model.ActualPrice = reader["ActualPrice"] is DBNull
                    ? 0
                    : Convert.ToDecimal(reader["ActualPrice"], CultureInfo.CurrentCulture);
                }
                if (reader.ColumnExists("Quantity"))
                {
                    model.Quontity = reader["Quantity"] is DBNull
                    ? 0
                    : Convert.ToDouble(reader["Quantity"], CultureInfo.CurrentCulture);
                }
                 if (reader.ColumnExists("CategoryId"))
                 {
                    model.CategoryId = reader["CategoryId"] is DBNull
                    ? Guid.Empty
                    : Guid.Parse(reader["CategoryId"].ToString());
                 }
                if (reader.ColumnExists("SubCategoryId"))
                {
                    model.SubCategoryId = reader["SubCategoryId"] is DBNull
                    ? Guid.Empty
                    : Guid.Parse(reader["SubCategoryId"].ToString());
            }

            return model;
            }
        }

}
