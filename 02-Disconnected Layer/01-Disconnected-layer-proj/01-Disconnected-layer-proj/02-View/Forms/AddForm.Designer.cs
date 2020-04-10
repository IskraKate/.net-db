namespace _01_Disconnected_layer_proj
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(8, 210);
            this.textBoxNumber.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxNumber.ReadOnly = false;
            this.textBoxNumber.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNumber_Validating);
            this.textBoxNumber.Validated += new System.EventHandler(this.textBoxNumber_Validated);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(8, 39);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxLogin.ReadOnly = false;
            this.textBoxLogin.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxLogin_Validating);
            this.textBoxLogin.Validated += new System.EventHandler(this.textBoxLogin_Validated);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(8, 154);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxAddress.ReadOnly = false;
            this.textBoxAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAddress_Validating);
            this.textBoxAddress.Validated += new System.EventHandler(this.textBoxAddress_Validated);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(8, 97);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBoxPassword.ReadOnly = false;
            this.textBoxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPassword_Validating);
            this.textBoxPassword.Validated += new System.EventHandler(this.textBoxPassword_Validated);
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.Enabled = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(255, 281);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 30);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 322);
            this.Controls.Add(this.addButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "AddForm";
            this.Text = "Add User";
            this.Controls.SetChildIndex(this.textBoxLogin, 0);
            this.Controls.SetChildIndex(this.textBoxAddress, 0);
            this.Controls.SetChildIndex(this.textBoxPassword, 0);
            this.Controls.SetChildIndex(this.textBoxNumber, 0);
            this.Controls.SetChildIndex(this.labelLogin, 0);
            this.Controls.SetChildIndex(this.labelPassword, 0);
            this.Controls.SetChildIndex(this.labelAddress, 0);
            this.Controls.SetChildIndex(this.labelTelNumber, 0);
            this.Controls.SetChildIndex(this.buttonEdit, 0);
            this.Controls.SetChildIndex(this.buttonEditted, 0);
            this.Controls.SetChildIndex(this.buttonDelete, 0);
            this.Controls.SetChildIndex(this.checkBoxAdmin, 0);
            this.Controls.SetChildIndex(this.addButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button addButton;
    }
}