using System;

namespace _03_Disconnected_layer_proj
{
    public class Check
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }

        public Buyer Buyer { get; set; }
        public Seller Seller { get; set; }
        public Fridge Fridge { get; set; }
    }
}
