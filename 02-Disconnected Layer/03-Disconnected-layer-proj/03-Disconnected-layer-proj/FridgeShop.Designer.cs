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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AddCheckButton
            // 
            this.AddCheckButton.Location = new System.Drawing.Point(677, 12);
            this.AddCheckButton.Name = "AddCheckButton";
            this.AddCheckButton.Size = new System.Drawing.Size(84, 23);
            this.AddCheckButton.TabIndex = 1;
            this.AddCheckButton.Text = "Add Check";
            this.AddCheckButton.UseVisualStyleBackColor = true;
            this.AddCheckButton.Click += new System.EventHandler(this.AddRecieptButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(677, 70);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(84, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save to XML";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(643, 378);
            this.dataGridView.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(677, 41);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(84, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // FridgeShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 412);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddCheckButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FridgeShop";
            this.Text = "FridgeShop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FridgeShop_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddCheckButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button deleteButton;
    }
}

