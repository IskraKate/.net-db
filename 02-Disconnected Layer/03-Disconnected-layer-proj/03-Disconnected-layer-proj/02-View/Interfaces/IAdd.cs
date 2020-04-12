using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Disconnected_layer_proj._02_View.Interfaces
{
    interface IAdd
    {
        List<Buyer> Buyers { get; set; }
        List<Seller> Sellers { get; set; }
        List<Fridge> Fridges { get; set; }

        event EventHandler AddEvent;
        event EventHandler AddCheck;

        event EventHandler AddBuyerEvent;
        event EventHandler AddSellerEvent;
        event EventHandler AddFridgeEvent;
    }
}
