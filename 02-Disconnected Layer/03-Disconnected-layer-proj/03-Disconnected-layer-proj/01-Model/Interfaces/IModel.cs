using _03_Disconnected_layer_proj.Elements;
using System.Collections.Generic;

namespace _03_Disconnected_layer_proj.Model
{
    interface IModel
    {
        List<Check> FillCkeckList(List<Check> checks);
        List<Buyer> FillBuyerList(List<Buyer> buyers);
        List<Fridge> FillFridgeList(List<Fridge> fridges);
        List<Seller> FillSellerList(List<Seller> sellers);
        void Delete(Check check);
        void SaveToXML(List<Check> checkList);
    }
}
