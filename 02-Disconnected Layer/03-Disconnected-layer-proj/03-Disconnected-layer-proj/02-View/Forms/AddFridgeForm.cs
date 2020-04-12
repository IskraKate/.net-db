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
    public partial class AddFridgeForm : Form
    {
        private delegate void AddFridgeHandler(Fridge fridge);
        private event AddFridgeHandler AddFridge;

        public AddFridgeForm()
        {
            InitializeComponent();
        }
        public AddFridgeForm(AddForm form)
        {
            InitializeComponent();

            AddFridge += form.AddFridge;
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxBrand.Text != string.Empty && textBoxNumber.Text != string.Empty)
            {
                AddFridge(new Fridge { Brand = textBoxBrand.Text, Number = textBoxNumber.Text } );
                this.Close();
            }
            else
            {
                MessageBox.Show("Fill textbox");
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
