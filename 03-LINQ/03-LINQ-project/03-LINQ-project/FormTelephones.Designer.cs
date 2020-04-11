namespace _03_LINQ_project
{
    partial class FormTelephones
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
            System.Windows.Forms.ColumnHeader columnHeaderTelephone;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTelephones));
            this.listViewTelephones = new System.Windows.Forms.ListView();
            this.columnHeaderContact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.checkBoxCAsc = new System.Windows.Forms.CheckBox();
            this.checkBoxCDesc = new System.Windows.Forms.CheckBox();
            this.checkBoxTAsc = new System.Windows.Forms.CheckBox();
            this.checkBoxTDesc = new System.Windows.Forms.CheckBox();
            columnHeaderTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // columnHeaderTelephone
            // 
            columnHeaderTelephone.Text = "Telephone";
            columnHeaderTelephone.Width = 180;
            // 
            // listViewTelephones
            // 
            this.listViewTelephones.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listViewTelephones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewTelephones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderContact,
            columnHeaderTelephone});
            this.listViewTelephones.GridLines = true;
            this.listViewTelephones.HideSelection = false;
            this.listViewTelephones.Location = new System.Drawing.Point(12, 35);
            this.listViewTelephones.MultiSelect = false;
            this.listViewTelephones.Name = "listViewTelephones";
            this.listViewTelephones.Scrollable = false;
            this.listViewTelephones.Size = new System.Drawing.Size(373, 426);
            this.listViewTelephones.TabIndex = 0;
            this.listViewTelephones.UseCompatibleStateImageBehavior = false;
            this.listViewTelephones.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderContact
            // 
            this.columnHeaderContact.Text = "Contact";
            this.columnHeaderContact.Width = 135;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(414, 35);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(414, 64);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(414, 93);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // checkBoxCAsc
            // 
            this.checkBoxCAsc.AutoSize = true;
            this.checkBoxCAsc.Location = new System.Drawing.Point(12, 8);
            this.checkBoxCAsc.Name = "checkBoxCAsc";
            this.checkBoxCAsc.Size = new System.Drawing.Size(37, 21);
            this.checkBoxCAsc.TabIndex = 5;
            this.checkBoxCAsc.Text = "↓";
            this.checkBoxCAsc.UseVisualStyleBackColor = true;
            this.checkBoxCAsc.CheckedChanged += new System.EventHandler(this.checkBoxCAsc_CheckedChanged);
            // 
            // checkBoxCDesc
            // 
            this.checkBoxCDesc.AutoSize = true;
            this.checkBoxCDesc.Location = new System.Drawing.Point(54, 8);
            this.checkBoxCDesc.Name = "checkBoxCDesc";
            this.checkBoxCDesc.Size = new System.Drawing.Size(37, 21);
            this.checkBoxCDesc.TabIndex = 6;
            this.checkBoxCDesc.Text = "↑";
            this.checkBoxCDesc.UseVisualStyleBackColor = true;
            this.checkBoxCDesc.CheckedChanged += new System.EventHandler(this.checkBoxCDesc_CheckedChanged);
            // 
            // checkBoxTAsc
            // 
            this.checkBoxTAsc.AutoSize = true;
            this.checkBoxTAsc.Location = new System.Drawing.Point(193, 8);
            this.checkBoxTAsc.Name = "checkBoxTAsc";
            this.checkBoxTAsc.Size = new System.Drawing.Size(37, 21);
            this.checkBoxTAsc.TabIndex = 7;
            this.checkBoxTAsc.Text = "↓";
            this.checkBoxTAsc.UseVisualStyleBackColor = true;
            this.checkBoxTAsc.CheckedChanged += new System.EventHandler(this.checkBoxTAsc_CheckedChanged);
            // 
            // checkBoxTDesc
            // 
            this.checkBoxTDesc.AutoSize = true;
            this.checkBoxTDesc.Location = new System.Drawing.Point(235, 8);
            this.checkBoxTDesc.Name = "checkBoxTDesc";
            this.checkBoxTDesc.Size = new System.Drawing.Size(37, 21);
            this.checkBoxTDesc.TabIndex = 8;
            this.checkBoxTDesc.Text = "↑";
            this.checkBoxTDesc.UseVisualStyleBackColor = true;
            this.checkBoxTDesc.CheckedChanged += new System.EventHandler(this.checkBoxTDesc_CheckedChanged);
            // 
            // FormTelephones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 473);
            this.Controls.Add(this.checkBoxTDesc);
            this.Controls.Add(this.checkBoxTAsc);
            this.Controls.Add(this.checkBoxCDesc);
            this.Controls.Add(this.checkBoxCAsc);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listViewTelephones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTelephones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telephones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTelephones;
        private System.Windows.Forms.ColumnHeader columnHeaderContact;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.CheckBox checkBoxCAsc;
        private System.Windows.Forms.CheckBox checkBoxCDesc;
        private System.Windows.Forms.CheckBox checkBoxTAsc;
        private System.Windows.Forms.CheckBox checkBoxTDesc;
    }
}

