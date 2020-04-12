using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj._02_View.Forms
{
    public partial class AddElementForm : Form
    {
        private delegate void AddBuyerHandler(Buyer buyer);
        private event AddBuyerHandler AddBuyer;

        private delegate void AddSellerHandler(Seller seller);
        private event AddSellerHandler AddSeller;

        public AddElementForm()
        {
            InitializeComponent();
        }
        public AddElementForm(AddForm form, string labelString)
        {
            InitializeComponent();

            AddBuyer += form.AddBuyer;
            AddSeller += form.AddSeller;

            this.Text = "Add " + labelString;
            labelName.Text = labelString + ":";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text != string.Empty)
            {
                if(labelName.Text.Contains("Buyer"))
                {
                    AddBuyer(new Buyer { Name = textBoxName.Text });
                }
                else if(labelName.Text.Contains("Seller"))
                {
                    AddSeller(new Seller { Name = textBoxName.Text });
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Fill the textbox");
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
