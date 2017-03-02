namespace ShopManager.DesctopUI.Forms.AdditionalForms
{
    partial class EmployeeRegistrationConfirm
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
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtFirstPassword = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRetPass = new System.Windows.Forms.Label();
            this.txtSecondPassword = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkSend = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtLogin.Location = new System.Drawing.Point(134, 35);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(143, 21);
            this.txtLogin.TabIndex = 0;
            // 
            // txtFirstPassword
            // 
            this.txtFirstPassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtFirstPassword.Location = new System.Drawing.Point(134, 62);
            this.txtFirstPassword.Name = "txtFirstPassword";
            this.txtFirstPassword.PasswordChar = '*';
            this.txtFirstPassword.Size = new System.Drawing.Size(143, 21);
            this.txtFirstPassword.TabIndex = 1;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(90, 38);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(38, 15);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Login";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(67, 65);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(61, 15);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkSend);
            this.groupBox1.Controls.Add(this.lblRetPass);
            this.groupBox1.Controls.Add(this.txtSecondPassword);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.lblPass);
            this.groupBox1.Controls.Add(this.lblLogin);
            this.groupBox1.Controls.Add(this.txtFirstPassword);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 161);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Confirm Registration";
            // 
            // lblRetPass
            // 
            this.lblRetPass.AutoSize = true;
            this.lblRetPass.Location = new System.Drawing.Point(27, 92);
            this.lblRetPass.Name = "lblRetPass";
            this.lblRetPass.Size = new System.Drawing.Size(101, 15);
            this.lblRetPass.TabIndex = 5;
            this.lblRetPass.Text = "Return Password";
            // 
            // txtSecondPassword
            // 
            this.txtSecondPassword.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSecondPassword.Location = new System.Drawing.Point(134, 89);
            this.txtSecondPassword.Name = "txtSecondPassword";
            this.txtSecondPassword.PasswordChar = '*';
            this.txtSecondPassword.Size = new System.Drawing.Size(143, 21);
            this.txtSecondPassword.TabIndex = 4;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConfirm.Location = new System.Drawing.Point(42, 220);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(86, 29);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(203, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // checkSend
            // 
            this.checkSend.AutoSize = true;
            this.checkSend.Location = new System.Drawing.Point(115, 126);
            this.checkSend.Name = "checkSend";
            this.checkSend.Size = new System.Drawing.Size(162, 19);
            this.checkSend.TabIndex = 6;
            this.checkSend.Text = "send information on mail";
            this.checkSend.UseVisualStyleBackColor = true;
            // 
            // EmployeeRegistrationConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(322, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmployeeRegistrationConfirm";
            this.Text = "Confirm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtFirstPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRetPass;
        private System.Windows.Forms.TextBox txtSecondPassword;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkSend;
    }
}