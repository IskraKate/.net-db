using System;

namespace _03_Disconnected_layer_proj
{
    public class Check
    {
        public long Id { get; private set; }
        public int Number { get; private set; }
        public DateTime Date { get; private set; }

        public long BuyerId { get; private set; }
        public string Buyer { get; private set; }

        public long SellerId { get; private set; }
        public string Seller { get; private set; }

        public long FridgeId { get; private set; }
        public string Fridge { get; private set; }


        public Check(int number, DateTime date, long buyerId, long sellerId, long fridgeId)
        {
            Number = number;
            Date = date;
            BuyerId = buyerId;
            SellerId = sellerId;
            FridgeId = fridgeId;
        }
        public Check(int number, DateTime date, string buyer, string seller, string fridge)
        {
            Number = number;
            Date = date;
            Buyer = buyer;
            Seller = seller;
            Fridge = fridge;
        }
        public Check(long id, int number, DateTime date, string buyer, string seller, string fridge)
        {
            Id = id;
            Number = number;
            Date = date;
            Buyer = buyer;
            Seller = seller;
            Fridge = fridge;
        }
    }
}
