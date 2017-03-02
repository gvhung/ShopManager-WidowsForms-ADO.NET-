using ShopManager.DAL.Abstraction.Repositories;

namespace ShopManager.DAL.Abstraction.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRealizationRepozitory RealizationRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IProductRepository ProductRepository { get; }
        ISaleRepository SalesRepository { get; }
        IStringRepository StringRepository { get; }
    }
}
