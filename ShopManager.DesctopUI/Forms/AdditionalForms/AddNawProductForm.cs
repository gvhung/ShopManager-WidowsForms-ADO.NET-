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
using ShopManager.Model.Entities;

namespace ShopManager.DesctopUI.Forms.AdditionalForms
{
    public partial class AddNawProductForm : Form
    {
        public AddNawProductForm()
        {
            InitializeComponent();
        }

        private void cmbCategory_Click(object sender, EventArgs e)
        {
            var category = Manager.Instance.UnitOfWork.StringRepository.GetCategoryNames();
            cmbCategory.DataSource = category;
        }

        private void cmbSubCategory_Click(object sender, EventArgs e)
        {
            var subCategory = Manager.Instance.UnitOfWork.StringRepository.GetSubCategoryNames(cmbCategory.Text);
            cmbSubCategory.DataSource = subCategory;
        }

        private void txbProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8))
            {
                e.KeyChar = (char)0;
            }
        }

        private void txbProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txbProductCode_Leave(object sender, EventArgs e)
        {
            if(txbProductCode.Text.Length >15 || txbProductCode.Text == string.Empty)
            {
                txbProductCode.Text = string.Empty;
                lblCode.ForeColor = Color.Red;
            }
        }

        private void txbProductName_Leave(object sender, EventArgs e)
        {
            if(txbProductName.Text.Length>50 || txbProductName.Text == string.Empty)
            {
                txbProductName.Text = string.Empty;
                lblName.ForeColor = Color.Red;
            }
        }

        private void txbProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == 8))
            {
                e.KeyChar = (char)0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool check = true;
            if(txbProductName.Text == string.Empty)
            {
                lblName.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblName.ForeColor = Color.Black;
                check = true;
            }
            if (txbProductCode.Text == string.Empty)
            {
                lblCode.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblName.ForeColor = Color.Black;
                check = true;
            }
            if (txbProductPrice.Text == string.Empty)
            {
                lblPrice.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblName.ForeColor = Color.Black;
                check = true;
            }
            if (cmbCategory.Text == string.Empty)
            {
                lblCategory.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblName.ForeColor = Color.Black;
                check = true;
            }
            if (cmbSubCategory.Text == string.Empty)
            {
                lblSubcategory.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblName.ForeColor = Color.Black;
                check = true;
            }
            if(check)
            {
                Product product = new Product()
                {
                    Name=txbProductName.Text,
                    Code=txbProductCode.Text,
                    ActualPrice = decimal.Parse(txbProductPrice.Text),
                };
                Manager.Instance.UnitOfWork.ProductRepository.AddNewProduct(product, cmbCategory.Text, cmbSubCategory.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
