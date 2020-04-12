using _03_Disconnected_layer_proj._02_View;
using _03_Disconnected_layer_proj._02_View.Forms;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj
{
    public partial class AddForm : Form, IAdd
    {
        public List<Check> CheckList { get; set; }
        public List<Buyer> Buyers { get; set; }
        public List<Fridge> Fridges { get; set; }
        public List<Seller> Sellers { get; set; }

        public event EventHandler AddEvent;
        public event EventHandler AddCheck;
        public event EventHandler AddBuyerEvent;
        public event EventHandler AddSellerEvent;
        public event EventHandler AddFridgeEvent;

        public AddForm(List<Check> checkList)
        {
            InitializeComponent();

            CheckList = checkList;
        }

        public void Load()
        {
            AddEvent?.Invoke(this, EventArgs.Empty);

            FillBuyerComboBox();
            FillSellerComboBox();
            FillFridgeComboBox();
        }
        private void FillBuyerComboBox()
        {
            buyerComboBox.Items.Clear();

            foreach (Buyer buyer in Buyers)
            {
                buyerComboBox.Items.Add(buyer);
            }
            buyerComboBox.DisplayMember = "Name";
            buyerComboBox.SelectedIndex = 0;
        }
        private void FillSellerComboBox()
        {
            sellerComboBox.Items.Clear();

            foreach (Seller seller in Sellers)
            {
                sellerComboBox.Items.Add(seller);
            }
            sellerComboBox.DisplayMember = "Name";
            sellerComboBox.SelectedIndex = 0;
        }
        private void FillFridgeComboBox()
        {
            fridgeComboBox.Items.Clear();

            foreach (Fridge fridge in Fridges)
            {
                fridgeComboBox.Items.Add(fridge);
            }
            fridgeComboBox.DisplayMember = "Brand";
            fridgeComboBox.SelectedIndex = 0;
        }

        private void addBuyerButton_Click(object sender, EventArgs e)
        {
            AddElementForm form = new AddElementForm(this, "Buyer");
            form.ShowDialog();
        }
        private void addSellerButton_Click(object sender, EventArgs e)
        {
            AddElementForm form = new AddElementForm(this, "Seller");
            form.ShowDialog();
        }
        private void addFridgeButton_Click(object sender, EventArgs e)
        {
            AddFridgeForm form = new AddFridgeForm(this);
            form.ShowDialog();
        }

        public void AddBuyer(Buyer buyer)
        {
            AddBuyerEvent(buyer, EventArgs.Empty);
            FillBuyerComboBox();
        }
        public void AddSeller(Seller seller)
        {
            AddSellerEvent(seller, EventArgs.Empty);
            FillSellerComboBox();
        }
        public void AddFridge(Fridge fridge)
        {
            AddFridgeEvent(fridge, EventArgs.Empty);
            FillFridgeComboBox();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text != string.Empty && dateTimePicker.Value != null &&
                buyerComboBox.SelectedItem != null && sellerComboBox.SelectedItem != null && fridgeComboBox.SelectedItem != null)
            {
                Buyer buyer = buyerComboBox.SelectedItem as Buyer;
                Seller seller = sellerComboBox.SelectedItem as Seller;
                Fridge fridge = fridgeComboBox.SelectedItem as Fridge;

                Check check = new Check{Number = textBoxNumber.Text,
                                        Date = dateTimePicker.Value,
                                        Buyer = buyer,
                                        Seller = seller,
                                        Fridge = fridge
                                        };
                
                CheckList.Add(check);
                AddCheck(check, EventArgs.Empty);

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
