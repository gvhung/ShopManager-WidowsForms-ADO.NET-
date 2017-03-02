using ShopManager.Model.Entities;
using System;
using System.Collections.Generic;
namespace ShopManager.DAL.Abstraction.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetUserByLogin(string login, string password);
        Employee GetEmployeeById(Guid id);
        void InsertEmployee(Employee newEmployee);
        IEnumerable<Employee> GetAllEmployees(); 
        void DeleteEmployee(Guid id);
        void UpdateEmployee(Guid id,string newLogin,string newPassword);
    }
}
