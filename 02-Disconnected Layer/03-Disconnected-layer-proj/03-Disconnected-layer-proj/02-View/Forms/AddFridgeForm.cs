using System;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj._02_View.Forms
{
    public partial class AddFridgeForm : Form
    {
        public string Number
        {
            get
            {
                return textBoxNumber.Text;
            }
        }

        public string Brand
        {
            get
            {
                return textBoxBrand.Text;
            }
        }

        public AddFridgeForm()
        {
            InitializeComponent();
        }
        public AddFridgeForm(AddForm form)
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxBrand.Text)&& !String.IsNullOrEmpty(textBoxNumber.Text))
                this.Close();
            else
                MessageBox.Show("Enter brand and number name, please");
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxBrand.Text = "";
            textBoxNumber.Text = "";
            this.Close();
        }
    }
}
