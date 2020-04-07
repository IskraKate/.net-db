namespace _02_LINQ_project
{
    partial class FormGemstone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGemstone));
            this.listBoxGems = new System.Windows.Forms.ListBox();
            this.checkBoxColorOrange = new System.Windows.Forms.CheckBox();
            this.checkBoxColorPurple = new System.Windows.Forms.CheckBox();
            this.checkBoxColorRed = new System.Windows.Forms.CheckBox();
            this.groupBoxColors = new System.Windows.Forms.GroupBox();
            this.groupBoxColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxGems
            // 
            this.listBoxGems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxGems.FormattingEnabled = true;
            this.listBoxGems.ItemHeight = 16;
            this.listBoxGems.Location = new System.Drawing.Point(24, 12);
            this.listBoxGems.Name = "listBoxGems";
            this.listBoxGems.Size = new System.Drawing.Size(299, 420);
            this.listBoxGems.TabIndex = 0;
            this.listBoxGems.SelectedIndexChanged += new System.EventHandler(this.listBoxGems_SelectedIndexChanged);
            // 
            // checkBoxColorOrange
            // 
            this.checkBoxColorOrange.AutoSize = true;
            this.checkBoxColorOrange.Location = new System.Drawing.Point(6, 21);
            this.checkBoxColorOrange.Name = "checkBoxColorOrange";
            this.checkBoxColorOrange.Size = new System.Drawing.Size(78, 21);
            this.checkBoxColorOrange.TabIndex = 1;
            this.checkBoxColorOrange.Text = "Orange";
            this.checkBoxColorOrange.UseVisualStyleBackColor = true;
            this.checkBoxColorOrange.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxColorPurple
            // 
            this.checkBoxColorPurple.AutoSize = true;
            this.checkBoxColorPurple.Location = new System.Drawing.Point(6, 73);
            this.checkBoxColorPurple.Name = "checkBoxColorPurple";
            this.checkBoxColorPurple.Size = new System.Drawing.Size(71, 21);
            this.checkBoxColorPurple.TabIndex = 2;
            this.checkBoxColorPurple.Text = "Purple";
            this.checkBoxColorPurple.UseVisualStyleBackColor = true;
            this.checkBoxColorPurple.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBoxColorRed
            // 
            this.checkBoxColorRed.AutoSize = true;
            this.checkBoxColorRed.Location = new System.Drawing.Point(6, 47);
            this.checkBoxColorRed.Name = "checkBoxColorRed";
            this.checkBoxColorRed.Size = new System.Drawing.Size(56, 21);
            this.checkBoxColorRed.TabIndex = 3;
            this.checkBoxColorRed.Text = "Red";
            this.checkBoxColorRed.UseVisualStyleBackColor = true;
            this.checkBoxColorRed.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // groupBoxColors
            // 
            this.groupBoxColors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxColors.Controls.Add(this.checkBoxColorOrange);
            this.groupBoxColors.Controls.Add(this.checkBoxColorPurple);
            this.groupBoxColors.Controls.Add(this.checkBoxColorRed);
            this.groupBoxColors.Location = new System.Drawing.Point(341, 12);
            this.groupBoxColors.Name = "groupBoxColors";
            this.groupBoxColors.Size = new System.Drawing.Size(98, 100);
            this.groupBoxColors.TabIndex = 4;
            this.groupBoxColors.TabStop = false;
            this.groupBoxColors.Text = "Colors";
            // 
            // FormGemstone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 450);
            this.Controls.Add(this.groupBoxColors);
            this.Controls.Add(this.listBoxGems);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGemstone";
            this.Text = "Gemsones";
            this.groupBoxColors.ResumeLayout(false);
            this.groupBoxColors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGems;
        private System.Windows.Forms.CheckBox checkBoxColorOrange;
        private System.Windows.Forms.CheckBox checkBoxColorPurple;
        private System.Windows.Forms.CheckBox checkBoxColorRed;
        private System.Windows.Forms.GroupBox groupBoxColors;
    }
}

