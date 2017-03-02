using System;
namespace ShopManager.DesctopUI.BussinessClass.Abstractin
{
    internal interface IUser
    {
        Guid Id { get; }
        string FirstName { get; }
        string LastName { get; }
        string Position { get; }
    }
}
