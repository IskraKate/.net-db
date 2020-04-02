namespace _01_Disconnected_layer_proj
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.checkBoxAdminShower = new System.Windows.Forms.CheckBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.ItemHeight = 16;
            this.listBoxUsers.Location = new System.Drawing.Point(12, 43);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.ScrollAlwaysVisible = true;
            this.listBoxUsers.Size = new System.Drawing.Size(396, 354);
            this.listBoxUsers.Sorted = true;
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxUsers_MouseDoubleClick);
            // 
            // checkBoxAdminShower
            // 
            this.checkBoxAdminShower.AutoSize = true;
            this.checkBoxAdminShower.Location = new System.Drawing.Point(12, 12);
            this.checkBoxAdminShower.Name = "checkBoxAdminShower";
            this.checkBoxAdminShower.Size = new System.Drawing.Size(110, 21);
            this.checkBoxAdminShower.TabIndex = 1;
            this.checkBoxAdminShower.Text = "ShowAdmins";
            this.checkBoxAdminShower.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(333, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 419);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.checkBoxAdminShower);
            this.Controls.Add(this.listBoxUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.CheckBox checkBoxAdminShower;
        private System.Windows.Forms.Button buttonAdd;
    }
}

