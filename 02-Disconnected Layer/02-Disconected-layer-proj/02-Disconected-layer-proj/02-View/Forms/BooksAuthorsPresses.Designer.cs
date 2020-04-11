namespace _02_Disconected_layer_proj
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
            this.checkBoxAuthors = new System.Windows.Forms.CheckBox();
            this.checkBoxPresses = new System.Windows.Forms.CheckBox();
            this.comboBoxAuthors = new System.Windows.Forms.ComboBox();
            this.comboBoxPresses = new System.Windows.Forms.ComboBox();
            this.listBoxBooks = new System.Windows.Forms.ListBox();
            this.burronSearch = new System.Windows.Forms.Button();
            this.labelBooks = new System.Windows.Forms.Label();
            this.groupBoxAuthors = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxAuthors.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxAuthors
            // 
            this.checkBoxAuthors.AutoSize = true;
            this.checkBoxAuthors.Location = new System.Drawing.Point(479, 30);
            this.checkBoxAuthors.Name = "checkBoxAuthors";
            this.checkBoxAuthors.Size = new System.Drawing.Size(79, 21);
            this.checkBoxAuthors.TabIndex = 0;
            this.checkBoxAuthors.Text = "Authors";
            this.checkBoxAuthors.UseVisualStyleBackColor = true;
            this.checkBoxAuthors.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // checkBoxPresses
            // 
            this.checkBoxPresses.AutoSize = true;
            this.checkBoxPresses.Location = new System.Drawing.Point(477, 33);
            this.checkBoxPresses.Name = "checkBoxPresses";
            this.checkBoxPresses.Size = new System.Drawing.Size(81, 21);
            this.checkBoxPresses.TabIndex = 1;
            this.checkBoxPresses.Text = "Presses";
            this.checkBoxPresses.UseVisualStyleBackColor = true;
            this.checkBoxPresses.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // comboBoxAuthors
            // 
            this.comboBoxAuthors.FormattingEnabled = true;
            this.comboBoxAuthors.Location = new System.Drawing.Point(6, 28);
            this.comboBoxAuthors.Name = "comboBoxAuthors";
            this.comboBoxAuthors.Size = new System.Drawing.Size(440, 24);
            this.comboBoxAuthors.TabIndex = 2;
            // 
            // comboBoxPresses
            // 
            this.comboBoxPresses.FormattingEnabled = true;
            this.comboBoxPresses.Location = new System.Drawing.Point(6, 31);
            this.comboBoxPresses.Name = "comboBoxPresses";
            this.comboBoxPresses.Size = new System.Drawing.Size(440, 24);
            this.comboBoxPresses.TabIndex = 3;
            // 
            // listBoxBooks
            // 
            this.listBoxBooks.FormattingEnabled = true;
            this.listBoxBooks.ItemHeight = 16;
            this.listBoxBooks.Location = new System.Drawing.Point(23, 222);
            this.listBoxBooks.Name = "listBoxBooks";
            this.listBoxBooks.Size = new System.Drawing.Size(440, 436);
            this.listBoxBooks.TabIndex = 4;
            // 
            // burronSearch
            // 
            this.burronSearch.Location = new System.Drawing.Point(500, 222);
            this.burronSearch.Name = "burronSearch";
            this.burronSearch.Size = new System.Drawing.Size(100, 38);
            this.burronSearch.TabIndex = 5;
            this.burronSearch.Text = "Search";
            this.burronSearch.UseVisualStyleBackColor = true;
            this.burronSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelBooks
            // 
            this.labelBooks.AutoSize = true;
            this.labelBooks.Location = new System.Drawing.Point(20, 202);
            this.labelBooks.Name = "labelBooks";
            this.labelBooks.Size = new System.Drawing.Size(47, 17);
            this.labelBooks.TabIndex = 8;
            this.labelBooks.Text = "Books";
            // 
            // groupBoxAuthors
            // 
            this.groupBoxAuthors.Controls.Add(this.comboBoxAuthors);
            this.groupBoxAuthors.Controls.Add(this.checkBoxAuthors);
            this.groupBoxAuthors.Location = new System.Drawing.Point(23, 26);
            this.groupBoxAuthors.Name = "groupBoxAuthors";
            this.groupBoxAuthors.Size = new System.Drawing.Size(577, 71);
            this.groupBoxAuthors.TabIndex = 9;
            this.groupBoxAuthors.TabStop = false;
            this.groupBoxAuthors.Text = "Authors";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPresses);
            this.groupBox1.Controls.Add(this.checkBoxPresses);
            this.groupBox1.Location = new System.Drawing.Point(23, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presses";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 670);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAuthors);
            this.Controls.Add(this.labelBooks);
            this.Controls.Add(this.burronSearch);
            this.Controls.Add(this.listBoxBooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BooksAuthorsPresses";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxAuthors.ResumeLayout(false);
            this.groupBoxAuthors.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAuthors;
        private System.Windows.Forms.CheckBox checkBoxPresses;
        private System.Windows.Forms.ComboBox comboBoxAuthors;
        private System.Windows.Forms.ComboBox comboBoxPresses;
        private System.Windows.Forms.ListBox listBoxBooks;
        private System.Windows.Forms.Button burronSearch;
        private System.Windows.Forms.Label labelBooks;
        private System.Windows.Forms.GroupBox groupBoxAuthors;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

