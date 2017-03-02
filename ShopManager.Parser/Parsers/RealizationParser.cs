using System;
using System.Data.SqlClient;
using ShopManager.Model.Entities;

namespace ShopManager.Parser.Parsers
{

    public class RealizationParser
    {

        private static RealizationParser _instance;
        private RealizationParser()
        {

        }
        public static RealizationParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new RealizationParser());
            }
        }

        public Realization MakeRealizationResult(SqlDataReader reader)
        {
            var model = new Realization();
            if (reader.ColumnExists("Id"))
            {
                model.Id = reader["Id"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["Id"].ToString());
            }

            if (reader.ColumnExists("EmployeeId"))
            {
                model.EmployeeId = reader["EmployeeId"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["EmployeeId"].ToString());
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
                : Convert.ToInt32(reader["Quantity"]);
            }

            if (reader.ColumnExists("Income"))
            {
                model.Income = reader["Income"] is DBNull
                ? (decimal)0.0
                : (decimal.Parse(reader["Income"].ToString()));
            }

            if (reader.ColumnExists("Date"))
            {
                model.Date = reader["Date"] is DBNull
                ? DateTime.MinValue
                : Convert.ToDateTime(reader["Date"].ToString());
            }
            return model;
        }
    }

}
