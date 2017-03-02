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
using ShopManager.DesctopUI.SellerBussinessClass.Concrete;
using System.Globalization;
using ShopManager.DesctopUI.Forms.AdditionalForms;
using System.Data.SqlClient;
using ShopManager.DesctopUI.SellerBussinessClass.Abstraction;
using Cryptography;

namespace ShopManager.DesctopUI.Forms
{
    public partial class SellerPanel : Form
    {
        private string _specifier = "0.00";
        public SellerPanel()
        {
            InitializeComponent();

        }
        


        private void SellerPanel_Load(object sender, EventArgs e)
        {
            //for change login current user
            txtOldLogin.Text = Cryptography.Decryptor.Decrypt( Seller.Instance.UnitOfWork.EmployeeRepository.GetEmployeeById(Seller.Instance.Id).Login);
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            if(txtProductCode.Text!=string.Empty)
            {
                var product = Seller.Instance.UnitOfWork.ProductRepository.GetProductByCode(txtProductCode.Text);
                if(product!=null)
                {
                    lblCode.ForeColor = Color.Black;
                    txtProductName.Text = product.Name;
                    txtProductPice.Text = product.ActualPrice.ToString(_specifier, CultureInfo.CurrentUICulture);
                }
                else
                {
                    lblCode.ForeColor = Color.Red;
                    txtProductName.Text = string.Empty;
                    txtProductPice.Text = string.Empty;
                }
            }
            else
            {
                txtProductName.Text = string.Empty;
                txtProductPice.Text = string.Empty;
            }
        }

        private void txtQuontity_Leave(object sender, EventArgs e)
        {
            if (txtProductCode.Text != string.Empty)
            {
                lblCode.ForeColor = Color.Black;
                if (txtQuontity.Text != string.Empty && int.Parse(txtQuontity.Text) <= Seller.Instance.UnitOfWork.ProductRepository.GetProductByCode(txtProductCode.Text).Quontity)
                {
                    lblQuontity.ForeColor = Color.Black;
                    txtTotalCost.Text = (decimal.Parse(txtProductPice.Text, CultureInfo.CurrentUICulture) *
                                            decimal.Parse(txtQuontity.Text, CultureInfo.CurrentUICulture)).ToString();
                }
                else
                {
                    lblQuontity.ForeColor = Color.Red;
                }
            }
            else
            {
                lblCode.ForeColor = Color.Red;
            }
        }

        private void FillDtgrOrdersList(Product product)
        {
            string[] arr = new string[]
            {
                product.Code.ToString(), product.Name,
                product.ActualPrice.ToString(_specifier, CultureInfo.CurrentUICulture),
                txtQuontity.Text, txtTotalCost.Text
            };
            dtgrOrdersList.Rows.Add(arr);
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (txtQuontity.Text != string.Empty)
            {
                Product product = Seller.Instance.UnitOfWork.ProductRepository.GetProductByCode(txtProductCode.Text);
                if (product!=null)
                {
                    Seller.Instance.AddToOrder(product, int.Parse(txtQuontity.Text));
                    FillDtgrOrdersList(product);
                    txtTotalSum.Text = Seller.Instance.Order.CountTotalSum().ToString();
                    //Clear
                    txtProductCode.Text = string.Empty;
                    txtProductName.Text = string.Empty;
                    txtProductPice.Text = string.Empty;
                    txtTotalCost.Text = string.Empty;
                    txtQuontity.Text = string.Empty;
                }
                else
                {
                    lblCode.ForeColor = Color.Red;
                    MessageBox.Show("Can add to order");
                }
            }
            else
            {
                lblQuontity.ForeColor = Color.Red;
            }
        }

        private void btnSavePaiment_Click(object sender, EventArgs e)
        {
            if (!Seller.Instance.Order.IsEmpty())
            {
                
                Seller.Instance.UnitOfWork.RealizationRepository.AddNewRealization(Seller.Instance.Order.ReturnRealizationList());

            }
            else
            {
                MessageBox.Show("Oreders list is empty");
            }
            //Clear
            Seller.Instance.Order.Clear();
            dtgrOrdersList.Rows.Clear();
            txtTotalSum.Text = string.Empty;
        }

