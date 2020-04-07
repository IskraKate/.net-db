namespace _03_Disconnected_layer_proj
{
    public class Seller
    {
        public long Id { get; private set; }
        public string Name { get; private set; }

        public Seller(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
