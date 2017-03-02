using System;
using System.Data.SqlClient;
using System.Globalization;
using ShopManager.Model.Entities;
using ShopManager.Parser;

namespace ShopManager.Parser.Parsers
{
    class ReturningParser
    {

        private static ReturningParser _instance;
        private ReturningParser()
        {

        }
        public static ReturningParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new ReturningParser());
            }
        }

        public Returning MakeReturningResult(SqlDataReader reader)
        {
            var model = new Returning();
            if (reader.ColumnExists("Id"))
            {
                model.Id = reader["Id"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["Id"].ToString());
            }

            if (reader.ColumnExists("ProductId"))
            {
                model.ProductId = reader["ProductId"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["ProductId"].ToString());
            }

            if (reader.ColumnExists("RealizationId"))
            {
                model.RealizationId = reader["RealizationId"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["RealizationId"].ToString());
            }


            if (reader.ColumnExists("EmployeeId"))
            {
                model.EmployeeId = reader["EmployeeId"] is DBNull
                ? Guid.Empty
                : Guid.Parse( reader["EmployeeId"].ToString());
            }

            if (reader.ColumnExists("Date"))
            {
                model.Date = reader["Date"] is DBNull
                ? DateTime.MaxValue
                : Convert.ToDateTime(reader["Date"], CultureInfo.CurrentCulture);
            }

            if (reader.ColumnExists("IsDefected"))
            {
                model.IsDefected = reader["IsDefected"] is DBNull
                ? false
                : Convert.ToBoolean(reader["IsDefected"], CultureInfo.CurrentCulture);
            }
            return model;

        }
    }
}
