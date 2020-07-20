namespace _02_Disconected_layer_proj
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public long AuthorFk { get; set; }
        public long PressFk { get; set; }
    }
}
