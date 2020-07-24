using System.Collections.Generic;

namespace _03_Disconnected_layer_proj._01_Model.Interfaces
{
    interface IModel
    {
        void Fill();
        void AddCheck(Check check);
        void AddBuyer(Buyer buyer);
        void AddSeller(Seller seller);
        void AddFridge(Fridge fridge);
        void Delete(Check check);
        void SaveToXML(List<Check> checkList);


        List<Buyer> Buyers { get; set; }
        List<Seller> Sellers { get; set; }
        List<Fridge> Fridges { get; set; }
        List<Check> Checks { get; set; }
    }
}
