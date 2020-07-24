using System;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj._02_View.Interfaces
{
    public delegate void ViewAddHandler(ComboBox fridges, ComboBox buyers, ComboBox sellers);
    public delegate void BuyersUpdateHandler(string name);
    public delegate void SellersUpdateHandler(string name);
    public delegate void FridgesUpdateHandler(string brand, string number);
    public delegate void AddCheckHandler();

    interface IAdd
    {
        event ViewAddHandler AddEvent;
        event BuyersUpdateHandler BuyersUpdateEvent;
        event SellersUpdateHandler SellersUpdateEvent;
        event FridgesUpdateHandler FridgesUdateEvent;
        event AddCheckHandler AddCheckEvent;

        string Brand { get; }

        string Number { get; }

        string BuyerName { get; }

        string SellerName { get; }
        DateTime Date { get; }
    }
}
