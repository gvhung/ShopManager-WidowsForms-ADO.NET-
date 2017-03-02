using System;
using System.Data.SqlClient;
using ShopManager.Model.Entities;

namespace ShopManager.Parser.Parsers
{
   public  class SupplierParser
    {
        private static SupplierParser _instance;
        private SupplierParser()
        {

        }

        public static SupplierParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new SupplierParser());
            }
        }
        public Supplier MakeSupplierResult(SqlDataReader reader)
        {
            var model = new Supplier();
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
            if (reader.ColumnExists("Phone"))
            {
                model.Phone = reader["Phone"] is DBNull
                ? string.Empty
                : reader["Phone"].ToString();
            }
            if (reader.ColumnExists("Address"))
            {
                model.Address = reader["Address"] is DBNull
                ? string.Empty
                : reader["Address"].ToString();
            }
            if (reader.ColumnExists("Mail"))
            {
                model.Mail = reader["Mail"] is DBNull
                ? string.Empty
                : reader["Mail"].ToString();
            }
            return model;
        }
    }
}