        private void btnDelLast_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FillDtgrSales(IEnumerable<Sale> sales)
        {
            foreach (var item in sales)
            {
                DataGridViewRow row = (DataGridViewRow)dtgrSales.Rows[0].Clone();
                row.Cells[0].Value = item.RealizationId;
                row.Cells[1].Value = item.ProductCode;
                row.Cells[2].Value = item.ProductName;
                row.Cells[3].Value = item.Quontity;
                row.Cells[4].Value = item.Income;
                row.Cells[5].Value = item.Date;
                row.Cells[6].Value = item.Seller;
                dtgrSales.Rows.Add(row);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtgrSales.Rows.Clear();
            if (checkByDate.Checked && checkByProductCode.Checked)
            {
                FillDtgrSales(Seller.Instance.UnitOfWork.SalesRepository.GetSalesByDateAndCode(searchClendar.Value.Date, txtSearchCode.Text));
                return;
                
            }
            if(checkByProductCode.Checked)
            {
                FillDtgrSales(Seller.Instance.UnitOfWork.SalesRepository.GetSalesByCode(txtSearchCode.Text));
                return;
            }
            if(checkByDate.Checked)
            {
                FillDtgrSales(Seller.Instance.UnitOfWork.SalesRepository.GetSalesByDate(searchClendar.Value.Date));
                return;
            }
            FillDtgrSales(Seller.Instance.UnitOfWork.SalesRepository.GetSalesAll());
            return;
        }

        //Add Intelisance to txtProductCode 
        private void txtProductCode_Enter(object sender, EventArgs e)
        {
            AutoCompleteStringCollection productCode = new AutoCompleteStringCollection();
            productCode.AddRange(Seller.Instance.UnitOfWork.StringRepository.GetProductsCode().ToArray());
            txtProductCode.AutoCompleteCustomSource = productCode;
        }
        //Add Intelisance to txtProductCode 
        private void txtSearchCode_Enter(object sender, EventArgs e)
        {
            AutoCompleteStringCollection productCode = new AutoCompleteStringCollection();
            productCode.AddRange(Seller.Instance.UnitOfWork.StringRepository.GetProductsCode().ToArray());
            txtSearchCode.AutoCompleteCustomSource = productCode;
        }

        private void txtRetRelizId_Leave(object sender, EventArgs e)
        {
            if(txtRetRelizId.Text != string.Empty)
            {
                try
                {
                    Realization reliz = Seller.Instance.UnitOfWork.RealizationRepository.GetRealizationById(Guid.Parse(txtRetRelizId.Text));
                    txtRetQuontity.Text = reliz.Quantity.ToString();
                    txtRetIncome.Text = reliz.Income.ToString(_specifier, CultureInfo.CurrentUICulture);
                    txtRetDate.Text = reliz.Date.ToString("d");
                    Product product = Seller.Instance.UnitOfWork.ProductRepository.GetProductById(reliz.ProductId);
                    txtRetProdCode.Text = product.Code;
                    txtRetProdName.Text = product.Name;
                    Employee emp = Seller.Instance.UnitOfWork.EmployeeRepository.GetEmployeeById(reliz.EmployeeId);
                    txtRetSellerName.Text = emp.LastName + emp.FirstName;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Number.ToString()+":"+ex.Message);
                }
            }
            else
            {

            }
        }

        private void btnConfirmReturning_Click(object sender, EventArgs e)
        {
            if (txtRetRelizId.Text != null)
            {
                txtRetRelizId.ForeColor = Color.Black;
                ReturningConfirmationForm frm = new ReturningConfirmationForm(txtRetRelizId.Text);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {

                }
            }
            else
            {
                txtRetRelizId.ForeColor = Color.Red;
            }
        }

        private void txtProductPice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-backspace
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8))
            {
                e.KeyChar = (char)0;
            }
        }

        private void txtQuontity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-backspace
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8))
            {
                e.KeyChar = (char)0;
            }
        }

        private void btnChangeUserInfConfirm_Click(object sender, EventArgs e)
        {
            if(Seller.Instance.UnitOfWork.EmployeeRepository.GetUserByLogin(Encryptor.Encrypt(txtOldLogin.Text), Encryptor.Encrypt(txtOldPassword.Text))!=null)
            {
                if(txtNewPassword.Text==txtRepeatPassword.Text)
                {
                    Seller.Instance.UnitOfWork.EmployeeRepository.UpdateEmployee(Seller.Instance.Id, Encryptor.Encrypt(txtNewLogin.Text), Encryptor.Encrypt(txtNewPassword.Text));
                    MessageBox.Show("Change login and password ");
                }
            }
        }
    }
}
