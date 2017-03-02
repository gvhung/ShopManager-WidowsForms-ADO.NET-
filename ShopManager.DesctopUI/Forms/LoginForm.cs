using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopManager.DAL.Concrete.UnitOfWork;
using ShopManager.DAL.Abstraction.UnitOfWork;
using ShopManager.DesctopUI.ManagerBussinessClass.Concrete;
using ShopManager.Model.Entities;
using System.Configuration;
using ShopManager.DesctopUI.SellerBussinessClass.Concrete;
using Cryptography;
namespace ShopManager.DesctopUI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtLogin.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                lbLogin.ForeColor = Color.Red;
                lbPassword.ForeColor = Color.Red;
                return;
            }
            else
            {
                lbLogin.ForeColor = Color.Black;
                lbPassword.ForeColor = Color.Black;
            }
            IUnitOfWork unitOfWork;
            switch (cmbCheckUser.Text)
            {
                case "Seller":
                    lblChooseUser.ForeColor = Color.Black;
                    unitOfWork = new SellerUnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    if (Seller.SetInstance(Encryptor.Encrypt(txtLogin.Text),Encryptor.Encrypt(txtPassword.Text), (SellerUnitOfWork)unitOfWork))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        lbLogin.ForeColor = Color.Red;
                        lbPassword.ForeColor = Color.Red;
                    }
                    break;
                case "Manager":
                    lblChooseUser.ForeColor = Color.Black;
                    unitOfWork = new ManagerUnitOfWork(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    //Encryptor.Encypt(string plainText) encrypt our login and password 
                    if (Manager.SetInstance(Encryptor.Encrypt(txtLogin.Text), Encryptor.Encrypt(txtPassword.Text), (ManagerUnitOfWork)unitOfWork))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        lbLogin.ForeColor = Color.Red;
                        lbPassword.ForeColor = Color.Red;
                    }
                    break;
                default:
                    lblChooseUser.ForeColor = Color.Red;
                    break;
            }
        }

    }
}
