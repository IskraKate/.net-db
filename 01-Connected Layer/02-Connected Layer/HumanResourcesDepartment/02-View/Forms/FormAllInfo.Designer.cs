namespace HumanResourcesDepartment
{
    partial class FormAllInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAllInfo));
            this.personName = new System.Windows.Forms.TextBox();
            this.personPhoto = new System.Windows.Forms.PictureBox();
            this.personSurname = new System.Windows.Forms.TextBox();
            this.personPatronymic = new System.Windows.Forms.TextBox();
            this.personContractNumber = new System.Windows.Forms.TextBox();
            this.personDismissalNumber = new System.Windows.Forms.TextBox();
            this.birthadyDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NameLable = new System.Windows.Forms.Label();
            this.surnameLable = new System.Windows.Forms.Label();
            this.PatronymicLabel = new System.Windows.Forms.Label();
            this.contractNumberLabel = new System.Windows.Forms.Label();
            this.dismissalNumberLabel = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonEddited = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.personPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // personName
            // 
            this.personName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.personName.Location = new System.Drawing.Point(433, 50);
            this.personName.Name = "personName";
            this.personName.ReadOnly = true;
            this.personName.Size = new System.Drawing.Size(336, 22);
            this.personName.TabIndex = 0;
            // 
            // personPhoto
            // 
            this.personPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.personPhoto.Location = new System.Drawing.Point(34, 50);
            this.personPhoto.Name = "personPhoto";
            this.personPhoto.Size = new System.Drawing.Size(328, 361);
            this.personPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.personPhoto.TabIndex = 1;
            this.personPhoto.TabStop = false;
            // 
            // personSurname
            // 
            this.personSurname.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.personSurname.Location = new System.Drawing.Point(433, 101);
            this.personSurname.Name = "personSurname";
            this.personSurname.ReadOnly = true;
            this.personSurname.Size = new System.Drawing.Size(336, 22);
            this.personSurname.TabIndex = 2;
            // 
            // personPatronymic
            // 
            this.personPatronymic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.personPatronymic.Location = new System.Drawing.Point(433, 152);
            this.personPatronymic.Name = "personPatronymic";
            this.personPatronymic.ReadOnly = true;
            this.personPatronymic.Size = new System.Drawing.Size(336, 22);
            this.personPatronymic.TabIndex = 3;
            // 
            // personContractNumber
            // 
            this.personContractNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.personContractNumber.Location = new System.Drawing.Point(433, 203);
            this.personContractNumber.Name = "personContractNumber";
            this.personContractNumber.ReadOnly = true;
            this.personContractNumber.Size = new System.Drawing.Size(336, 22);
            this.personContractNumber.TabIndex = 4;
            this.personContractNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // personDismissalNumber
            // 
            this.personDismissalNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.personDismissalNumber.Location = new System.Drawing.Point(433, 254);
            this.personDismissalNumber.Name = "personDismissalNumber";
            this.personDismissalNumber.ReadOnly = true;
            this.personDismissalNumber.Size = new System.Drawing.Size(336, 22);
            this.personDismissalNumber.TabIndex = 5;
            this.personDismissalNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // birthadyDateTimePicker
            // 
            this.birthadyDateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.Black;
            this.birthadyDateTimePicker.Enabled = false;
            this.birthadyDateTimePicker.Location = new System.Drawing.Point(433, 305);
            this.birthadyDateTimePicker.Name = "birthadyDateTimePicker";
            this.birthadyDateTimePicker.Size = new System.Drawing.Size(336, 22);
            this.birthadyDateTimePicker.TabIndex = 6;
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.ForeColor = System.Drawing.Color.LightCoral;
            this.NameLable.Location = new System.Drawing.Point(430, 30);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(45, 17);
            this.NameLable.TabIndex = 7;
            this.NameLable.Text = "Name";
            // 
            // surnameLable
            // 
            this.surnameLable.AutoSize = true;
            this.surnameLable.ForeColor = System.Drawing.Color.LightCoral;
            this.surnameLable.Location = new System.Drawing.Point(430, 81);
            this.surnameLable.Name = "surnameLable";
            this.surnameLable.Size = new System.Drawing.Size(65, 17);
            this.surnameLable.TabIndex = 8;
            this.surnameLable.Text = "Surname";
            // 
            // PatronymicLabel
            // 
            this.PatronymicLabel.AutoSize = true;
            this.PatronymicLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.PatronymicLabel.Location = new System.Drawing.Point(430, 132);
            this.PatronymicLabel.Name = "PatronymicLabel";
            this.PatronymicLabel.Size = new System.Drawing.Size(78, 17);
            this.PatronymicLabel.TabIndex = 9;
            this.PatronymicLabel.Text = "Patronymic";
            // 
            // contractNumberLabel
            // 
            this.contractNumberLabel.AutoSize = true;
            this.contractNumberLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.contractNumberLabel.Location = new System.Drawing.Point(430, 183);
            this.contractNumberLabel.Name = "contractNumberLabel";
            this.contractNumberLabel.Size = new System.Drawing.Size(115, 17);
            this.contractNumberLabel.TabIndex = 10;
            this.contractNumberLabel.Text = "Contract Number";
            // 
            // dismissalNumberLabel
            // 
            this.dismissalNumberLabel.AutoSize = true;
            this.dismissalNumberLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.dismissalNumberLabel.Location = new System.Drawing.Point(430, 234);
            this.dismissalNumberLabel.Name = "dismissalNumberLabel";
            this.dismissalNumberLabel.Size = new System.Drawing.Size(121, 17);
            this.dismissalNumberLabel.TabIndex = 11;
            this.dismissalNumberLabel.Text = "Dismissal Number";
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.AutoSize = true;
            this.birthdayLabel.ForeColor = System.Drawing.Color.LightCoral;
            this.birthdayLabel.Location = new System.Drawing.Point(430, 285);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(60, 17);
            this.birthdayLabel.TabIndex = 12;
            this.birthdayLabel.Text = "Birthday";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(592, 388);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 13;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonEddited
            // 
            this.buttonEddited.Enabled = false;
            this.buttonEddited.Location = new System.Drawing.Point(694, 388);
            this.buttonEddited.Name = "buttonEddited";
            this.buttonEddited.Size = new System.Drawing.Size(75, 23);
            this.buttonEddited.TabIndex = 14;
            this.buttonEddited.Text = "Editted";
            this.buttonEddited.UseVisualStyleBackColor = true;
            this.buttonEddited.Click += new System.EventHandler(this.buttonEddited_Click);
            // 
            // FormAllInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 486);
            this.Controls.Add(this.buttonEddited);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.birthdayLabel);
            this.Controls.Add(this.dismissalNumberLabel);
            this.Controls.Add(this.contractNumberLabel);
            this.Controls.Add(this.PatronymicLabel);
            this.Controls.Add(this.surnameLable);
            this.Controls.Add(this.NameLable);
            this.Controls.Add(this.birthadyDateTimePicker);
            this.Controls.Add(this.personDismissalNumber);
            this.Controls.Add(this.personContractNumber);
            this.Controls.Add(this.personPatronymic);
            this.Controls.Add(this.personSurname);
            this.Controls.Add(this.personPhoto);
            this.Controls.Add(this.personName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAllInfo";
            this.Text = "All Info";
            this.Load += new System.EventHandler(this.FormAllInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.personPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.TextBox personName;
        protected System.Windows.Forms.TextBox personSurname;
        protected System.Windows.Forms.TextBox personPatronymic;
        protected System.Windows.Forms.TextBox personContractNumber;
        protected System.Windows.Forms.TextBox personDismissalNumber;
        protected System.Windows.Forms.PictureBox personPhoto;
        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.Label surnameLable;
        private System.Windows.Forms.Label PatronymicLabel;
        private System.Windows.Forms.Label contractNumberLabel;
        private System.Windows.Forms.Label dismissalNumberLabel;
        private System.Windows.Forms.Label birthdayLabel;
        protected System.Windows.Forms.DateTimePicker birthadyDateTimePicker;
        protected System.Windows.Forms.Button buttonEddited;
        protected System.Windows.Forms.Button buttonEdit;
    }
}