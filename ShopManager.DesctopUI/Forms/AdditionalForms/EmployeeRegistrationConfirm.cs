using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopManager.Model.Entities;
using Cryptography;
using ShopManager.DesctopUI.ManagerBussinessClass.Concrete;
using System.Data.SqlClient;

namespace ShopManager.DesctopUI.Forms.AdditionalForms
{
    public partial class EmployeeRegistrationConfirm : Form
    {
        Employee _emp;
        public EmployeeRegistrationConfirm(Employee emp)
        {
            InitializeComponent();
            this._emp = emp;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool check = true;
            if(txtLogin.Text == string.Empty)
            {
                lblLogin.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblLogin.ForeColor = Color.Black;
            }

            if(txtFirstPassword.Text == string.Empty)
            {
                lblPass.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblPass.ForeColor = Color.Black;
            }

            if (txtSecondPassword.Text == string.Empty)
            {
                lblRetPass.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblRetPass.ForeColor = Color.Black;
            }

            if(txtFirstPassword.Text != txtSecondPassword.Text)
            {
                check = false;
                MessageBox.Show("Invalid password!!!");
            }

            if(check)
            {
                //Crypt login and password
                _emp.Login = Encryptor.Encrypt(txtLogin.Text);
                _emp.Password = Encryptor.Encrypt(txtFirstPassword.Text);
                try
                {
                    Manager.Instance.UnitOfWork.EmployeeRepository.InsertEmployee(_emp);
                    //if user syccesuful added to data base , sednd his login and pasword on mail

                    //string mail = "shopmanagerdef@gmail.com";
                    //string password = "epam2016";
                    //MailSender.MailSender.SendMail("smtp.gmail.com", mail, password, txtEmpMailAddress.Text, "Welcome", "Welcome to shop system");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //Manager.Instance
        }
    }
}
