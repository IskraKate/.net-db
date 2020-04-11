﻿using _03_Disconnected_layer_proj._02_View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj
{
    public partial class AddForm : Form, IView
    {
        public List<Check> CheckList { get; set; }
        public List<Buyer> BuyerList { get; set; }
        public List<Fridge> FridgeList { get; set; }
        public List<Seller> SellerList { get; set; }

        public Check check { get; }

        public event EventHandler ViewEvent;

        public AddForm()
        {
            InitializeComponent();
        }

        public AddForm(FridgeShop fridgeShop)
        {
            InitializeComponent();
            CheckList = new List<Check>();
       
            //AddCheck += fridgeShop.AddCheck;

            //foreach (DataRow row in _dataSet.Tables[0].Rows)
            //{
            //    Buyer buyer = new Buyer(row.Field<long>("Id"), row.Field<string>("Name"));
            //    buyerComboBox.Items.Add(buyer);
            //}
            //buyerComboBox.DisplayMember = "Name";
            //buyerComboBox.SelectedIndex = 0;


            //_dataSet = new DataSet("FridgeShopDB");
            //fridgeShop.SqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Sellers", fridgeShop.SqlConnection);
            //fridgeShop.SqlDataAdapter.Fill(_dataSet);
            //foreach (DataRow row in _dataSet.Tables[0].Rows)
            //{
            //    Seller seller = new Seller(row.Field<long>("Id"), row.Field<string>("Name"));
            //    sellerComboBox.Items.Add(seller);
            //}
            //sellerComboBox.DisplayMember = "Name";
            //sellerComboBox.SelectedIndex = 0;


            //_dataSet = new DataSet("FridgeShopDB");
            //fridgeShop.SqlDataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Fridges", fridgeShop.SqlConnection);
            //fridgeShop.SqlDataAdapter.Fill(_dataSet);
            //foreach (DataRow row in _dataSet.Tables[0].Rows)
            //{
            //    Fridge fridge = new Fridge(row.Field<long>("Id"), row.Field<string>("Brand"), row.Field<string>("Number"));
            //    fridgeComboBox.Items.Add(fridge);
            //}
            //fridgeComboBox.DisplayMember = "Brand";
            //fridgeComboBox.SelectedIndex = 0;
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //if (textBoxNumber.Text != string.Empty && dateTimePicker.Value != null &&
            //    buyerComboBox.SelectedItem != null && sellerComboBox.SelectedItem != null && fridgeComboBox.SelectedItem != null)
            //{
            //    Buyer buyer = buyerComboBox.SelectedItem as Buyer;
            //    Seller seller = sellerComboBox.SelectedItem as Seller;
            //    Fridge fridge = fridgeComboBox.SelectedItem as Fridge;

            //    Check check = new Check(int.Parse(textBoxNumber.Text),
            //                            dateTimePicker.Value,
            //                            buyer.Id,
            //                            seller.Id,
            //                            fridge.Id);

            //    AddCheck(check);
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Please fill all the fields");
            //}
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}