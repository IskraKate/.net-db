namespace HumanResourcesDepartment
{
    partial class FormAddPerson
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
            this.downloadPhoto = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.personPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // personContractNumber
            // 
            this.personContractNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // personDismissalNumber
            // 
            this.personDismissalNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // downloadPhoto
            // 
            this.downloadPhoto.Location = new System.Drawing.Point(34, 450);
            this.downloadPhoto.Name = "downloadPhoto";
            this.downloadPhoto.Size = new System.Drawing.Size(328, 23);
            this.downloadPhoto.TabIndex = 6;
            this.downloadPhoto.Text = "Download a photo";
            this.downloadPhoto.UseVisualStyleBackColor = true;
            this.downloadPhoto.Click += new System.EventHandler(this.downloadPhoto_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(631, 450);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(128, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // AddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.downloadPhoto);
            this.Name = "AddPerson";
            this.Text = "AddPerson";
            this.Load += new System.EventHandler(this.AddPerson_Load);
            this.Controls.SetChildIndex(this.buttonEdit, 0);
            this.Controls.SetChildIndex(this.buttonEddited, 0);
            this.Controls.SetChildIndex(this.birthadyDateTimePicker, 0);
            this.Controls.SetChildIndex(this.personPhoto, 0);
            this.Controls.SetChildIndex(this.personName, 0);
            this.Controls.SetChildIndex(this.personSurname, 0);
            this.Controls.SetChildIndex(this.personPatronymic, 0);
            this.Controls.SetChildIndex(this.personContractNumber, 0);
            this.Controls.SetChildIndex(this.personDismissalNumber, 0);
            this.Controls.SetChildIndex(this.downloadPhoto, 0);
            this.Controls.SetChildIndex(this.buttonAdd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.personPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadPhoto;
        private System.Windows.Forms.Button buttonAdd;
    }
}