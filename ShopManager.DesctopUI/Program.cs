using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopManager.DesctopUI.Forms;
using ShopManager.DesctopUI.SellerBussinessClass.Concrete;
using ShopManager.DesctopUI.ManagerBussinessClass.Concrete;

namespace ShopManager.DesctopUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm frmLogin = new LoginForm();
            if (frmLogin.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (!Seller.IsEmpty())
            {
                Application.Run(new SellerPanel());
            }
            if(!Manager.IsEmpty())
            {
                Application.Run(new ManagerPanel());
            }
            

        }
    }
}
