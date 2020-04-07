namespace _03_Disconnected_layer_proj
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelTelSeller = new System.Windows.Forms.Label();
            this.labelBuyer = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.fridgeComboBox = new System.Windows.Forms.ComboBox();
            this.sellerComboBox = new System.Windows.Forms.ComboBox();
            this.buyerComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(137, 264);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(73, 24);
            this.buttonAdd.TabIndex = 20;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelTelSeller
            // 
            this.labelTelSeller.AutoSize = true;
            this.labelTelSeller.Location = new System.Drawing.Point(18, 162);
            this.labelTelSeller.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTelSeller.Name = "labelTelSeller";
            this.labelTelSeller.Size = new System.Drawing.Size(36, 13);
            this.labelTelSeller.TabIndex = 19;
            this.labelTelSeller.Text = "Seller:";
            // 
            // labelBuyer
            // 
            this.labelBuyer.AutoSize = true;
            this.labelBuyer.Location = new System.Drawing.Point(18, 116);
            this.labelBuyer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBuyer.Name = "labelBuyer";
            this.labelBuyer.Size = new System.Drawing.Size(37, 13);
            this.labelBuyer.TabIndex = 18;
            this.labelBuyer.Text = "Buyer:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(18, 70);
            this.labelDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(33, 13);
            this.labelDate.TabIndex = 17;
            this.labelDate.Text = "Date:";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(18, 23);
            this.labelNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(47, 13);
            this.labelNumber.TabIndex = 16;
            this.labelNumber.Text = "Number:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(20, 39);
            this.textBoxNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(427, 20);
            this.textBoxNumber.TabIndex = 12;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(243, 264);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(73, 24);
            this.buttonCancel.TabIndex = 24;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(21, 86);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 211);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Fridge";
            // 
            // fridgeComboBox
            // 
            this.fridgeComboBox.FormattingEnabled = true;
            this.fridgeComboBox.Location = new System.Drawing.Point(21, 227);
            this.fridgeComboBox.Name = "fridgeComboBox";
            this.fridgeComboBox.Size = new System.Drawing.Size(426, 21);
            this.fridgeComboBox.TabIndex = 28;
            // 
            // sellerComboBox
            // 
            this.sellerComboBox.FormattingEnabled = true;
            this.sellerComboBox.Location = new System.Drawing.Point(21, 178);
            this.sellerComboBox.Name = "sellerComboBox";
            this.sellerComboBox.Size = new System.Drawing.Size(426, 21);
            this.sellerComboBox.TabIndex = 29;
            // 
            // buyerComboBox
            // 
            this.buyerComboBox.FormattingEnabled = true;
            this.buyerComboBox.Location = new System.Drawing.Point(21, 132);
            this.buyerComboBox.Name = "buyerComboBox";
            this.buyerComboBox.Size = new System.Drawing.Size(426, 21);
            this.buyerComboBox.TabIndex = 30;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 318);
            this.Controls.Add(this.buyerComboBox);
            this.Controls.Add(this.sellerComboBox);
            this.Controls.Add(this.fridgeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelTelSeller);
            this.Controls.Add(this.labelBuyer);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.textBoxNumber);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Button buttonAdd;
        protected System.Windows.Forms.Label labelTelSeller;
        protected System.Windows.Forms.Label labelBuyer;
        protected System.Windows.Forms.Label labelDate;
        protected System.Windows.Forms.Label labelNumber;
        protected System.Windows.Forms.TextBox textBoxNumber;
        protected System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fridgeComboBox;
        private System.Windows.Forms.ComboBox sellerComboBox;
        private System.Windows.Forms.ComboBox buyerComboBox;
    }
}