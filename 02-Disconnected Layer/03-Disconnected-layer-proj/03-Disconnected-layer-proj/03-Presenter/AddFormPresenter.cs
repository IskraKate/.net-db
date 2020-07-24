using _03_Disconnected_layer_proj._01_Model;
using _03_Disconnected_layer_proj._01_Model.Interfaces;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj._03_Presenter
{
    class AddFormPresenter
    {
        private IModel _model;
        private IAdd _add;

        public AddFormPresenter(IAdd add)
        {
            _model = Model.GetModel;
            _add = add;

            _add.AddEvent += FillAddFormEvent;
            _add.BuyersUpdateEvent += BuyersOnUpdate;
            _add.SellersUpdateEvent += SellersOnUpdate;
            _add.FridgesUdateEvent += FridgesOnUpdate;
            _add.AddCheckEvent += _add_AddCheck;
        }

        private void OnUpdateElement(ComboBox comboBox)
        {
            comboBox.Items.Clear();
        }

        private void BuyersOnUpdate(string name)
        {
            Buyer buyer = new Buyer();
            buyer.Name = name;
            _model.AddBuyer(buyer);
        }

        private void SellersOnUpdate(string name)
        {
            Seller seller = new Seller();
            seller.Name = name;
            _model.AddSeller(seller);
        }

        private void FridgesOnUpdate(string brand, string number)
        {
            Fridge fridge = new Fridge();
            fridge.Brand = brand;
            fridge.Number = number;
            _model.AddFridge(fridge);
        }

        private void _add_AddCheck()
        {
            Buyer buyer = _model.Buyers.Where(b =>b.Name == _add.BuyerName).First();
            Seller seller = _model.Sellers.Where(s => s.Name == _add.SellerName).First();
            Fridge fridge = _model.Fridges.Where(f => f.Brand == _add.Brand).First();

            Check check = new Check
            {
                Number = _add.Number,
                Date = _add.Date,
                Buyer = buyer,
                Seller = seller,
                Fridge = fridge
            };

             _model.AddCheck(check);
        }

        private void FillAddFormEvent(ComboBox fridges, ComboBox buyers, ComboBox sellers)
        {
            fridges.Items.Clear();
            buyers.Items.Clear();
            sellers.Items.Clear();

            FillComboBox(fridges, _model.Fridges.Select(f => f.Brand).ToArray());
            FillComboBox(buyers, _model.Buyers.Select(b => b.Name).ToArray());
            FillComboBox(sellers, _model.Sellers.Select(s => s.Name).ToArray());

            fridges.DisplayMember = "Brand";
            fridges.SelectedIndex = 0;
            buyers.DisplayMember = "Name";
            buyers.SelectedIndex = 0;
            sellers.DisplayMember = "Name";
            sellers.SelectedIndex = 0;
        }

        private void FillComboBox(ComboBox comboBox, string[] list)
        {
            comboBox.Items.AddRange(list);
        }

    }
}
