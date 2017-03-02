using System;
using System.Collections.Generic;
using ShopManager.DesctopUI.BussinessClass.Abstractin;
using ShopManager.DesctopUI.BussinessClass.Concrete;
using ShopManager.DAL.Abstraction.UnitOfWork;
using ShopManager.Model.Entities;

namespace ShopManager.DesctopUI.ManagerBussinessClass.Concrete
{
    /// <summary>
    /// Manager class that represent manager in my program.
    /// Singleton
    /// </summary>
    internal class Manager:User,IUser
    {
        private static Manager _instance;
        private IManagerUnitOfWork _unitOfWork;
        public IList<Supply> Supplies { get; set; }
        private Manager(Guid id,string fName,string lName,string position,IManagerUnitOfWork unitOfWork)
            :base(id,fName,lName,position)
        {
            this._unitOfWork = unitOfWork;
            this.Supplies = new List<Supply>();
        }
        /// <summary>
        /// Get : Manager ooject or null ,if don`t  exist in current app domain
        /// </summary>
        public static Manager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Set Manager
        /// </summary>
        /// <param name="login">User login</param>
        /// <param name="password">User password</param>
        /// <param name="unitOfWork">An object yhat implement IUnitOfWork interface</param>
        /// <returns>false if Manager object is already consists in current app domain</returns>
        public static bool SetInstance(string login, string password, IManagerUnitOfWork unitOfWork)
        {
            if (_instance == null)
            {
                var employee = unitOfWork.EmployeeRepository.GetUserByLogin(login, password);
                if (employee != null && employee.Priority == 1)
                {
                    Manager._instance = new Manager(employee.Id, employee.FirstName, employee.LastName, employee.Pasition, unitOfWork);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Сhecks whether there is an Manager object
        /// </summary>
        /// <returns> Return true if don`t exist manager in current app domain</returns>
        public static bool IsEmpty()
        {
            return _instance == null ? true : false;
        }
        /// <summary>
        /// Ovveride Object.ToString()
        /// </summary>
        /// <returns> string that represent current manager</returns>
        public override string ToString()
        {
            return base.ToString();
        }
        public IManagerUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }
    }
}
