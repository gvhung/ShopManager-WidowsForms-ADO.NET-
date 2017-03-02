using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopManager.DesctopUI.ManagerBussinessClass.Concrete;
using Cryptography;
using ShopManager.Model.Entities;

namespace ShopManager.DesctopUI.Forms.AdditionalForms
{
    public partial class ManagerConfirmationForm : Form
    {
        public ManagerConfirmationForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool check = true;
            //
            if(txtLogin.Text==string.Empty)
            {
                lblLogin.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblLogin.ForeColor = Color.Black;
            }

            if(check)
            {
                var emp = Manager.Instance.UnitOfWork.EmployeeRepository.GetEmployeeById(Manager.Instance.Id);
                if(Encryptor.Encrypt(txtLogin.Text)==emp.Login && Encryptor.Encrypt(txtFPassword.Text) == emp.Password)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid data;");
                }
            }

        }
    }
}
