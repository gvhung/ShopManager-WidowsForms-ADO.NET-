using System;
using System.Data.SqlClient;
using ShopManager.Model.Entities;


namespace ShopManager.Parser.Parsers
{
    public class EmployeeParser
    {

        private static EmployeeParser _instance;
        private EmployeeParser()
        {

        }
        public static EmployeeParser GetInstance
        {
            get
            {
                return _instance ?? (_instance = new EmployeeParser());
            }
        }

        public Employee MakeEmployeeResult(SqlDataReader reader)
        {
            var model = new Employee();
            if (reader.ColumnExists("Id"))
            {
                model.Id = reader["Id"] is DBNull
                ? Guid.Empty
                : Guid.Parse(reader["Id"].ToString());
            }

            if (reader.ColumnExists("FirstName"))
            {
                model.FirstName = reader["FirstName"] is DBNull
                ? string.Empty
                : reader["FirstName"].ToString();
            }

            if (reader.ColumnExists("LastName"))
            {
                model.LastName = reader["LastName"] is DBNull
                ? string.Empty
                : reader["LastName"].ToString();
            }

            if (reader.ColumnExists("MiddleName"))
            {
                model.MiddleName = reader["MiddleName"] is DBNull
                ? string.Empty
                : reader["MiddleName"].ToString();
            }

            if (reader.ColumnExists("Position"))
            {
                model.Pasition = reader["Position"] is DBNull
                ? string.Empty
                : reader["Position"].ToString();
            }

            if (reader.ColumnExists("Position"))
            {
                model.Pasition = reader["Position"] is DBNull
                ? string.Empty
                : reader["Position"].ToString();
            }

            if (reader.ColumnExists("Salary"))
            {
                model.Salary = reader["Salary"] is DBNull
                ? (decimal)0.0
                : (decimal.Parse(reader["Salary"].ToString()));
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
            
            if (reader.ColumnExists("Priority"))
            {
                model.Priority = reader["Priority"] is DBNull
                ? 0
                : int.Parse(reader["Priority"].ToString());
            }
            if (reader.ColumnExists("Login"))
            {
                model.Login = reader["Login"] is DBNull
                ? string.Empty
                : reader["Login"].ToString();
            }
            if (reader.ColumnExists("Password"))
            {
                model.Password = reader["Password"] is DBNull
                ? string.Empty
                : reader["Password"].ToString();
            }

            return model;
        }
    }


}
