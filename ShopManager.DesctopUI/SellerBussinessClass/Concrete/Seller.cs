using System;
using ShopManager.DesctopUI.BussinessClass.Abstractin;
using ShopManager.DesctopUI.BussinessClass.Concrete;
using ShopManager.DesctopUI.SellerBussinessClass.Abstraction;
using ShopManager.DAL.Abstraction.UnitOfWork;
using ShopManager.Model.Entities;

namespace ShopManager.DesctopUI.SellerBussinessClass.Concrete
{
    internal class Seller:User,IUser
    {
        private IOrder _order;
        private ISellerUnitOfWork _unitOfWork;
        private static Seller _instance;

        private Seller(Guid id, string fName, string lName, string position, ISellerUnitOfWork unitOfwork)
           : base(id, fName, lName, position)
        {
            this._order = new Order();
            this._unitOfWork = unitOfwork;
        }

        public ISellerUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public IOrder Order
        {
            get
            {
                return _order;
            }
        }

        public bool AddToOrder(Product product,int quontity)
        {
 
           return _order.Add(product, Id, quontity);
        }

        public static Seller Instance
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


        public static bool SetInstance(string login,string password,ISellerUnitOfWork unitOfWork)
        {
            if (_instance == null)
            {
                var employee = unitOfWork.EmployeeRepository.GetUserByLogin(login, password);
                if (employee!=null && employee.Priority == 2)
                {
                    Seller._instance = new Seller(employee.Id, employee.FirstName, employee.LastName, employee.Pasition,unitOfWork);
                    return true;
                }
            }
            return false;
        }

        public static bool IsEmpty()
        {
            return _instance == null ? true : false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
