using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManager.DAL.Abstraction.UnitOfWork;
using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.DAL.Concrete.Repositories;

namespace ShopManager.DAL.Concrete.UnitOfWork
{
    public class ManagerUnitOfWork:UnitOfWork,IManagerUnitOfWork
    {
        private ICategoryRepository _categoryRepository;
        private ISubCategoryRepository _subCategoryRepository;
        private IDefectedProductRepository _defectedProductRepository;
        private ISupplierRepository _supplierRepository;
        private ISupplyRepository _supplyRepository;
        public ManagerUnitOfWork(string connection):base(connection)
        {

        }
        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository(_connection)); }
        }
        public ISubCategoryRepository SubCategoryRepository
        {
            get { return _subCategoryRepository ?? (_subCategoryRepository = new SubCategoryRepository(_connection)); }
        }
        
        public ISupplierRepository SupplierRepository
        {
            get { return _supplierRepository ?? (_supplierRepository = new SupplierRepository(_connection)); }
        }
        public ISupplyRepository SupplyRepository
        {
            get { return _supplyRepository ?? (_supplyRepository = new SupplyRepository(_connection)); }
        }
        public IDefectedProductRepository DefectedProductRepository
        {
            get { return _defectedProductRepository ?? (_defectedProductRepository = new DefectedProductRepository(_connection)); }
        }
    }
}
