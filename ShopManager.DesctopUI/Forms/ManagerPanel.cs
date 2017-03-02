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
using MailSender;
using ShopManager.DesctopUI.Forms.AdditionalForms;

namespace ShopManager.DesctopUI.Forms
{
    public partial class ManagerPanel : Form
    {
        public ManagerPanel()
        {
            InitializeComponent();
        }

        //Allow only number in txtEmpSalary
        private void txtEmpSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            //8-backspace
            if(!(char.IsNumber(e.KeyChar)||e.KeyChar=='.'||e.KeyChar==8))
            {
                e.KeyChar = (char)0;
            }
        }
        //Allow only characters
        private void txtEmpFirsName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsLetter(e.KeyChar) || e.KeyChar==8))
            {
                e.KeyChar = (char)0;
            }
        }
        //Check if the mail addres has correct forms
        private void txtEmpMailAddress_Leave(object sender, EventArgs e)
        {
            RegexUtilities utility = new RegexUtilities();
            if(utility.IsValidEmail(txtEmpMailAddress.Text))
            {
                lblEmpMailAddress.ForeColor = Color.Black;
                return;
            }
            else
            {
                lblEmpMailAddress.ForeColor = Color.Red;
            }
        }
        //Employee registration confirmation
        private void btnEmpRegistrate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(maskEmpPhone.Text);
            bool check = true;
            if(txtEmpFirsName.Text == string.Empty)
            {
                lblEmpFName.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblEmpFName.ForeColor = Color.Black;
            }

            if(txtEmpLastName.Text == string.Empty)
            {
                lblEmpLName.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblEmpLName.ForeColor = Color.Black;
            }

            if(txtEmpMiddleName.Text == string.Empty)
            {
                lblEmpMName.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblEmpMName.ForeColor = Color.Black;
            }

            if(txtEmpPosition.Text == string.Empty)
            {
                lblPos.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblPos.ForeColor = Color.Black;
            }

            if(txtEmpSalary.Text == string.Empty)
            {
                lblPos.ForeColor = Color.Black;
                check = false;
            }
            else
            {
                lblSalary.ForeColor = Color.Black;
            }

            RegexUtilities utility = new RegexUtilities();
            if (!utility.IsValidEmail(txtEmpMailAddress.Text))
            {
                lblEmpMailAddress.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblEmpMailAddress.ForeColor = Color.Black;
            }

            if(cmbEmpPrioruty.Text == string.Empty)
            {
                lblEmpPriority.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblEmpPriority.ForeColor = Color.Black;
            }
             
            if (txtEmpAddress.Text == string.Empty)
            {
                lblEmpAddress.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblEmpAddress.ForeColor = Color.Black;
            }
            if(maskEmpPhone.Text.Length<14)
            {
                lblEmpPhone.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblEmpPhone.ForeColor = Color.Black;
            }

            //fill employee object
            if (check)
            {
                Employee emp = new Employee()
                {
                    FirstName = txtEmpFirsName.Text,
                    LastName = txtEmpLastName.Text,
                    MiddleName = txtEmpMiddleName.Text,
                    Pasition = txtEmpPosition.Text,
                    Salary = decimal.Parse(txtEmpSalary.Text),
                    Phone = maskEmpPhone.Text,
                    Address = txtEmpAddress.Text,
                    Mail = txtEmpMailAddress.Text,
                    Priority = int.Parse(cmbEmpPrioruty.Text)
                };
                EmployeeRegistrationConfirm form = new EmployeeRegistrationConfirm(emp);
                if(form.ShowDialog()==DialogResult.OK)
                {
                    MessageBox.Show("New Employee was succesuful added to data base");
                    ClearEmpRegistration();
                }
            }
        }

        private void FillEmployeeDataGrid(DataGridView dtgr,IEnumerable<Employee> collection)
        {
            foreach (var item in collection)
            {
                var arr = new string[]
                {
                   item.Id.ToString(),
                   item.FirstName,
                   item.LastName,
                   item.Pasition,
                   item.Salary.ToString(),
                   item.Phone,
                   item.Address,
                   item.Mail
                };
                dtgr.Rows.Add(arr);
            }
        }


        // Rview button event handler. Show oll registred emploies
        private void btnEmpReview_Click(object sender, EventArgs e)
        {
            FillEmployeeDataGrid(dtgrEmployee, Manager.Instance.UnitOfWork.EmployeeRepository.GetAllEmployees());
        }
        //copy text
        private void contMStrEmployee_Click(object sender, EventArgs e)
        {

        }
        //fill txtDelEmpName,txtDelEmpLName,txtDelEmpPos 
        private void txtDelEmpId_Leave(object sender, EventArgs e)
        {
            if (txtDelEmpId.Text != null)
            {
                lblDelEmpId.ForeColor = Color.Black;
               // try
               // {
                    var employee = Manager.Instance.UnitOfWork.EmployeeRepository.GetEmployeeById(Guid.Parse(txtDelEmpId.Text));
                //}
                ///catch(SystemformatEx)
                txtDelEmpName.Text = employee.FirstName;
                txtDelEmpLName.Text = employee.LastName;
                txtDelEmpPos.Text = employee.Pasition;
            }
            else
            {
                lblDelEmpId.ForeColor = Color.Red;
            }
        }

        private void btnDeletEmployee_Click(object sender, EventArgs e)
        {
            var form = new ManagerConfirmationForm();
            //check that the people that wont delete the Employee is realy current manager
            if(form.ShowDialog() == DialogResult.OK)
            {
                //
                Manager.Instance.UnitOfWork.EmployeeRepository.DeleteEmployee(Guid.Parse(txtDelEmpId.Text));
            }
        }
        //Send our message for employee
        private void btnEmpSend_Click(object sender, EventArgs e)
        {
            MessageBox.Show("None implemented");
        }

        private void FillProductDataGrid(DataGridView dtgr, IEnumerable<Product> collection)
        {
            foreach (var item in collection)
            {
                var arr = new string[]
                {
                   item.Code,
                   item.Name,
                   item.ActualPrice.ToString(),
                   item.Quontity.ToString(),
                   Manager.Instance.UnitOfWork.CategoryRepository.GetCategoryById(item.CategoryId).Name,
                   Manager.Instance.UnitOfWork.SubCategoryRepository.GetSubCategoryById(item.SubCategoryId).Name,
                };
                dtgr.Rows.Add(arr);
            }
        }
        //Review all product
        private void btnProdReview_Click(object sender, EventArgs e)
        {
            dtgrProducts.Rows.Clear();
            if(cmbProdSCatName.Text!=string.Empty)
            {
                FillProductDataGrid(dtgrProducts, Manager.Instance.UnitOfWork.ProductRepository.GetProductBySubCategory(cmbProdSCatName.Text));
                cmbProdCatName.DataSource = null;
                cmbProdSCatName.DataSource = null;
                return;
            }
            if(cmbProdCatName.Text!=string.Empty)
            {
                FillProductDataGrid(dtgrProducts, Manager.Instance.UnitOfWork.ProductRepository.GetProductByCategory(cmbProdCatName.Text));
                cmbProdCatName.DataSource = null;
                cmbProdSCatName.DataSource = null;
                return;
            }
            var products = Manager.Instance.UnitOfWork.ProductRepository.GetAllProducts();
            FillProductDataGrid(dtgrProducts, products);
          
        }

        //View Category and Subcategory
        private void btnCatTreeView_Click(object sender, EventArgs e)
        {

            CustomCategories categories = new CustomCategories();
            var dictionary = categories.CategoryDictionary;
            var count = 0;
            foreach (var i in dictionary)
            {
                var node = new TreeNode(i.Key.Name);
                treeCategory.Nodes.Add(node);
                foreach (var j in i.Value)
                {
                    var subnode = new TreeNode(j.Name);
                    treeCategory.Nodes[count].Nodes.Add(subnode);
                }
                count++;
            }
        }

        private void treeCategory_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (((TreeView)sender).SelectedNode.Level != 0)
                {


                    // TasksTree.ContextMenuStrip = null;
                }
                else
                {
                    // TasksTree.ContextMenuStrip = null;
                }
            }
        }
        //Add new product
        private void btnProdAddNewProduct_Click(object sender, EventArgs e)
        {
            var form = new AddNawProductForm();
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Add new Product");
            }
        }
        private void ClearEmpRegistration()
        {
            txtEmpFirsName.Text = string.Empty;
            txtEmpLastName.Text = string.Empty;
            txtEmpMiddleName.Text = string.Empty;
            txtEmpPosition.Text = string.Empty;
            txtEmpSalary.Text = string.Empty;
            txtEmpAddress.Text = string.Empty;
            txtEmpMailAddress.Text = string.Empty;
            maskEmpPhone.Text = string.Empty;
            cmbEmpChoose.Text=string.Empty;
        }
        //Clear
        private void btnEmpClear_Click(object sender, EventArgs e)
        {
            ClearEmpRegistration();
        }

        private void cmbProdCatName_Click(object sender, EventArgs e)
        {
            cmbProdCatName.DataSource = Manager.Instance.UnitOfWork.StringRepository.GetCategoryNames();
        }

        private void cmbProdSCatName_Click(object sender, EventArgs e)
        {
            cmbProdSCatName.DataSource = Manager.Instance.UnitOfWork.StringRepository.GetSubCategoryNames(cmbProdCatName.Text);
        }

        private void checkProdChangeCat_CheckStateChanged(object sender, EventArgs e)
        {
            if(checkProdChangeCat.Checked)
            {
                cmbProdChCat.Visible = true;
                cmbProdChSCat.Visible = true;
            }
            else
            {
                cmbProdChCat.Visible = false;
                cmbProdChSCat.Visible = false;
            }
        }

        private void txtProdCode_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("sdwe");
            AutoCompleteStringCollection productCode = new AutoCompleteStringCollection();
            productCode.AddRange(Manager.Instance.UnitOfWork.StringRepository.GetProductsCode().ToArray());
            txtProdCode.AutoCompleteCustomSource = productCode;
        }

        private void txtProdCode_Leave(object sender, EventArgs e)
        {
            if (txtProdCode.Text != string.Empty)
            {
                var product = Manager.Instance.UnitOfWork.ProductRepository.GetProductByCode(txtProdCode.Text);
                if (product != null)
                {
                     label6.ForeColor = Color.Black;
                    txtProdName.Text = product.Name;
                    txtProdPrice.Text = product.ActualPrice.ToString("0.00");
                }
                else
                {
                    label6.ForeColor = Color.Red;
                    txtProdName.Text = string.Empty;
                    txtProdPrice.Text = string.Empty;
                }
            }
            else
            {
                txtProdName.Text = string.Empty;
                txtProdPrice.Text = string.Empty;
            }
        }

        private void cmbProdChCat_Click(object sender, EventArgs e)
        {
            var category = Manager.Instance.UnitOfWork.StringRepository.GetCategoryNames();
            cmbProdChCat .DataSource = category;
        }

        private void cmbProdChSCat_Click(object sender, EventArgs e)
        {
            var subCategory = Manager.Instance.UnitOfWork.StringRepository.GetSubCategoryNames(cmbProdChCat.Text);
            cmbProdChSCat.DataSource = subCategory;
        }

        private void btnProdChange_Click(object sender, EventArgs e)
        {

            if(!checkProdChangeCat.Checked)
            {
                var product = new Product()
                {
                    Id = Manager.Instance.UnitOfWork.ProductRepository.GetProductByCode(txtProdCode.Text).Id,
                    Code = txtProdCode.Text,
                    Name = txtProdName.Text,
                    ActualPrice = decimal.Parse(txtProdPrice.Text)
                };
                Manager.Instance.UnitOfWork.ProductRepository.UpdateProduct(product);
            }
        }

        private void cmbProdDelCat1_Click(object sender, EventArgs e)
        {
            var category = Manager.Instance.UnitOfWork.StringRepository.GetCategoryNames();
            cmbProdDelCat1.DataSource = category;
        }

        private void cmbProdDelCst2_Click(object sender, EventArgs e)
        {
            var category = Manager.Instance.UnitOfWork.StringRepository.GetCategoryNames();
            cmbProdDelCst2.DataSource = category;
        }

        private void cmbProdDelSCat_Click(object sender, EventArgs e)
        {
            if (cmbProdDelCat3.Text != string.Empty)
            {
                var subCategory = Manager.Instance.UnitOfWork.StringRepository.GetSubCategoryNames(cmbProdDelCat3.Text);
                cmbProdDelSCat.DataSource = subCategory;
            }
        }

        private void cmbProdDelCat3_Click(object sender, EventArgs e)
        {
            var category = Manager.Instance.UnitOfWork.StringRepository.GetCategoryNames();
            cmbProdDelCat3.DataSource = category;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txtNewCategory.Text != string.Empty)
            {
                Manager.Instance.UnitOfWork.CategoryRepository.AddCategory(txtNewCategory.Text);
            }
        }

        private void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            if(cmbProdDelCst2.Text != string.Empty)
            {
                Manager.Instance.UnitOfWork.SubCategoryRepository.AddNewSubCategory(cmbProdDelCst2.Text, txtPodNewSubCategory.Text);
            }
        }

        private void txtAddSupplierMail_Enter(object sender, EventArgs e)
        {
            lblAddSMail.ForeColor = Color.Black;
            RegexUtilities regex = new RegexUtilities();
            if(!regex.IsValidEmail(txtAddSupplierMail.Text))
            {
                lblAddSMail.ForeColor = Color.Red;
            }
        }

        private void btnAddNewSupplier_Click(object sender, EventArgs e)
        {
            bool check = true;
            if(txtAddSupplierName.Text==string.Empty)
            {
                lblAddSpN.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblAddSpN.ForeColor = Color.Black;
            }
            if(maskAddSupplierPhone.Text == string.Empty)
            {
                lblAddSP.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblAddSP.ForeColor = Color.Black;
            }
            if(txtAddSupplierAddress.Text == string.Empty)
            {
                lblAddSupAddres.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblAddSupAddres.ForeColor = Color.Black;
            }
            RegexUtilities regex = new RegexUtilities();
            if (!regex.IsValidEmail(txtAddSupplierMail.Text))
            {
                lblAddSMail.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                lblAddSMail.ForeColor = Color.Black;
            }

            if(check)
            {
                var supplier = new Supplier()
                {
                    Name=txtAddSupplierName.Text,
                    Phone= maskAddSupplierPhone.Text,
                    Address= txtAddSupplierAddress.Text,
                    Mail= txtAddSupplierMail.Text
                };
                Manager.Instance.UnitOfWork.SupplierRepository.AddNewSupplier(supplier);
                txtAddSupplierName.Text = string.Empty;
                maskAddSupplierPhone.Text = string.Empty;
                txtAddSupplierAddress.Text = string.Empty;
                txtAddSupplierMail.Text = string.Empty;
            }
        }

        private void txtAddSupplierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == 8))
            {
                e.KeyChar = (char)0;
            }
        }

        private void cmbSupplierName_Click(object sender, EventArgs e)
        {
            var supplier = Manager.Instance.UnitOfWork.StringRepository.GetSupplierNames();
            cmbSupplierName.DataSource = supplier;
        }

        private void txtAddSupplyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)||e.KeyChar=='.'||e.KeyChar==8))
            {
                e.KeyChar = (char)0;
            }
        }



        private void btnAddSupply_Click(object sender, EventArgs e)
        {

            bool check = true;
            if (txtAddSupplyPrCode.Text == string.Empty)
            {
                //lblAddSpN.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                //lblAddSpN.ForeColor = Color.Black;
            }
            if (txtAddSupplyPrice.Text == string.Empty)
            {
                //lblAddSP.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                //lblAddSP.ForeColor = Color.Black;
            }
            if (txtAddSupplyQuontity.Text == string.Empty)
            {
                //lblAddSupAddres.ForeColor = Color.Red;
                check = false;
            }
            else
            {
                //lblAddSupAddres.ForeColor = Color.Black;
            }
            if(cmbSupplierName.Text==string.Empty)
            {
                check = false;
            }

            if(check)
            {
                var supply = new Supply()
                {
                    ProductId = Manager.Instance.UnitOfWork.ProductRepository.GetProductByCode(txtAddSupplyPrCode.Text).Id,
                    Price = decimal.Parse(txtAddSupplyPrice.Text),
                    Quantity = int.Parse(txtAddSupplyPrice.Text),
                    SupplierId = Manager.Instance.UnitOfWork.SupplierRepository.GetSupplierByName(cmbSupplierName.Text).Id
                };
                Manager.Instance.Supplies.Add(supply);
                var arr = new string[]
                {
                   Manager.Instance.UnitOfWork.ProductRepository.GetProductById(supply.ProductId).Name,
                   supply.Price.ToString(),
                   supply.Quantity.ToString(),
                   Manager.Instance.UnitOfWork.SupplierRepository.GetSupplierById(supply.SupplierId).Name
                };
                dtgrSupplies.Rows.Add(arr);
            }
            else
            {
                MessageBox.Show("Incorect data");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Manager.Instance.Supplies.Count > 0)
            {
                Manager.Instance.UnitOfWork.SupplyRepository.AddNewSupply(Manager.Instance.Supplies);
            }
            dtgrSupplies.Rows.Clear();
            Manager.Instance.Supplies = new List<Supply>();
        }

        private void txtAddSupplyPrCode_Enter(object sender, EventArgs e)
        {
            AutoCompleteStringCollection productCode = new AutoCompleteStringCollection();
            productCode.AddRange(Manager.Instance.UnitOfWork.StringRepository.GetProductsCode().ToArray());
            txtAddSupplyPrCode.AutoCompleteCustomSource = productCode;
        }

        private void txtSearchCode_Enter(object sender, EventArgs e)
        {
            AutoCompleteStringCollection productCode = new AutoCompleteStringCollection();
            productCode.AddRange(Manager.Instance.UnitOfWork.StringRepository.GetProductsCode().ToArray());
            txtSearchCode.AutoCompleteCustomSource = productCode;
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
                FillDtgrSales(Manager.Instance.UnitOfWork.SalesRepository.GetSalesByDateAndCode(searchClendar.Value.Date, txtSearchCode.Text));
                return;

            }
            if (checkByProductCode.Checked)
            {
                FillDtgrSales(Manager.Instance.UnitOfWork.SalesRepository.GetSalesByCode(txtSearchCode.Text));
                return;
            }
            if (checkByDate.Checked)
            {
                FillDtgrSales(Manager.Instance.UnitOfWork.SalesRepository.GetSalesByDate(searchClendar.Value.Date));
                return;
            }
            FillDtgrSales(Manager.Instance.UnitOfWork.SalesRepository.GetSalesAll());
            return;
        }

        private void btnDefProduct_Click(object sender, EventArgs e)
        {
            dtgrDefProducts.Rows.Clear();
            var defProd = Manager.Instance.UnitOfWork.DefectedProductRepository.GetAllDefectedProduct();
            foreach (var item in defProd)
            {
                var prod = Manager.Instance.UnitOfWork.ProductRepository.GetProductById(item.ProductId);
                DataGridViewRow row = (DataGridViewRow)dtgrDefProducts.Rows[0].Clone();
                row.Cells[0].Value = prod.Code;
                row.Cells[1].Value = prod.Name;
                row.Cells[2].Value = item.Quantity;
                row.Cells[3].Value = Manager.Instance.UnitOfWork.RealizationRepository.GetRealizationById(item.RealizationId).Income.ToString();
                dtgrDefProducts.Rows.Add(row);
            }
        }
    }
}
