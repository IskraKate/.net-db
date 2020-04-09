namespace HumanResourcesDepartment
{
    partial class FormNameList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNameList));
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.listViewNames = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(795, 91);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(136, 46);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(795, 163);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(136, 46);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // listViewNames
            // 
            this.listViewNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName});
            this.listViewNames.GridLines = true;
            this.listViewNames.HideSelection = false;
            this.listViewNames.Location = new System.Drawing.Point(12, 91);
            this.listViewNames.MultiSelect = false;
            this.listViewNames.Name = "listViewNames";
            this.listViewNames.Scrollable = false;
            this.listViewNames.Size = new System.Drawing.Size(767, 495);
            this.listViewNames.TabIndex = 7;
            this.listViewNames.UseCompatibleStateImageBehavior = false;
            this.listViewNames.View = System.Windows.Forms.View.Details;
            this.listViewNames.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewNames_MouseDoubleClick);
            // 
            // columnName
            // 
            this.columnName.Text = "";
            this.columnName.Width = 800;
            // 
            // FormNameList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 647);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listViewNames);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "FormNameList";
            this.Text = "HumanResources";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNameList_FormClosed);
            this.Load += new System.EventHandler(this.FormNameList_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ColumnHeader columnName;
        protected System.Windows.Forms.ListView listViewNames;
    }
}

