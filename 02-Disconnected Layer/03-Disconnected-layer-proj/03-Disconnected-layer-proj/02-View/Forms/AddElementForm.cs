using System;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj._02_View.Forms
{
    public partial class AddElementForm : Form
    {
        public string Text
        {
            get
            {
                return textBoxName.Text;
            }
        }

        public AddElementForm()
        {
            InitializeComponent();
        }
        public AddElementForm(string labelString)
        {
            InitializeComponent();
            labelName.Text = $" {labelString}:";
            textBoxName.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxName.Text))
                this.Close();
            else
                MessageBox.Show("Enter buyer name, please");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            this.Close();
        }
    }
}
