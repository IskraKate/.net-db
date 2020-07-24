using _03_Disconnected_layer_proj._02_View.Forms;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using System;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj
{
    public partial class AddForm : Form, IAdd
    {
        public string Brand { get; private set; }
        public string Number { get; private set; }
        public string BuyerName{ get; private set; }
        public string SellerName{ get; private set; }
        public DateTime Date{ get; private set; }

        public event ViewAddHandler AddEvent;
        public event BuyersUpdateHandler BuyersUpdateEvent;
        public event SellersUpdateHandler SellersUpdateEvent;
        public event FridgesUpdateHandler FridgesUdateEvent;
        public event AddCheckHandler AddCheckEvent;

        public AddForm()
        {
            InitializeComponent();
        }

        public void Load()
        {
            AddEvent?.Invoke(fridgeComboBox, buyerComboBox, sellerComboBox);
        }

        private void addBuyerButton_Click(object sender, EventArgs e)
        {
            AddElementForm form = new AddElementForm("Buyer");
            form.ShowDialog();
            buyerComboBox.Items.Add(form.Text);
            BuyersUpdateEvent?.Invoke(form.Text);
        }

        private void addSellerButton_Click(object sender, EventArgs e)
        {
            AddElementForm form = new AddElementForm( "Seller");
            form.ShowDialog();
            sellerComboBox.Items.Add(form.Text);
            SellersUpdateEvent?.Invoke(form.Text);
        }

        private void addFridgeButton_Click(object sender, EventArgs e)
        {
            AddFridgeForm form = new AddFridgeForm(this);
            form.ShowDialog();
            fridgeComboBox.Items.Add(form.Brand);
            FridgesUdateEvent?.Invoke(form.Brand, form.Number);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text != string.Empty && dateTimePicker.Value != null &&
               buyerComboBox.SelectedItem != null && sellerComboBox.SelectedItem != null && fridgeComboBox.SelectedItem != null)
            {
                Date = dateTimePicker.Value;
                Number = textBoxNumber.Text;
                Brand = fridgeComboBox.Text;
                BuyerName = buyerComboBox.Text;
                SellerName = sellerComboBox.Text;

                AddCheckEvent?.Invoke();

                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
