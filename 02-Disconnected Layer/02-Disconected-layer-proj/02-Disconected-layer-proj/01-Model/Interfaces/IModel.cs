using System.Collections.Generic;

namespace _02_Disconected_layer_proj._01_Model.Interfaces
{
    interface IModel
    {
        List<Author> FillAuthorsList(List<Author> authors);
        List<Press> FillPressesList(List<Press> authors);
        List<Book> FillBooksList(List<Book> books);
    }
}
