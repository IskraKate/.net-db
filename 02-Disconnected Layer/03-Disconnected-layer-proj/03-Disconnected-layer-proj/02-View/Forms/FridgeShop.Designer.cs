namespace _03_Disconnected_layer_proj
{
    partial class FridgeShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FridgeShop));
            this.AddCheckButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.listViewCheck = new System.Windows.Forms.ListView();
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBrand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBuyer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSeller = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // AddCheckButton
            // 
            this.AddCheckButton.Location = new System.Drawing.Point(524, 36);
            this.AddCheckButton.Name = "AddCheckButton";
            this.AddCheckButton.Size = new System.Drawing.Size(84, 23);
            this.AddCheckButton.TabIndex = 1;
            this.AddCheckButton.Text = "Add Check";
            this.AddCheckButton.UseVisualStyleBackColor = true;
            this.AddCheckButton.Click += new System.EventHandler(this.AddRecieptButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(524, 93);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(84, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save to XML";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(524, 64);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(84, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // listViewCheck
            // 
            this.listViewCheck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumber,
            this.columnHeaderDate,
            this.columnHeaderBrand,
            this.columnHeaderBuyer,
            this.columnHeaderSeller});
            this.listViewCheck.HideSelection = false;
            this.listViewCheck.Location = new System.Drawing.Point(9, 36);
            this.listViewCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewCheck.MultiSelect = false;
            this.listViewCheck.Name = "listViewCheck";
            this.listViewCheck.Scrollable = false;
            this.listViewCheck.Size = new System.Drawing.Size(510, 299);
            this.listViewCheck.TabIndex = 5;
            this.listViewCheck.UseCompatibleStateImageBehavior = false;
            this.listViewCheck.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "Number";
            this.columnHeaderNumber.Width = 100;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Date";
            this.columnHeaderDate.Width = 100;
            // 
            // columnHeaderBrand
            // 
            this.columnHeaderBrand.Text = "Brand";
            this.columnHeaderBrand.Width = 100;
            // 
            // columnHeaderBuyer
            // 
            this.columnHeaderBuyer.Text = "Buyer";
            this.columnHeaderBuyer.Width = 100;
            // 
            // columnHeaderSeller
            // 
            this.columnHeaderSeller.Text = "Seller";
            this.columnHeaderSeller.Width = 100;
            // 
            // FridgeShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 345);
            this.Controls.Add(this.listViewCheck);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddCheckButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FridgeShop";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FridgeShop";
            this.Load += new System.EventHandler(this.FridgeShop_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddCheckButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ListView listViewCheck;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderBrand;
        private System.Windows.Forms.ColumnHeader columnHeaderBuyer;
        private System.Windows.Forms.ColumnHeader columnHeaderSeller;
    }
}

