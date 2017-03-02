using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ShopManager.DAL.Abstraction.UnitOfWork;
using ShopManager.DAL.Concrete.UnitOfWork;
using Cryptography;
namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {

            var str = Encryptor.Encrypt("qwerty");
            Console.WriteLine(str);
            Console.WriteLine(Decryptor.Decrypt("BmwzQACRCmddGbSXdUJIGw=="));
        }
    }
}
