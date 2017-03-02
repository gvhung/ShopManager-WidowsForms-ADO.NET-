using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ShopManager.Model.Entities;

namespace ShopManager.Parser.Parsers
{
    public class SupplyParser
    {
        private static SupplyParser _instance;
        private SupplyParser()
        {

        }

        public static SupplyParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new SupplyParser());
            }
        }
        public Supply MakeCategoryResult(SqlDataReader reader)
        {
            var model = new Supply();
            if (reader.ColumnExists("Id"))
            {
                model.Id = reader["Id"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["Id"].ToString());
            }

            if (reader.ColumnExists("Date"))
            {
                model.Date = reader["Date"] is DBNull
                ? DateTime.MaxValue
                : DateTime.Parse(reader["Date"].ToString());
            }
            if (reader.ColumnExists("Price"))
            {
                model.Price = reader["Price"] is DBNull
                ? 0.0m
                : decimal.Parse(reader["Price"].ToString());
            }
            if (reader.ColumnExists("ProductId"))
            {
                model.ProductId = reader["ProductId"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["ProductId"].ToString());
            }
            if (reader.ColumnExists("Quantity"))
            {
                model.Quantity = reader["Quantity"] is DBNull
                ? 0
                : int.Parse(reader["Quantity"].ToString());
            }
            if (reader.ColumnExists("SupplierId"))
            {
                model.SupplierId = reader["SupplierId"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["SupplierId"].ToString());
            }
            return model;
        }
    }
}
