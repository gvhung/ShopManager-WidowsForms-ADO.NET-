namespace ShopManager.DesctopUI.Forms.AdditionalForms
{
    partial class ManagerConfirmationForm
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
            this.txtFPassword = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblFPassword = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCnacel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.Aquamarine;
            this.txtLogin.Location = new System.Drawing.Point(160, 55);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(169, 20);
            this.txtLogin.TabIndex = 0;
            // 
            // txtFPassword
            // 
            this.txtFPassword.BackColor = System.Drawing.Color.Aquamarine;
            this.txtFPassword.Location = new System.Drawing.Point(160, 82);
            this.txtFPassword.Name = "txtFPassword";
            this.txtFPassword.PasswordChar = '*';
            this.txtFPassword.Size = new System.Drawing.Size(169, 20);
            this.txtFPassword.TabIndex = 1;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(114, 58);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(40, 13);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "LOGIN";
            // 
            // lblFPassword
            // 
            this.lblFPassword.AutoSize = true;
            this.lblFPassword.Location = new System.Drawing.Point(84, 85);
            this.lblFPassword.Name = "lblFPassword";
            this.lblFPassword.Size = new System.Drawing.Size(70, 13);
            this.lblFPassword.TabIndex = 4;
            this.lblFPassword.Text = "PASSWORD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Confirm that you are realy current manager...";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConfirm.Location = new System.Drawing.Point(20, 133);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(134, 23);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCnacel
            // 
            this.btnCnacel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCnacel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCnacel.Location = new System.Drawing.Point(254, 133);
            this.btnCnacel.Name = "btnCnacel";
            this.btnCnacel.Size = new System.Drawing.Size(75, 23);
            this.btnCnacel.TabIndex = 8;
            this.btnCnacel.Text = "Cancel";
            this.btnCnacel.UseVisualStyleBackColor = false;
            // 
            // ManagerConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(353, 197);
            this.Controls.Add(this.btnCnacel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblFPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtFPassword);
            this.Controls.Add(this.txtLogin);
            this.Name = "ManagerConfirmationForm";
            this.Text = "ManagerConfirmationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtFPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblFPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCnacel;
    }
}