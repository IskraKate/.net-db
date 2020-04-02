namespace _01_Disconnected_layer_proj
{
    partial class FullUserInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullUserInfoForm));
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelTelNumber = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonEditted = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(16, 40);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.ReadOnly = true;
            this.textBoxLogin.Size = new System.Drawing.Size(568, 22);
            this.textBoxLogin.TabIndex = 0;
            this.textBoxLogin.Text = "UsersLogin";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(16, 154);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(568, 22);
            this.textBoxAddress.TabIndex = 1;
            this.textBoxAddress.Text = "UsersAddress";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(16, 97);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.ReadOnly = true;
            this.textBoxPassword.Size = new System.Drawing.Size(568, 22);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.Text = "UsersPassword";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(16, 211);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.ReadOnly = true;
            this.textBoxNumber.Size = new System.Drawing.Size(568, 22);
            this.textBoxNumber.TabIndex = 3;
            this.textBoxNumber.Text = "0123456789";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(13, 20);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(47, 17);
            this.labelLogin.TabIndex = 4;
            this.labelLogin.Text = "Login:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(13, 77);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(73, 17);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(13, 134);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(102, 17);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "Email Address:";
            // 
            // labelTelNumber
            // 
            this.labelTelNumber.AutoSize = true;
            this.labelTelNumber.Location = new System.Drawing.Point(13, 191);
            this.labelTelNumber.Name = "labelTelNumber";
            this.labelTelNumber.Size = new System.Drawing.Size(134, 17);
            this.labelTelNumber.TabIndex = 7;
            this.labelTelNumber.Text = "Telephone Number:";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(621, 36);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 30);
            this.buttonEdit.TabIndex = 8;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonEditted
            // 
            this.buttonEditted.Enabled = false;
            this.buttonEditted.Location = new System.Drawing.Point(621, 93);
            this.buttonEditted.Name = "buttonEditted";
            this.buttonEditted.Size = new System.Drawing.Size(75, 30);
            this.buttonEditted.TabIndex = 9;
            this.buttonEditted.Text = "Editted";
            this.buttonEditted.UseVisualStyleBackColor = true;
            this.buttonEditted.Click += new System.EventHandler(this.buttonEditted_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(621, 150);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 30);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Enabled = false;
            this.checkBoxAdmin.Location = new System.Drawing.Point(16, 245);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(69, 21);
            this.checkBoxAdmin.TabIndex = 11;
            this.checkBoxAdmin.Text = "Admin";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // FullUserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 278);
            this.Controls.Add(this.checkBoxAdmin);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEditted);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.labelTelNumber);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FullUserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info";
            this.Load += new System.EventHandler(this.FullUserInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox textBoxNumber;
        protected System.Windows.Forms.Label labelLogin;
        protected System.Windows.Forms.Label labelPassword;
        protected System.Windows.Forms.Label labelAddress;
        protected System.Windows.Forms.Label labelTelNumber;
        protected System.Windows.Forms.TextBox textBoxLogin;
        protected System.Windows.Forms.TextBox textBoxAddress;
        protected System.Windows.Forms.TextBox textBoxPassword;
        protected System.Windows.Forms.CheckBox checkBoxAdmin;
        protected System.Windows.Forms.Button buttonEdit;
        protected System.Windows.Forms.Button buttonEditted;
        protected System.Windows.Forms.Button buttonDelete;
    }
}