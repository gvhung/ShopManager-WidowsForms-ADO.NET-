namespace ShopManager.DesctopUI.Forms.AdditionalForms
{
    partial class AddNawProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSubcategory = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txbProductPrice = new System.Windows.Forms.TextBox();
            this.txbProductCode = new System.Windows.Forms.TextBox();
            this.txbProductName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSubcategory);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.cmbSubCategory);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.txbProductPrice);
            this.groupBox1.Controls.Add(this.txbProductCode);
            this.groupBox1.Controls.Add(this.txbProductName);
            this.groupBox1.Location = new System.Drawing.Point(45, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ADD New Product";
            // 
            // lblSubcategory
            // 
            this.lblSubcategory.AutoSize = true;
            this.lblSubcategory.Location = new System.Drawing.Point(7, 144);
            this.lblSubcategory.Name = "lblSubcategory";
            this.lblSubcategory.Size = new System.Drawing.Size(111, 13);
            this.lblSubcategory.TabIndex = 10;
            this.lblSubcategory.Text = "Product Sub Category";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(29, 117);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(89, 13);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "Product Category";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(47, 90);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(71, 13);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "Product Price";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(46, 64);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(72, 13);
            this.lblCode.TabIndex = 7;
            this.lblCode.Text = "Product Code";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(43, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Product Name";
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.Location = new System.Drawing.Point(124, 141);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(153, 21);
            this.cmbSubCategory.TabIndex = 4;
            this.cmbSubCategory.Click += new System.EventHandler(this.cmbSubCategory_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(124, 114);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(153, 21);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.Click += new System.EventHandler(this.cmbCategory_Click);
            // 
            // txbProductPrice
            // 
            this.txbProductPrice.Location = new System.Drawing.Point(124, 87);
            this.txbProductPrice.Name = "txbProductPrice";
            this.txbProductPrice.Size = new System.Drawing.Size(153, 20);
            this.txbProductPrice.TabIndex = 2;
            this.txbProductPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbProductPrice_KeyPress);
            // 
            // txbProductCode
            // 
            this.txbProductCode.Location = new System.Drawing.Point(124, 61);
            this.txbProductCode.Name = "txbProductCode";
            this.txbProductCode.Size = new System.Drawing.Size(153, 20);
            this.txbProductCode.TabIndex = 1;
            this.txbProductCode.Leave += new System.EventHandler(this.txbProductCode_Leave);
            // 
            // txbProductName
            // 
            this.txbProductName.Location = new System.Drawing.Point(124, 35);
            this.txbProductName.Name = "txbProductName";
            this.txbProductName.Size = new System.Drawing.Size(153, 20);
            this.txbProductName.TabIndex = 0;
            this.txbProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbProductName_KeyPress);
            this.txbProductName.Leave += new System.EventHandler(this.txbProductName_Leave);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(95, 249);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(221, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddNawProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 324);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddNawProductForm";
            this.Text = "AddNawProductForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbSubCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txbProductPrice;
        private System.Windows.Forms.TextBox txbProductCode;
        private System.Windows.Forms.TextBox txbProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSubcategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}