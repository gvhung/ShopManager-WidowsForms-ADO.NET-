using System;
using System.Data.SqlClient;
using System.Globalization;
using ShopManager.Model.Entities;
using ShopManager.Parser;

namespace ShopManager.Parser.Parsers
{
    public class SaleParser
    {

        private static SaleParser _instance;
        private SaleParser()
        {

        }
        public static SaleParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new SaleParser());
            }
        }

        public Sale MakeSaleResult(SqlDataReader reader)
        {
            var model = new Sale();
            if (reader.ColumnExists("RealizationId"))
            {
                model.RealizationId = reader["RealizationId"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["RealizationId"].ToString());
            }

            if (reader.ColumnExists("ProductCode"))
            {
                model.ProductCode = reader["ProductCode"] is DBNull
                ? string.Empty
                : reader["ProductCode"].ToString();
            }
            if (reader.ColumnExists("ProductName"))
            {
                model.ProductName = reader["ProductName"] is DBNull
                ? string.Empty
                : reader["ProductName"].ToString();
            }
            if (reader.ColumnExists("Quontity"))
            {
                model.Quontity = reader["Quontity"] is DBNull
                ? 0
                : Convert.ToInt32(reader["Quontity"], CultureInfo.CurrentCulture);
            }
            if (reader.ColumnExists("Income"))
            {
                model.Income = reader["Income"] is DBNull
                ? 0
                : Convert.ToDecimal(reader["Income"], CultureInfo.CurrentCulture);
            }
            if (reader.ColumnExists("Date"))
            {
                model.Date = reader["Date"] is DBNull
                ? DateTime.MaxValue
                : Convert.ToDateTime(reader["Date"], CultureInfo.CurrentCulture);
            }
            if (reader.ColumnExists("Seller"))
            {
                model.Seller = reader["Seller"] is DBNull
                ? string.Empty
                : reader["Seller"].ToString();
            }

            return model;
        }
    }
}
