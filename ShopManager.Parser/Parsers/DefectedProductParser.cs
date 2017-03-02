using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.Model.Entities;
using System.Data.SqlClient;

namespace ShopManager.Parser.Parsers
{
   public class DefectedProductParser
    {
        private static  DefectedProductParser _instance;
        private DefectedProductParser()
        {

        }

        public static DefectedProductParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new DefectedProductParser());
            }
        }
        public DefectedProduct MakeDefectedProductResult(SqlDataReader reader)
        {
            var model = new DefectedProduct();
            if (reader.ColumnExists("Id"))
            {
                model.Id= reader["Id"] is DBNull
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
            if (reader.ColumnExists("Quantity"))
            {
                model.Quantity = reader["Quantity"] is DBNull
                ? 0
                : int.Parse(reader["Quantity"].ToString());
            }
            return model;
        }
    }
}
