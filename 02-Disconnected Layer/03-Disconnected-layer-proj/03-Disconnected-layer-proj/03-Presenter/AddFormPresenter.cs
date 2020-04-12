using _03_Disconnected_layer_proj._02_View;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using _03_Disconnected_layer_proj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Disconnected_layer_proj._03_Presenter
{
    class AddFormPresenter
    {
        private IModel _model;
        private IAdd _add;

        public AddFormPresenter(IAdd add, IModel model)
        {
            _model = model;
            _add = add;

            _add.AddEvent += FillAddFormEvent;
            _add.AddCheck += _add_AddCheck;
            _add.AddBuyerEvent += AddBuyerEvent;
            _add.AddSellerEvent += AddSellerEvent;
            _add.AddFridgeEvent += AddFridgeEvent;
        }





        private void AddBuyerEvent(object sender, EventArgs e)
        {
            _model.AddBuyer(sender as Buyer);
            _add.Buyers = _model.Buyers;
        }
        private void AddFridgeEvent(object sender, EventArgs e)
        {
            _model.AddFridge(sender as Fridge);
            _add.Fridges = _model.Fridges;
        }
        private void AddSellerEvent(object sender, EventArgs e)
        {
            _model.AddSeller(sender as Seller);
            _add.Sellers = _model.Sellers;
        }


        private void _add_AddCheck(object sender, EventArgs e)
        {
            _model.AddCheck(sender as Check);
        }

        private void FillAddFormEvent(object sender, EventArgs e)
        {
            _add.Fridges = _model.Fridges;
            _add.Buyers = _model.Buyers;
            _add.Sellers = _model.Sellers;
        }

    }
}
