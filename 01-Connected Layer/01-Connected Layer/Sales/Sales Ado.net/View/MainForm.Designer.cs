namespace Sales
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BFirstname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BLastname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MoneySum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // BFirstname
            // 
            this.BFirstname.Text = "Buyer`s Name";
            this.BFirstname.Width = 145;
            // 
            // BLastname
            // 
            this.BLastname.Text = "Buyer`s LastName";
            this.BLastname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BLastname.Width = 145;
            // 
            // SFirstName
            // 
            this.SFirstName.Text = "Saler`s Name";
            this.SFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SFirstName.Width = 145;
            // 
            // SLastName
            // 
            this.SLastName.Text = "Saler`s Lastname";
            this.SLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SLastName.Width = 145;
            // 
            // MoneySum
            // 
            this.MoneySum.Text = "Money Sum";
            this.MoneySum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MoneySum.Width = 100;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Date.Width = 120;
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.AutoArrange = false;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BFirstname,
            this.BLastname,
            this.SFirstName,
            this.SLastName,
            this.MoneySum,
            this.Date});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Scrollable = false;
            this.listView.Size = new System.Drawing.Size(800, 450);
            this.listView.TabIndex = 2;
            this.listView.TabStop = false;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader BFirstname;
        private System.Windows.Forms.ColumnHeader BLastname;
        private System.Windows.Forms.ColumnHeader SFirstName;
        private System.Windows.Forms.ColumnHeader SLastName;
        private System.Windows.Forms.ColumnHeader MoneySum;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ListView listView;
    }
}

