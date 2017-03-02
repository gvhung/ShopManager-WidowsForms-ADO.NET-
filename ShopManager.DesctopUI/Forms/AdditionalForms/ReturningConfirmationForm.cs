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
using ShopManager.DAL.Concrete.UnitOfWork;
using ShopManager.DAL.Abstraction.UnitOfWork;
using System.Data.SqlClient;
namespace ShopManager.DesctopUI.Forms.AdditionalForms
{
    public partial class ReturningConfirmationForm : Form
    {
        private string _realizationId;
        private Returning _returning;
        public ReturningConfirmationForm( string realizationId)
        {
            InitializeComponent();
            this._realizationId = realizationId;
           
        }

        private void ReturningConfirmationForm_Load(object sender, EventArgs e)
        {
            Realization currentRealization = Seller.Instance.UnitOfWork.RealizationRepository.GetRealizationById(Guid.Parse(_realizationId));
            //
            _returning = new Returning()
            {
                EmployeeId = Seller.Instance.Id,
                ProductId = currentRealization.ProductId,
                RealizationId = currentRealization.Id
            };

            Product currentProduct = Seller.Instance.UnitOfWork.ProductRepository.GetProductById(currentRealization.ProductId);
            //fill text box
            txtRetRelizId.Text = currentRealization.Id.ToString();
            txtRetProdCode.Text = currentProduct.Code;
            txtRetProdName.Text = currentProduct.Name;
            txtRetQuontity.Text = currentRealization.Quantity.ToString();
            txtRetIncome.Text = currentRealization.Income.ToString();
            txtRetDate.Text = currentRealization.Date.ToString("d");
            txtRetSellerName.Text = Seller.Instance.LastName + "  " + Seller.Instance.FirstName;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _returning.IsDefected = checkIsDefected.Checked;
            try
            {
                Seller.Instance.UnitOfWork.ReturningRepository.AddNewReturning(_returning);
                MessageBox.Show("Tre returning is succesuful added!");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
