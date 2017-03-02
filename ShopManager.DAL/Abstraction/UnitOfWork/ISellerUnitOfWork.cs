
using ShopManager.DAL.Abstraction.Repositories;
namespace ShopManager.DAL.Abstraction.UnitOfWork
{
    public interface ISellerUnitOfWork:IUnitOfWork
    {
       
        IReturnitngRepository ReturningRepository { get; }
    }
}
