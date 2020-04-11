using System;

namespace _03_Disconnected_layer_proj
{
    public class Check
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }

        public string Brand { get; set; }
        public long BrandFk { get; set; }

        public string Buyer { get; set; }
        public long BuyerFk { get; set; }

        public string Seller { get; set; }
        public long SellerFk { get; set; }
    }
}
