namespace _03_Disconnected_layer_proj
{
    public class Fridge
    {
        public long Id { get; private set; }
        public string Brand { get; private set; }
        public string Number { get; private set; }

        public Fridge(long id, string brand, string number)
        {
            Id = id;
            Brand = brand;
            Number = number;
        }
    }
}
