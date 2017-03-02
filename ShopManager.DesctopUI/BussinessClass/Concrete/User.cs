using System;
using ShopManager.DesctopUI.BussinessClass.Abstractin;

namespace ShopManager.DesctopUI.BussinessClass.Concrete
{
    internal class User : IUser
    {
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _position;

        public User(Guid id, string fName, string lName, string position)
        {
            this._id = id;
            this._firstName = fName;
            this._lastName = lName;
            this._position = position;
        }

        public Guid Id { get { return _id; } }
        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public string Position { get { return _position; } }

        public override string ToString()
        {
            return string.Format("{0} {1} :  {2}", _lastName, _firstName, _position); ;
        }
    }
}
