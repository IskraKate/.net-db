using System.Collections.Generic;

namespace _02_Disconected_layer_proj._01_Model.Interfaces
{
    interface IModel
    {
        List<Author> Authors { get; set; }
        List<Book> Books { get; set; }
        List<Press> Presses { get; set; }

        void FillAuthorsList();
        void FillPressesList();
        void FillBooksList();
    }
}
