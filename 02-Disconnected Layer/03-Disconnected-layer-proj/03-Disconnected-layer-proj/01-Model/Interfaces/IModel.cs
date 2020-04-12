using System.Collections.Generic;

namespace _03_Disconnected_layer_proj.Model
{
    interface IModel
    {
        List<Check> Fill(List<Check> checks);
        void AddCheck(Check check);
        void AddBuyer(Buyer buyer);
        void AddSeller(Seller seller);
        void AddFridge(Fridge fridge);
        
        void Delete(Check check);
        void SaveToXML(List<Check> checkList);



        List<Buyer> Buyers { get; set; }
        List<Seller> Sellers { get; set; }
        List<Fridge> Fridges { get; set; }
    }
}
