using System;
using System.Collections.Generic;
using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.Model.Entities;
using ShopManager.Parser.Parsers;
using System.Data.SqlClient;

namespace ShopManager.DAL.Concrete.Repositories
{
    internal class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(string strConnect) : base(strConnect)
        {

        }
        public Employee GetUserByLogin(string login, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Login", login),
                new SqlParameter("@Password", password)
            };
            return ExecuteReaderOneRow("spGetUserByLogin", EmployeeParser.GetInstance.MakeEmployeeResult, parameters);
        }

        public Employee GetEmployeeById(Guid id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", id) };
                return ExecuteReaderOneRow("spGetEmployeeById", EmployeeParser.GetInstance.MakeEmployeeResult, param);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void InsertEmployee(Employee emp)
        {
            SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter("@FName", emp.FirstName),
                new SqlParameter("@LName", emp.LastName),
                new SqlParameter("@MName", emp.MiddleName),
                new SqlParameter("@Position", emp.Pasition),
                new SqlParameter("@Salary", emp.Salary),
                new SqlParameter("@Phone", emp.Phone),
                new SqlParameter("@Address", emp.Address),
                new SqlParameter("@Mail", emp.Mail),
                new SqlParameter("@Login", emp.Login),
                new SqlParameter("@Password", emp.Password),
                new SqlParameter("@Priority", emp.Priority)
           };
            try
            {
                ExecuteNoneQuery("spInsertEmployee", parameters);
            }
            catch(SqlException ex)
            {
                throw ex;
            }

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return ExecuteReaderWithoutParameters("spGetAllEmployees",EmployeeParser.GetInstance.MakeEmployeeResult);
        }
        public void DeleteEmployee(Guid Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeId", Id),
            };
            ExecuteNoneQuery("spDeleteEmployee", parameters);
        }
        public void UpdateEmployee(Guid id, string newLogin, string newPassword)
        {
            SqlParameter[] parameters = new SqlParameter[]
           {
                new SqlParameter("@Id", id),
                new SqlParameter("@NewPassword", newPassword),
                new SqlParameter("@NewLogin", newLogin)
           };
            ExecuteNoneQuery("spUpdateEmployee", parameters);
        }
    }
}
