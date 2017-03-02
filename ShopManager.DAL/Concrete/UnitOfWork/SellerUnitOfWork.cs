using ShopManager.DAL.Abstraction.UnitOfWork;
using ShopManager.DAL.Abstraction.Repositories;
using ShopManager.DAL.Concrete.Repositories;
namespace ShopManager.DAL.Concrete.UnitOfWork
{
   public class SellerUnitOfWork:UnitOfWork,ISellerUnitOfWork
    {
        
      
        private IReturnitngRepository _returningRepository;
        public  SellerUnitOfWork(string connection):base(connection)
        {

        }

        public IReturnitngRepository ReturningRepository
        {
            get { return _returningRepository ?? (_returningRepository = new ReturningRepository(_connection)); }
        }
    }
}
