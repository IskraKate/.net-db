﻿using System;

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
            this.components = new System.ComponentModel.Container();
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(16, 39);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.ReadOnly = true;
            this.textBoxLogin.Size = new System.Drawing.Size(568, 22);
            this.textBoxLogin.TabIndex = 0;
            this.textBoxLogin.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxLogin_Validating);
            this.textBoxLogin.Validated += new System.EventHandler(this.textBoxLogin_Validated);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(16, 154);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(568, 22);
            this.textBoxAddress.TabIndex = 2;
            this.textBoxAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAddress_Validating);
            this.textBoxAddress.Validated += new System.EventHandler(this.textBoxAddress_Validated);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(16, 97);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.ReadOnly = true;
            this.textBoxPassword.Size = new System.Drawing.Size(568, 22);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxPassword_MouseClick);
            this.textBoxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPassword_Validating);
            this.textBoxPassword.Validated += new System.EventHandler(this.textBoxPassword_Validated);
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(16, 210);
            this.textBoxNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.ReadOnly = true;
            this.textBoxNumber.Size = new System.Drawing.Size(568, 22);
            this.textBoxNumber.TabIndex = 3;
            this.textBoxNumber.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNumber_Validating);
            this.textBoxNumber.Validated += new System.EventHandler(this.textBoxNumber_Validated);
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
            this.labelPassword.Location = new System.Drawing.Point(13, 78);
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
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 30);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonEditted
            // 
            this.buttonEditted.Enabled = false;
            this.buttonEditted.Location = new System.Drawing.Point(621, 94);
            this.buttonEditted.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditted.Name = "buttonEditted";
            this.buttonEditted.Size = new System.Drawing.Size(75, 30);
            this.buttonEditted.TabIndex = 6;
            this.buttonEditted.Text = "Editted";
            this.buttonEditted.UseVisualStyleBackColor = true;
            this.buttonEditted.Click += new System.EventHandler(this.buttonEditted_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(621, 150);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 30);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Enabled = false;
            this.checkBoxAdmin.Location = new System.Drawing.Point(16, 246);
            this.checkBoxAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(69, 21);
            this.checkBoxAdmin.TabIndex = 4;
            this.checkBoxAdmin.Text = "Admin";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FullUserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info";
            this.Load += new System.EventHandler(this.FullUserInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}