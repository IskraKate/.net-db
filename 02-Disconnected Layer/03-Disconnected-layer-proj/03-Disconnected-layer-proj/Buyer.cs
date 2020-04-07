namespace _03_Disconnected_layer_proj
{
    public class Buyer
    {
        public long Id { get; private set; }
        public string Name { get; private set; }

        public Buyer(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
